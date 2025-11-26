using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Models.API.Request;
using PazarAtlasi.CMS.Application.Models.API.Response;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Persistence.Context;
using System.Globalization;
using System.Text.Json;

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
        /// Get page by slug with all sections, items, fields and values (including layout sections)
        /// </summary>
        /// <param name="slug">Page slug</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Complete page data with breadcrumbs and layout sections</returns>
        [HttpGet("pages/{slug}")]
        public async Task<ActionResult<PageResponse>> GetPage(string slug, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(slug))
                {
                    return BadRequest("Slug is required.");
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get page by slug with all related data including layout
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.ParentPage)
                    .Include(p => p.Content)
                        .ThenInclude(c => c.ContentSlugs.Where(cs => cs.LanguageId == language.Id))
                    .Include(p => p.Layout) // Include layout
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
                    .FirstOrDefaultAsync(p => p.Content != null &&
                        p.Content.ContentSlugs.Any(cs => cs.Slug.ToLower() == slug.ToLower() && cs.LanguageId == language.Id) &&
                        p.Status == Status.Active && !p.IsDeleted);

                if (page == null)
                {
                    return NotFound($"Page with slug '{slug}' not found.");
                }

                // Build breadcrumbs
                var breadcrumbs = await BuildBreadcrumbs(page, language.Id);

                // Build sections response with layout integration
                var allSections = await BuildPageSectionsWithLayout(page, language.Id);

                // Get current slug for this language
                var currentSlug = page.Content?.ContentSlugs?.FirstOrDefault(cs => cs.LanguageId == language.Id)?.Slug ?? string.Empty;

                // Build response
                var response = new PageResponse
                {
                    Id = page.Id,
                    Name = page.Name ?? string.Empty,
                    Slug = currentSlug,
                    PageType = page.PageType,
                    Description = page.Description,
                    Status = page.Status,
                    LayoutId = page.LayoutId,
                    LayoutName = page.Layout?.Name,
                    Breadcrumbs = breadcrumbs,
                    Sections = allSections,
                    SEO = page.Content != null ? new PageSEOResponse
                    {
                        Id = page.Content.Id,
                        MetaTitle = page.Content.MetaTitle,
                        MetaDescription = page.Content.MetaDescription,
                        MetaKeywords = page.Content.MetaKeywords,
                        Title = page.Content.Title,
                        CanonicalURL = null, // ContentSlugs'dan canonical URL oluşturulabilir
                        Author = page.Content.Author,
                        Description = page.Content.Description
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

        /// <summary>
        /// Get page sections by page slug (including layout sections)
        /// </summary>
        /// <param name="slug">Page slug</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Page sections data with layout sections integrated</returns>
        [HttpGet("pages/{slug}/sections")]
        public async Task<ActionResult<PageSectionResponse>> GetPageSections(string slug, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(slug))
                {
                    return BadRequest("Slug is required.");
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get page with sections and layout
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.Content)
                        .ThenInclude(c => c.ContentSlugs.Where(cs => cs.LanguageId == language.Id))
                    .Include(p => p.Layout) // Include layout
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
                    .FirstOrDefaultAsync(p => p.Content != null &&
                        p.Content.ContentSlugs.Any(cs => cs.Slug.ToLower() == slug.ToLower() && cs.LanguageId == language.Id) &&
                        p.Status == Status.Active && !p.IsDeleted);

                if (page == null)
                {
                    return NotFound($"Page with slug '{slug}' not found.");
                }

                // Build sections response with layout integration
                var allSections = await BuildPageSectionsWithLayout(page, language.Id);

                // Get current slug for this language
                var currentSlug = page.Content?.ContentSlugs?.FirstOrDefault(cs => cs.LanguageId == language.Id)?.Slug ?? string.Empty;

                var response = new PageSectionResponse
                {
                    PageId = page.Id,
                    PageName = page.Name ?? string.Empty,
                    PageSlug = currentSlug,
                    LayoutId = page.LayoutId,
                    LayoutName = page.Layout?.Name,
                    Sections = allSections
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get section by Key
        /// </summary>
        /// <param name="key">Section key</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Section data with all items</returns>
        [HttpGet("sections/{key}")]
        public async Task<ActionResult<SectionResponse>> GetSection(string key, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    return BadRequest("Section key is required.");
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get section with all related data by Key
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
                    .FirstOrDefaultAsync(s => s.Key == key && s.Status == Status.Active && !s.IsDeleted);

                if (section == null)
                {
                    return NotFound($"Section with key '{key}' not found.");
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
        /// <param name="id">Section item ID</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Section item data with all fields</returns>
        [HttpGet("section-items/{id}")]
        public async Task<ActionResult<SectionItemResponse>> GetSectionItem(int id, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get section item with all related data
                var sectionItem = await _pazarAtlasiDbContext.SectionItems
                    .Include(si => si.Translations.Where(sit => sit.LanguageId == language.Id))
                    .Include(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                        .ThenInclude(fv => fv.SectionItemField)
                        .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                    .Include(si => si.SectionItemFieldValues)
                        .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                    .FirstOrDefaultAsync(si => si.Id == id && si.Status == Status.Active && !si.IsDeleted);

                if (sectionItem == null)
                {
                    return NotFound($"Section item with ID '{id}' not found.");
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
        /// <param name="id">Section item field ID</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Section item field data</returns>
        [HttpGet("section-item-fields/{id}")]
        public async Task<ActionResult<SectionItemFieldResponse>> GetSectionItemField(int id, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
        .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get section item field value with all related data
                var fieldValue = await _pazarAtlasiDbContext.SectionItemFieldValues
                  .Include(fv => fv.SectionItemField)
             .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                  .Include(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                           .FirstOrDefaultAsync(fv => fv.Id == id && !fv.IsDeleted);

                if (fieldValue == null)
                {
                    return NotFound($"Section item field with ID '{id}' not found.");
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

        /// <summary>
        /// Get layout sections by layout ID
        /// </summary>
        /// <param name="layoutId">Layout ID</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Layout sections organized by position</returns>
        [HttpGet("layouts/{layoutId}/sections")]
        public async Task<ActionResult<LayoutSectionsResponse>> GetLayoutSections(int layoutId, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                 .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get layout with sections
                var layout = await _pazarAtlasiDbContext.Set<PazarAtlasi.CMS.Domain.Entities.Content.Layout>()
                    .Include(l => l.LayoutSections.OrderBy(ls => ls.SortOrder))
                           .ThenInclude(ls => ls.Section)
                            .ThenInclude(s => s.Translations.Where(st => st.LanguageId == language.Id))
                 .Include(l => l.LayoutSections)
                       .ThenInclude(ls => ls.Section)
                 .ThenInclude(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
                 .ThenInclude(siv => siv.SectionItem)
                       .ThenInclude(si => si.Translations.Where(sit => sit.LanguageId == language.Id))
                  .Include(l => l.LayoutSections)
                              .ThenInclude(ls => ls.Section)
                   .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                          .ThenInclude(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                         .ThenInclude(fv => fv.SectionItemField)
                       .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == language.Id))
                      .Include(l => l.LayoutSections)
                         .ThenInclude(ls => ls.Section)
                     .ThenInclude(s => s.SectionItemValues)
                          .ThenInclude(siv => siv.SectionItem)
                         .ThenInclude(si => si.SectionItemFieldValues)
                             .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == language.Id))
                        .FirstOrDefaultAsync(l => l.Id == layoutId && l.Status == Status.Active && !l.IsDeleted);

                if (layout == null)
                {
                    return NotFound($"Layout with ID '{layoutId}' not found.");
                }

                // Group sections by position
                var headerSections = new List<SectionResponse>();
                var contentSections = new List<SectionResponse>();
                var sidebarSections = new List<SectionResponse>();
                var footerSections = new List<SectionResponse>();

                foreach (var layoutSection in layout.LayoutSections.Where(ls => ls.Section.Status == Status.Active && !ls.Section.IsDeleted))
                {
                    var sectionResponse = await BuildLayoutSectionResponse(layoutSection, language.Id);

                    switch (layoutSection.Position.ToLower())
                    {
                        case "header":
                            headerSections.Add(sectionResponse);
                            break;
                        case "content":
                            contentSections.Add(sectionResponse);
                            break;
                        case "sidebar":
                            sidebarSections.Add(sectionResponse);
                            break;
                        case "footer":
                            footerSections.Add(sectionResponse);
                            break;
                    }
                }

                var response = new LayoutSectionsResponse
                {
                    LayoutId = layout.Id,
                    LayoutName = layout.Name,
                    HeaderSections = headerSections,
                    ContentSections = contentSections,
                    SidebarSections = sidebarSections,
                    FooterSections = footerSections
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #region Article Endpoints

        /// <summary>
        /// Get article by slug with full details
        /// </summary>
        /// <param name="slug">Article slug</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Complete article data with category and related articles</returns>
        [HttpGet("articles/{slug}")]
        public async Task<ActionResult<ArticleResponse>> GetArticle(string slug, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(slug))
                {
                    return BadRequest("Slug is required.");
                }

                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get article by slug with all related data
                var article = await _pazarAtlasiDbContext.Articles
                    .Include(a => a.Category)
                        .ThenInclude(c => c.Translations.Where(ct => ct.LanguageId == language.Id))
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .FirstOrDefaultAsync(a =>
                        a.Translations.Any(t => t.Slug.ToLower() == slug.ToLower() && t.LanguageId == language.Id) &&
                        a.Status == Status.Active &&
                        !a.IsDeleted);

                if (article == null)
                {
                    return NotFound($"Article with slug '{slug}' not found.");
                }

                // Increment view count
                article.ViewCount++;
                await _pazarAtlasiDbContext.SaveChangesAsync();

                var translation = article.Translations.FirstOrDefault();
                var categoryTranslation = article.Category?.Translations.FirstOrDefault();

                // Parse tags from JSON
                var tags = new List<string>();
                if (!string.IsNullOrEmpty(article.Tags))
                {
                    try
                    {
                        tags = JsonSerializer.Deserialize<List<string>>(article.Tags) ?? new List<string>();
                    }
                    catch { }
                }

                // Get related articles (same category, excluding current)
                var relatedArticles = await GetRelatedArticles(article.Id, article.CategoryId, language.Id, 4);

                var response = new ArticleResponse
                {
                    Id = article.Id,
                    Title = translation?.Title ?? string.Empty,
                    Slug = translation?.Slug ?? string.Empty,
                    Summary = translation?.Summary,
                    Content = translation?.Content,
                    FeaturedImage = article.FeaturedImage,
                    VideoUrl = article.VideoUrl,
                    PublishedAt = article.PublishedAt,
                    ViewCount = article.ViewCount,
                    LikeCount = article.LikeCount,
                    IsFeatured = article.IsFeatured,
                    IsTrending = article.IsTrending,
                    ReadingTime = article.ReadingTime,
                    Tags = tags,
                    Status = article.Status,
                    MetaTitle = translation?.MetaTitle,
                    MetaDescription = article.MetaDescription,
                    MetaKeywords = article.MetaKeywords,
                    Category = article.Category != null ? new ArticleCategoryResponse
                    {
                        Id = article.Category.Id,
                        Name = categoryTranslation?.Name ?? string.Empty,
                        Description = categoryTranslation?.Description,
                        Icon = article.Category.Icon,
                        Color = article.Category.Color,
                        ParentCategoryId = article.Category.ParentCategoryId
                    } : null,
                    RelatedArticles = relatedArticles,
                    CreatedAt = article.CreatedAt,
                    UpdatedAt = article.UpdatedAt
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get article list with filtering and pagination
        /// </summary>
        /// <param name="culture">Culture code</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="categoryId">Filter by category ID</param>
        /// <param name="isFeatured">Filter by featured</param>
        /// <param name="isTrending">Filter by trending</param>
        /// <param name="searchTerm">Search term</param>
        /// <param name="sortBy">Sort by (latest, popular, trending, oldest)</param>
        /// <returns>Paginated article list</returns>
        [HttpGet("articles")]
        public async Task<ActionResult<ArticleListResponse>> GetArticleList(
            [FromQuery] string culture = "tr-TR",
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 12,
            [FromQuery] int? categoryId = null,
            [FromQuery] bool? isFeatured = null,
            [FromQuery] bool? isTrending = null,
            [FromQuery] string? searchTerm = null,
            [FromQuery] string sortBy = "latest")
        {
            try
            {
                // Get language by culture
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Build query
                var articlesQuery = _pazarAtlasiDbContext.Articles
                    .Include(a => a.Category)
                        .ThenInclude(c => c.Translations.Where(ct => ct.LanguageId == language.Id))
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .Where(a => a.Status == Status.Active && !a.IsDeleted);

                // Apply filters
                if (categoryId.HasValue)
                {
                    articlesQuery = articlesQuery.Where(a => a.CategoryId == categoryId.Value);
                }

                if (isFeatured.HasValue)
                {
                    articlesQuery = articlesQuery.Where(a => a.IsFeatured == isFeatured.Value);
                }

                if (isTrending.HasValue)
                {
                    articlesQuery = articlesQuery.Where(a => a.IsTrending == isTrending.Value);
                }

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var search = searchTerm.ToLower();
                    articlesQuery = articlesQuery.Where(a =>
                        a.Translations.Any(t =>
                            t.Title.ToLower().Contains(search) ||
                            (t.Summary != null && t.Summary.ToLower().Contains(search)) ||
                            (t.Content != null && t.Content.ToLower().Contains(search))));
                }

                // Apply sorting
                articlesQuery = sortBy.ToLower() switch
                {
                    "popular" => articlesQuery.OrderByDescending(a => a.ViewCount),
                    "trending" => articlesQuery.OrderByDescending(a => a.IsTrending).ThenByDescending(a => a.ViewCount),
                    "oldest" => articlesQuery.OrderBy(a => a.PublishedAt ?? a.CreatedAt),
                    _ => articlesQuery.OrderByDescending(a => a.PublishedAt ?? a.CreatedAt) // latest (default)
                };

                // Get total count
                var totalCount = await articlesQuery.CountAsync();

                // Apply pagination
                var articles = await articlesQuery
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(a => new ArticleListItemResponse
                    {
                        Id = a.Id,
                        Title = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Title : string.Empty,
                        Slug = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Slug : string.Empty,
                        Summary = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Summary : null,
                        FeaturedImage = a.FeaturedImage,
                        PublishedAt = a.PublishedAt,
                        ViewCount = a.ViewCount,
                        LikeCount = a.LikeCount,
                        IsFeatured = a.IsFeatured,
                        IsTrending = a.IsTrending,
                        ReadingTime = a.ReadingTime,
                        CategoryId = a.CategoryId,
                        CategoryName = a.Category != null && a.Category.Translations.Any()
                            ? a.Category.Translations.FirstOrDefault()!.Name
                            : null,
                        CategoryColor = a.Category != null ? a.Category.Color : null,
                        CategoryIcon = a.Category != null ? a.Category.Icon : null
                    })
                    .ToListAsync();

                var response = new ArticleListResponse
                {
                    Articles = articles,
                    TotalCount = totalCount,
                    PageNumber = page,
                    PageSize = pageSize
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get featured articles
        /// </summary>
        /// <param name="culture">Culture code</param>
        /// <param name="count">Number of articles to return</param>
        /// <returns>List of featured articles</returns>
        [HttpGet("articles/featured")]
        public async Task<ActionResult<List<ArticleListItemResponse>>> GetFeaturedArticles(
            [FromQuery] string culture = "tr-TR",
            [FromQuery] int count = 5)
        {
            try
            {
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                var articles = await _pazarAtlasiDbContext.Articles
                    .Include(a => a.Category)
                        .ThenInclude(c => c.Translations.Where(ct => ct.LanguageId == language.Id))
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .Where(a => a.IsFeatured && a.Status == Status.Active && !a.IsDeleted)
                    .OrderByDescending(a => a.PublishedAt ?? a.CreatedAt)
                    .Take(count)
                    .Select(a => new ArticleListItemResponse
                    {
                        Id = a.Id,
                        Title = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Title : string.Empty,
                        Slug = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Slug : string.Empty,
                        Summary = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Summary : null,
                        FeaturedImage = a.FeaturedImage,
                        PublishedAt = a.PublishedAt,
                        ViewCount = a.ViewCount,
                        LikeCount = a.LikeCount,
                        IsFeatured = a.IsFeatured,
                        IsTrending = a.IsTrending,
                        ReadingTime = a.ReadingTime,
                        CategoryId = a.CategoryId,
                        CategoryName = a.Category != null && a.Category.Translations.Any()
                            ? a.Category.Translations.FirstOrDefault()!.Name
                            : null,
                        CategoryColor = a.Category != null ? a.Category.Color : null,
                        CategoryIcon = a.Category != null ? a.Category.Icon : null
                    })
                    .ToListAsync();

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get trending articles
        /// </summary>
        /// <param name="culture">Culture code</param>
        /// <param name="count">Number of articles to return</param>
        /// <returns>List of trending articles</returns>
        [HttpGet("articles/trending")]
        public async Task<ActionResult<List<ArticleListItemResponse>>> GetTrendingArticles(
            [FromQuery] string culture = "tr-TR",
            [FromQuery] int count = 5)
        {
            try
            {
                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                var articles = await _pazarAtlasiDbContext.Articles
                    .Include(a => a.Category)
                        .ThenInclude(c => c.Translations.Where(ct => ct.LanguageId == language.Id))
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .Where(a => a.IsTrending && a.Status == Status.Active && !a.IsDeleted)
                    .OrderByDescending(a => a.ViewCount)
                    .ThenByDescending(a => a.PublishedAt ?? a.CreatedAt)
                    .Take(count)
                    .Select(a => new ArticleListItemResponse
                    {
                        Id = a.Id,
                        Title = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Title : string.Empty,
                        Slug = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Slug : string.Empty,
                        Summary = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Summary : null,
                        FeaturedImage = a.FeaturedImage,
                        PublishedAt = a.PublishedAt,
                        ViewCount = a.ViewCount,
                        LikeCount = a.LikeCount,
                        IsFeatured = a.IsFeatured,
                        IsTrending = a.IsTrending,
                        ReadingTime = a.ReadingTime,
                        CategoryId = a.CategoryId,
                        CategoryName = a.Category != null && a.Category.Translations.Any()
                            ? a.Category.Translations.FirstOrDefault()!.Name
                            : null,
                        CategoryColor = a.Category != null ? a.Category.Color : null,
                        CategoryIcon = a.Category != null ? a.Category.Icon : null
                    })
                    .ToListAsync();

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get article categories with hierarchical structure
        /// </summary>
        /// <param name="query">Category query</param>
        /// <returns>List of categories with optional article counts</returns>
        [HttpGet("article-categories")]
        public async Task<ActionResult<ArticleCategoryListResponse>> GetArticleCategories([FromQuery] ArticleCategoryQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var language = await _pazarAtlasiDbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{query.Culture}' not found.");
                }

                var categoriesQuery = _pazarAtlasiDbContext.ArticleCategories
                    .Include(c => c.Translations.Where(t => t.LanguageId == language.Id))
                    .Where(c => c.Status == Status.Active && !c.IsDeleted);

                if (query.IncludeChildren)
                {
                    categoriesQuery = categoriesQuery.Include(c => c.ChildCategories
                        .Where(cc => cc.Status == Status.Active && !cc.IsDeleted))
                        .ThenInclude(cc => cc.Translations.Where(t => t.LanguageId == language.Id));
                }

                var categories = await categoriesQuery
                    .OrderBy(c => c.SortOrder)
                    .ToListAsync();

                var categoryResponses = new List<ArticleCategoryResponse>();

                foreach (var category in categories.Where(c => c.ParentCategoryId == null))
                {
                    var categoryResponse = await BuildArticleCategoryResponse(category, language.Id, query.IncludeArticleCount, query.IncludeChildren);
                    categoryResponses.Add(categoryResponse);
                }

                var response = new ArticleCategoryListResponse
                {
                    Categories = categoryResponses
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Like an article
        /// </summary>
        /// <param name="id">Article ID</param>
        /// <returns>Updated like count</returns>
        [HttpPost("article/{id}/like")]
        public async Task<ActionResult<int>> LikeArticle(int id)
        {
            try
            {
                var article = await _pazarAtlasiDbContext.Articles
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

                if (article == null)
                {
                    return NotFound($"Article with ID '{id}' not found.");
                }

                article.LikeCount++;
                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Ok(article.LikeCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Get related articles based on category
        /// </summary>
        private async Task<List<ArticleListItemResponse>> GetRelatedArticles(int currentArticleId, int? categoryId, int languageId, int count)
        {
            if (!categoryId.HasValue)
            {
                return new List<ArticleListItemResponse>();
            }

            var relatedArticles = await _pazarAtlasiDbContext.Articles
                .Include(a => a.Category)
                    .ThenInclude(c => c.Translations.Where(ct => ct.LanguageId == languageId))
                .Include(a => a.Translations.Where(t => t.LanguageId == languageId))
                .Where(a =>
                    a.CategoryId == categoryId &&
                    a.Id != currentArticleId &&
                    a.Status == Status.Active &&
                    !a.IsDeleted)
                .OrderByDescending(a => a.ViewCount)
                .Take(count)
                .Select(a => new ArticleListItemResponse
                {
                    Id = a.Id,
                    Title = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Title : string.Empty,
                    Slug = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Slug : string.Empty,
                    Summary = a.Translations.FirstOrDefault() != null ? a.Translations.FirstOrDefault()!.Summary : null,
                    FeaturedImage = a.FeaturedImage,
                    PublishedAt = a.PublishedAt,
                    ViewCount = a.ViewCount,
                    LikeCount = a.LikeCount,
                    IsFeatured = a.IsFeatured,
                    IsTrending = a.IsTrending,
                    ReadingTime = a.ReadingTime,
                    CategoryId = a.CategoryId,
                    CategoryName = a.Category != null && a.Category.Translations.Any()
                        ? a.Category.Translations.FirstOrDefault()!.Name
                        : null,
                    CategoryColor = a.Category != null ? a.Category.Color : null,
                    CategoryIcon = a.Category != null ? a.Category.Icon : null
                })
                .ToListAsync();

            return relatedArticles;
        }

        /// <summary>
        /// Build category response with children
        /// </summary>
        private async Task<ArticleCategoryResponse> BuildArticleCategoryResponse(
            PazarAtlasi.CMS.Domain.Entities.Content.ArticleCategory category,
            int languageId,
            bool includeArticleCount,
            bool includeChildren)
        {
            var translation = category.Translations.FirstOrDefault();

            var response = new ArticleCategoryResponse
            {
                Id = category.Id,
                Name = translation?.Name ?? string.Empty,
                Description = translation?.Description,
                Icon = category.Icon,
                Color = category.Color,
                ParentCategoryId = category.ParentCategoryId
            };

            if (includeArticleCount)
            {
                response.ArticleCount = await _pazarAtlasiDbContext.Articles
                    .CountAsync(a => a.CategoryId == category.Id && a.Status == Status.Active && !a.IsDeleted);
            }

            if (includeChildren && category.ChildCategories.Any())
            {
                foreach (var child in category.ChildCategories.OrderBy(c => c.SortOrder))
                {
                    var childResponse = await BuildArticleCategoryResponse(child, languageId, includeArticleCount, false);
                    response.ChildCategories.Add(childResponse);
                }
            }

            return response;
        }

        /// <summary>
        /// Build page sections with layout integration
        /// </summary>
        private async Task<List<SectionResponse>> BuildPageSectionsWithLayout(PazarAtlasi.CMS.Domain.Entities.Content.Page page, int languageId)
        {
            var allSections = new List<SectionResponse>();

            // If page has a layout, get layout sections
            if (page.LayoutId.HasValue)
            {
                var layoutSections = await _pazarAtlasiDbContext.Set<PazarAtlasi.CMS.Domain.Entities.Content.LayoutSection>()
                    .Include(ls => ls.Section)
                        .ThenInclude(s => s.Translations.Where(st => st.LanguageId == languageId))
                    .Include(ls => ls.Section)
                        .ThenInclude(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.Translations.Where(sit => sit.LanguageId == languageId))
                    .Include(ls => ls.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFieldValues.OrderBy(fv => fv.SectionItemField.SortOrder))
                                .ThenInclude(fv => fv.SectionItemField)
                                .ThenInclude(f => f.Translations.Where(ft => ft.LanguageId == languageId))
                    .Include(ls => ls.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFieldValues)
                                .ThenInclude(fv => fv.Translations.Where(fvt => fvt.LanguageId == languageId))
                    .Where(ls => ls.LayoutId == page.LayoutId.Value && ls.Section.Status == Status.Active && !ls.Section.IsDeleted)
                    .OrderBy(ls => ls.SortOrder)
                    .ToListAsync();

                // Group layout sections by position
                var headerSections = layoutSections.Where(ls => ls.Position.ToLower() == "header").ToList();
                var contentSections = layoutSections.Where(ls => ls.Position.ToLower() == "content").ToList();
                var sidebarSections = layoutSections.Where(ls => ls.Position.ToLower() == "sidebar").ToList();
                var footerSections = layoutSections.Where(ls => ls.Position.ToLower() == "footer").ToList();

                // Add header sections first
                foreach (var layoutSection in headerSections)
                {
                    var sectionResponse = await BuildLayoutSectionResponse(layoutSection, languageId);
                    allSections.Add(sectionResponse);
                }

                // Add layout content sections
                foreach (var layoutSection in contentSections)
                {
                    var sectionResponse = await BuildLayoutSectionResponse(layoutSection, languageId);
                    allSections.Add(sectionResponse);
                }

                // Add page-specific sections (these go in the content area)
                var pageSections = await BuildSectionsResponse(page.PageSections.Select(ps => ps.Section).ToList(), languageId);
                allSections.AddRange(pageSections);

                // Add sidebar sections
                foreach (var layoutSection in sidebarSections)
                {
                    var sectionResponse = await BuildLayoutSectionResponse(layoutSection, languageId);
                    allSections.Add(sectionResponse);
                }

                // Add footer sections last
                foreach (var layoutSection in footerSections)
                {
                    var sectionResponse = await BuildLayoutSectionResponse(layoutSection, languageId);
                    allSections.Add(sectionResponse);
                }
            }
            else
            {
                // No layout, just return page sections
                allSections = await BuildSectionsResponse(page.PageSections.Select(ps => ps.Section).ToList(), languageId);
            }

            return allSections;
        }

        /// <summary>
        /// Build layout section response
        /// </summary>
        private async Task<SectionResponse> BuildLayoutSectionResponse(PazarAtlasi.CMS.Domain.Entities.Content.LayoutSection layoutSection, int languageId)
        {
            var section = layoutSection.Section;
            var sectionTranslation = section.Translations.FirstOrDefault();

            var sectionResponse = new SectionResponse
            {
                Id = section.Id,
                Type = section.Type,
                Key = section.Key,
                Attributes = section.Attributes,
                Configure = section.Configure,
                SortOrder = layoutSection.SortOrder, // Use layout sort order
                Status = section.Status,
                Name = sectionTranslation?.Name,
                Title = sectionTranslation?.Title,
                Description = sectionTranslation?.Description,
                Position = layoutSection.Position, // Add position information
                IsLayoutSection = true, // Mark as layout section
                IsRequired = layoutSection.IsRequired,
                Items = await BuildSectionItemsResponse(section.SectionItemValues.ToList(), languageId)
            };

            return sectionResponse;
        }

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
                        .Include(p => p.Content)
                            .ThenInclude(c => c.ContentSlugs.Where(cs => cs.LanguageId == languageId))
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

                // Get slug for this page and language
                var pageSlug = hierarchyPage.Content?.ContentSlugs?.FirstOrDefault(cs => cs.LanguageId == languageId)?.Slug ?? string.Empty;

                breadcrumbs.Add(new BreadcrumbItem
                {
                    Name = hierarchyPage.Name ?? string.Empty,
                    Href = pageSlug,
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
                    Position = "content", // Page sections are always in content area
                    IsLayoutSection = false, // Page-specific sections
                    IsRequired = false,
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
    }
}
