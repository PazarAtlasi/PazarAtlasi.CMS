using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Models.API.Request;
using PazarAtlasi.CMS.Application.Models.API.Response;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Persistence.Context;
using System.Globalization;

namespace PazarAtlasi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly PazarAtlasiDbContext _pazarAtlasiDbContext;

        public ContentController(
            PazarAtlasiDbContext pazarAtlasiDbContext)
        {
            _pazarAtlasiDbContext = pazarAtlasiDbContext;
        }

        /// <summary>
        /// Test endpoint to check if API is working
        /// </summary>
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "API is working!", timestamp = DateTime.UtcNow });
        }

        /// <summary>
        /// Get page by slug with all sections, items, fields and values
        /// </summary>
        /// <param name="query">Page query with slug and culture</param>
        /// <returns>Complete page data with breadcrumbs</returns>
        [HttpGet("page")]
        public async Task<ActionResult<PageResponse>> GetPage([FromQuery] PageQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{query.Culture}' not found.");
                }

                // Get page by slug with all related data
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.ParentPage)
                    .Include(p => p.PageSEOParameter)
                    .Include(p => p.PageSections.OrderBy(ps => ps.SortOrder))
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.Translations.Where(st => st.LanguageId == language.Id))
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.Translations.Where(sit => sit.LanguageId == language.Id))
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                                .ThenInclude(fv => fv.SectionItemField)
                                .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFieldValues)
                                .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                    .FirstOrDefaultAsync(p => p.Slug == query.Slug && p.Status == Status.Active && !p.IsDeleted);

                if (page == null)
                {
                    return NotFound($"Page with slug '{query.Slug}' not found.");
                }

                // Build breadcrumbs
                var breadcrumbs = await BuildBreadcrumbs(page, language.Id);

                // Build response
                var response = new PageResponse
                {
                    Id = page.Id,
                    Name = page.Name ?? string.Empty,
                    Slug = page.Slug ?? string.Empty,
                    PageType = page.PageType,
                    Description = page.Description,
                    Status = page.Status,
                    Breadcrumbs = breadcrumbs,
                    Sections = await BuildSectionsResponse(page.PageSections.Select(ps => ps.Section).ToList(), language.Id),
                    SEO = page.PageSEOParameter != null ? new PageSEOResponse
                    {
                        Id = page.PageSEOParameter.Id,
                        MetaTitle = page.PageSEOParameter.MetaTitle,
                        MetaDescription = page.PageSEOParameter.MetaDescription,
                        MetaKeywords = page.PageSEOParameter.MetaKeywords,
                        Title = page.PageSEOParameter.Title,
                        CanonicalURL = page.PageSEOParameter.CanonicalURL,
                        Author = page.PageSEOParameter.Author,
                        Description = page.PageSEOParameter.Description
                    } : null,
                    CreatedAt = page.CreatedAt,
                    UpdatedAt = page.UpdatedAt
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #region Private Helper Methods

        /// <summary>
        /// Build breadcrumbs for the page hierarchy
        /// </summary>
        private async Task<List<BreadcrumbItem>> BuildBreadcrumbs(PazarAtlasi.CMS.Domain.Entities.Content.Page page, int languageId)
        {
            var breadcrumbs = new List<BreadcrumbItem>();
            var currentPage = page;
            var pageHierarchy = new List<PazarAtlasi.CMS.Domain.Entities.Content.Page>();

            // Build hierarchy from current page to root
            while (currentPage != null)
            {
                pageHierarchy.Insert(0, currentPage);
                
                if (currentPage.ParentPageId.HasValue)
                {
                    currentPage = await _pazarAtlasiDbContext.Pages
                        .FirstOrDefaultAsync(p => p.Id == currentPage.ParentPageId.Value && !p.IsDeleted);
                }
                else
                {
                    currentPage = null;
                }
            }

            // Convert to breadcrumb items
            for (int i = 0; i < pageHierarchy.Count; i++)
            {
                var hierarchyPage = pageHierarchy[i];
                var isLast = i == pageHierarchy.Count - 1;

                breadcrumbs.Add(new BreadcrumbItem
                {
                    Name = hierarchyPage.Name ?? string.Empty,
                    Href = hierarchyPage.Slug ?? string.Empty,
                    IsActive = isLast
                });
            }

            return breadcrumbs;
        }

        /// <summary>
        /// Build sections response with all nested data
        /// </summary>
        private async Task<List<SectionResponse>> BuildSectionsResponse(List<PazarAtlasi.CMS.Domain.Entities.Content.Section> sections, int languageId)
        {
            var sectionResponses = new List<SectionResponse>();

            foreach (var section in sections.OrderBy(s => s.SortOrder))
            {
                var sectionTranslation = section.Translations.FirstOrDefault();
                
                var sectionResponse = new SectionResponse
                {
                    Id = section.Id,
                    Type = section.Type,
                    Key = section.Key,
                    Attributes = section.Attributes,
                    Configure = section.Configure,
                    SortOrder = section.SortOrder,
                    Status = section.Status,
                    Name = sectionTranslation?.Name,
                    Title = sectionTranslation?.Title,
                    Description = sectionTranslation?.Description,
                    Items = await BuildSectionItemsResponse(section.SectionItemValues.ToList(), languageId)
                };

                sectionResponses.Add(sectionResponse);
            }

            return sectionResponses;
        }

        /// <summary>
        /// Build section items response with hierarchical structure
        /// </summary>
        private async Task<List<SectionItemResponse>> BuildSectionItemsResponse(List<PazarAtlasi.CMS.Domain.Entities.Content.SectionItemValue> sectionItemValues, int languageId)
        {
            var itemResponses = new List<SectionItemResponse>();

            // Group by parent-child relationship
            var rootItems = sectionItemValues
                .Where(siv => siv.SectionItem.ParentSectionItemId == null)
                .OrderBy(siv => siv.SectionItem.SortOrder)
                .ToList();

            foreach (var rootItemValue in rootItems)
            {
                var itemResponse = await BuildSectionItemResponse(rootItemValue.SectionItem, sectionItemValues, languageId);
                itemResponses.Add(itemResponse);
            }

            return itemResponses;
        }

        /// <summary>
        /// Build single section item response with children
        /// </summary>
        private async Task<SectionItemResponse> BuildSectionItemResponse(PazarAtlasi.CMS.Domain.Entities.Content.SectionItem sectionItem, List<PazarAtlasi.CMS.Domain.Entities.Content.SectionItemValue> allSectionItemValues, int languageId)
        {
            var itemTranslation = sectionItem.Translations.FirstOrDefault();

            var itemResponse = new SectionItemResponse
            {
                Id = sectionItem.Id,
                Type = sectionItem.Type,
                MediaType = sectionItem.MediaType,
                SortOrder = sectionItem.SortOrder,
                Status = sectionItem.Status,
                Title = itemTranslation?.Title ?? sectionItem.Title,
                Description = itemTranslation?.Description ?? sectionItem.Description,
                Key = sectionItem.Key,
                AllowReorder = sectionItem.AllowReorder,
                AllowRemove = sectionItem.AllowRemove,
                IconClass = sectionItem.IconClass,
                Fields = BuildFieldsResponse(sectionItem.SectionItemFieldValues.ToList(), languageId)
            };

            // Build children recursively
            var childItemValues = allSectionItemValues
                .Where(siv => siv.SectionItem.ParentSectionItemId == sectionItem.Id)
                .OrderBy(siv => siv.SectionItem.SortOrder)
                .ToList();

            foreach (var childItemValue in childItemValues)
            {
                var childResponse = await BuildSectionItemResponse(childItemValue.SectionItem, allSectionItemValues, languageId);
                itemResponse.Children.Add(childResponse);
            }

            return itemResponse;
        }

        /// <summary>
        /// Build fields response for section item
        /// </summary>
        private List<SectionItemFieldResponse> BuildFieldsResponse(List<PazarAtlasi.CMS.Domain.Entities.Content.SectionItemFieldValue> fieldValues, int languageId)
        {
            var fieldResponses = new List<SectionItemFieldResponse>();

            foreach (var fieldValue in fieldValues.OrderBy(fv => fv.SectionItemField?.SortOrder ?? 0))
            {
                var fieldTranslation = fieldValue.SectionItemField?.Translations.FirstOrDefault();
                var valueTranslation = fieldValue.Translations.FirstOrDefault();

                var fieldResponse = new SectionItemFieldResponse
                {
                    Id = fieldValue.Id,
                    FieldKey = fieldValue.SectionItemField?.FieldKey ?? string.Empty,
                    FieldName = fieldTranslation?.Label ?? fieldValue.SectionItemField?.FieldName ?? string.Empty,
                    Type = fieldValue.SectionItemField?.Type ?? SectionItemFieldType.Text,
                    Required = fieldValue.SectionItemField?.Required ?? false,
                    IsTranslatable = fieldValue.SectionItemField?.IsTranslatable ?? false,
                    Value = valueTranslation?.Value ?? fieldValue.Value,
                    JsonValue = valueTranslation?.JsonValue ?? fieldValue.JsonValue,
                    SortOrder = fieldValue.SectionItemField?.SortOrder ?? 0
                };

                fieldResponses.Add(fieldResponse);
            }

            return fieldResponses;
        }

        #endregion

        /// <summary>
        /// Get page sections by page ID
        /// </summary>
        /// <param name="query">Page section query with page ID and culture</param>
        /// <returns>Page sections data</returns>
        [HttpGet("page-sections")]
        public async Task<ActionResult<PageSectionResponse>> GetPageSections([FromQuery] PageSectionQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{query.Culture}' not found.");
                }

                // Get page with sections
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.PageSections.OrderBy(ps => ps.SortOrder))
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.Translations.Where(st => st.LanguageId == language.Id))
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.Translations.Where(sit => sit.LanguageId == language.Id))
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                                .ThenInclude(fv => fv.SectionItemField)
                                .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFieldValues)
                                .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                    .FirstOrDefaultAsync(p => p.Id == query.PageId && p.Status == Status.Active && !p.IsDeleted);

                if (page == null)
                {
                    return NotFound($"Page with ID '{query.PageId}' not found.");
                }

                var response = new PageSectionResponse
                {
                    PageId = page.Id,
                    PageName = page.Name ?? string.Empty,
                    PageSlug = page.Slug ?? string.Empty,
                    Sections = await BuildSectionsResponse(page.PageSections.Select(ps => ps.Section).ToList(), language.Id)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get section by ID
        /// </summary>
        /// <param name="query">Section query with section ID and culture</param>
        /// <returns>Section data with all items</returns>
        [HttpGet("section")]
        public async Task<ActionResult<SectionResponse>> GetSection([FromQuery] SectionQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{query.Culture}' not found.");
                }

                // Get section with all related data
                var section = await _pazarAtlasiDbContext.Sections
                    .Include(s => s.Translations.Where(st => st.LanguageId == language.Id))
                    .Include(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
                        .ThenInclude(siv => siv.SectionItem)
                        .ThenInclude(si => si.Translations.Where(sit => sit.LanguageId == language.Id))
                    .Include(s => s.SectionItemValues)
                        .ThenInclude(siv => siv.SectionItem)
                        .ThenInclude(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                            .ThenInclude(fv => fv.SectionItemField)
                            .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                    .Include(s => s.SectionItemValues)
                        .ThenInclude(siv => siv.SectionItem)
                        .ThenInclude(si => si.SectionItemFieldValues)
                            .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                    .FirstOrDefaultAsync(s => s.Id == query.SectionId && s.Status == Status.Active && !s.IsDeleted);

                if (section == null)
                {
                    return NotFound($"Section with ID '{query.SectionId}' not found.");
                }

                var sectionTranslation = section.Translations.FirstOrDefault();
                
                var response = new SectionResponse
                {
                    Id = section.Id,
                    Type = section.Type,
                    Key = section.Key,
                    Attributes = section.Attributes,
                    Configure = section.Configure,
                    SortOrder = section.SortOrder,
                    Status = section.Status,
                    Name = sectionTranslation?.Name,
                    Title = sectionTranslation?.Title,
                    Description = sectionTranslation?.Description,
                    Items = await BuildSectionItemsResponse(section.SectionItemValues.ToList(), language.Id)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get section item by ID
        /// </summary>
        /// <param name="query">Section item query with section item ID and culture</param>
        /// <returns>Section item data with all fields</returns>
        [HttpGet("section-item")]
        public async Task<ActionResult<SectionItemResponse>> GetSectionItem([FromQuery] SectionItemQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{query.Culture}' not found.");
                }

                // Get section item with all related data
                var sectionItem = await _pazarAtlasiDbContext.SectionItems
                    .Include(si => si.Translations.Where(sit => sit.LanguageId == language.Id))
                    .Include(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                        .ThenInclude(fv => fv.SectionItemField)
                        .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                    .Include(si => si.SectionItemFieldValues)
                        .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                    .FirstOrDefaultAsync(si => si.Id == query.SectionItemId && si.Status == Status.Active && !si.IsDeleted);

                if (sectionItem == null)
                {
                    return NotFound($"Section item with ID '{query.SectionItemId}' not found.");
                }

                var itemTranslation = sectionItem.Translations.FirstOrDefault();

                var response = new SectionItemResponse
                {
                    Id = sectionItem.Id,
                    Type = sectionItem.Type,
                    MediaType = sectionItem.MediaType,
                    SortOrder = sectionItem.SortOrder,
                    Status = sectionItem.Status,
                    Title = itemTranslation?.Title ?? sectionItem.Title,
                    Description = itemTranslation?.Description ?? sectionItem.Description,
                    Key = sectionItem.Key,
                    AllowReorder = sectionItem.AllowReorder,
                    AllowRemove = sectionItem.AllowRemove,
                    IconClass = sectionItem.IconClass,
                    Fields = BuildFieldsResponse(sectionItem.SectionItemFieldValues.ToList(), language.Id)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get section item field by ID
        /// </summary>
        /// <param name="query">Section item field query with field ID and culture</param>
        /// <returns>Section item field data</returns>
        [HttpGet("section-item-field")]
        public async Task<ActionResult<SectionItemFieldResponse>> GetSectionItemField([FromQuery] SectionItemFieldQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{query.Culture}' not found.");
                }

                // Get section item field value with all related data
                var fieldValue = await _pazarAtlasiDbContext.SectionItemFieldValues
                    .Include(fv => fv.SectionItemField)
                        .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                    .Include(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                    .FirstOrDefaultAsync(fv => fv.Id == query.SectionItemFieldId && !fv.IsDeleted);

                if (fieldValue == null)
                {
                    return NotFound($"Section item field with ID '{query.SectionItemFieldId}' not found.");
                }

                var fieldTranslation = fieldValue.SectionItemField?.Translations.FirstOrDefault();
                var valueTranslation = fieldValue.Translations.FirstOrDefault();

                var response = new SectionItemFieldResponse
                {
                    Id = fieldValue.Id,
                    FieldKey = fieldValue.SectionItemField?.FieldKey ?? string.Empty,
                    FieldName = fieldTranslation?.Label ?? fieldValue.SectionItemField?.FieldName ?? string.Empty,
                    Type = fieldValue.SectionItemField?.Type ?? SectionItemFieldType.Text,
                    Required = fieldValue.SectionItemField?.Required ?? false,
                    IsTranslatable = fieldValue.SectionItemField?.IsTranslatable ?? false,
                    Value = valueTranslation?.Value ?? fieldValue.Value,
                    JsonValue = valueTranslation?.JsonValue ?? fieldValue.JsonValue,
                    SortOrder = fieldValue.SectionItemField?.SortOrder ?? 0
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
