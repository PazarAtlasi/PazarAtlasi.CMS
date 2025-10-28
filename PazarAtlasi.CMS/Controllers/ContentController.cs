using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Models.ViewModels;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PazarAtlasi.CMS.Controllers
{
    public class ContentController : Controller
    {
        private readonly PazarAtlasiDbContext _pazarAtlasiDbContext;
        private readonly IMediaUploadService _mediaUploadService;

        public ContentController(
            PazarAtlasiDbContext pazarAtlasiDbContext,
            IMediaUploadService mediaUploadService)
        {
            _pazarAtlasiDbContext = pazarAtlasiDbContext;
            _mediaUploadService = mediaUploadService;
        }

        /// <summary>
        /// Main view for menu management
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Pages list with hierarchical structure
        /// </summary>
        public async Task<IActionResult> Pages(int page = 1, int pageSize = 50) // Increased page size for hierarchy
        {
            // Get all pages with parent information for hierarchy building
            var allPages = await _pazarAtlasiDbContext.Pages
                .Include(p => p.ParentPage)
                .OrderBy(p => p.ParentPageId ?? 0) // Root pages first
                .ThenBy(p => p.Name)
                .Select(p => new PageListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    PageType = p.PageType,
                    Description = p.Description,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ParentPageId = p.ParentPageId,
                    ParentPageName = p.ParentPage != null ? p.ParentPage.Name : null
                })
                .ToListAsync();

            // Build hierarchical structure
            var hierarchicalPages = BuildPageHierarchy(allPages);

            // Flatten for display with proper levels
            var flattenedPages = new List<PageListViewModel>();
            FlattenPageHierarchy(hierarchicalPages, flattenedPages, 0);

            // Apply pagination to flattened list
            var totalCount = flattenedPages.Count;
            var paginatedPages = flattenedPages
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new PageListResponse
            {
                Pages = paginatedPages,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Page details with all related data
        /// </summary>
        public async Task<IActionResult> PageDetails(int id)
        {
            var page = await _pazarAtlasiDbContext.Pages
                .Include(p => p.PageSEOParameter)
                .Include(p => p.PageSections.OrderBy(s => s.SortOrder))
                    .ThenInclude(ps => ps.Section)
                    .ThenInclude(s => s.SectionItemValues)
                        .ThenInclude(siv => siv.SectionItem)
                        .ThenInclude(si => si.SectionItemFields)
                        .ThenInclude(f => f.Translations)
                .Include(p => p.PageSections)
                    .ThenInclude(ps => ps.Section)
                    .ThenInclude(s => s.SectionItemValues)
                        .ThenInclude(siv => siv.SectionItem)
                        .ThenInclude(si => si.SectionItemFieldValues)
                        .ThenInclude(fv => fv.Translations)
                .Include(p => p.PageSections)
                    .ThenInclude(ps => ps.Section)
                    .ThenInclude(s => s.SectionItemValues)
                        .ThenInclude(siv => siv.SectionItem)
                        .ThenInclude(si => si.Translations)
                .Include(p => p.PageTranslations)
                    .ThenInclude(pt => pt.Language)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (page == null)
            {
                return NotFound();
            }

            var model = new PageDetailsViewModel
            {
                Id = page.Id,
                Name = page.Name,
                Code = page.Code,
                PageType = page.PageType,
                Description = page.Description,
                Status = page.Status,
                CreatedAt = page.CreatedAt,
                UpdatedAt = page.UpdatedAt,
                SEOParameter = page.PageSEOParameter != null ? new PageSEOParameterViewModel
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
                Sections = page.PageSections.Select(ps => ps.Section).Select(s => new SectionViewModel
                {
                    Id = s.Id,
                    Type = s.Type,
                    Key = s.Key,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = s.SectionItemValues
                        .Select(siv => new SectionItemViewModel
                        {
                            Id = siv.SectionItem.Id,
                            Type = siv.SectionItem.Type,
                            SortOrder = siv.SectionItem.SortOrder,
                            Status = siv.SectionItem.Status,
                            Title = siv.SectionItem.Title,
                            Description = siv.SectionItem.Description,
                            AllowReorder = siv.SectionItem.AllowReorder,
                            AllowRemove = siv.SectionItem.AllowRemove,
                            IconClass = siv.SectionItem.IconClass,
                            Fields = siv.SectionItem.SectionItemFieldValues.Select(fv => new SectionItemFieldViewModel
                            {
                                Id = fv.Id,
                                SectionItemId = fv.SectionItemId,
                                FieldType = fv.SectionItemField?.Type ?? SectionItemFieldType.Text,
                                FieldKey = fv.SectionItemField?.FieldKey ?? "",
                                FieldValue = fv.Value,
                                IsTranslatable = fv.SectionItemField?.IsTranslatable ?? false,
                                ShowInUI = fv.SectionItemField?.ShowInUI ?? true,
                                Translations = fv.Translations?.Select(ft => new SectionItemFieldTranslationViewModel
                                {
                                    Id = ft.Id,
                                    SectionItemFieldId = ft.SectionItemFieldValueId,
                                    LanguageId = ft.LanguageId,
                                    LanguageCode = ft.Language?.Code ?? "",
                                    LanguageName = ft.Language?.Name ?? "",
                                    Label = ft.Value,
                                    Description = ft.Value,
                                    Placeholder = ft.Value
                                }).ToList() ?? new List<SectionItemFieldTranslationViewModel>(),
                            }).ToList(),
                            Translations = siv.SectionItem.Translations.Select(sit => new SectionItemTranslationViewModel
                            {
                                Id = sit.Id,
                                LanguageId = sit.LanguageId,
                                Name = sit.Title,
                                Title = sit.Title,
                                Description = sit.Description
                            }).ToList()
                        }).ToList(),
                    Translations = s.Translations.Select(st => new SectionTranslationViewModel
                    {
                        Id = st.Id,
                        LanguageId = st.LanguageId,
                        Name = st.Name,
                        Title = st.Title,
                        Description = st.Description
                    }).ToList()
                }).ToList(),
                Translations = page.PageTranslations.Select(pt => new PageTranslationViewModel
                {
                    Id = pt.Id,
                    LanguageId = pt.LanguageId,
                    LanguageName = pt.Language.Name,
                    LanguageCode = pt.Language.Code,
                    Value = pt.Value
                }).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// Page edit form - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> PageEdit(int id)
        {
            try
            {
                // Önce sadece temel page bilgilerini yükle
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.PageSEOParameter)
                    .Include(p => p.PageTranslations)
                        .ThenInclude(pt => pt.Language)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (page != null)
                {
                    // Sections'ları ayrı query ile yükle
                    await _pazarAtlasiDbContext.Entry(page)
                        .Collection(p => p.PageSections)
                        .Query()
                        .Include(s => s.Section)
                        .ThenInclude(s => s.Translations)
                        .OrderBy(s => s.SortOrder)
                        .LoadAsync();

                    // Tüm section item value'larını tek query ile yükle (daha performanslı)
                    if (page.PageSections.Select(ps => ps.Section).Any())
                    {
                        var sectionIds = page.PageSections.Select(ps => ps.Section).Select(s => s.Id).ToList();
                        var allSectionItemValues = await _pazarAtlasiDbContext.SectionItemValues
                            .Include(siv => siv.SectionItem)
                                .ThenInclude(si => si.Translations)
                            .Include(siv => siv.SectionItem)
                                .ThenInclude(si => si.SectionItemFieldValues)
                                .ThenInclude(fv => fv.SectionItemField)
                                .ThenInclude(f => f.Translations)
                            .Include(siv => siv.SectionItem)
                                .ThenInclude(si => si.SectionItemFieldValues)
                                .ThenInclude(fv => fv.Translations)
                            .Where(siv => sectionIds.Contains(siv.SectionId) && !siv.IsDeleted)
                            .OrderBy(siv => siv.SectionItem.SortOrder)
                            .ToListAsync();

                        // Section item value'larını ilgili section'lara dağıt
                        foreach (var section in page.PageSections.Select(ps => ps.Section))
                        {
                            section.SectionItemValues = allSectionItemValues
                                .Where(siv => siv.SectionId == section.Id)
                                .ToList();
                        }
                    }
                }

                if (page == null)
                {
                    TempData["ErrorMessage"] = "Page not found.";
                    return RedirectToAction("Pages");
                }

                // Get available languages
                var languages = await _pazarAtlasiDbContext.Languages
                    .Where(l => !l.IsDeleted)
                    .Select(l => new LanguageViewModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Code = l.Code,
                        IsDefault = l.IsDefault
                    })
                    .ToListAsync();

                var model = await MapToPageEditViewModel(page, languages);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading the page.";
                return RedirectToAction("Pages");
            }
        }

        /// <summary>
        /// Page edit form - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PageEdit(PageEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Reload languages for dropdown
                model.AvailableLanguages = await GetAvailableLanguagesAsync();
                return View(model);
            }

            try
            {
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.PageSEOParameter)
                    .Include(p => p.PageSections)
                        .ThenInclude(ps => ps.Section)
                        .ThenInclude(s => s.SectionItemValues)
                            .ThenInclude(siv => siv.SectionItem)
                            .ThenInclude(si => si.Translations)
                    .Include(p => p.PageTranslations)
                    .FirstOrDefaultAsync(p => p.Id == model.Id);

                if (page == null)
                {
                    TempData["ErrorMessage"] = "Page not found.";
                    return RedirectToAction("Pages");
                }

                // Update page properties
                page.Name = model.Name;
                page.Code = model.Code;
                page.PageType = model.PageType;
                page.Description = model.Description;
                page.Status = model.Status;
                page.ParentPageId = model.ParentPageId;
                page.UpdatedAt = DateTime.UtcNow;

                // Update SEO parameters
                if (model.SEOParameter != null)
                {
                    if (page.PageSEOParameter == null)
                    {
                        page.PageSEOParameter = new PageSEOParameter
                        {
                            Id = 0,
                            PageId = page.Id
                        };
                        _pazarAtlasiDbContext.PageSEOParameters.Add(page.PageSEOParameter);
                    }

                    page.PageSEOParameter.MetaTitle = model.SEOParameter.MetaTitle;
                    page.PageSEOParameter.MetaDescription = model.SEOParameter.MetaDescription;
                    page.PageSEOParameter.MetaKeywords = model.SEOParameter.MetaKeywords;
                    page.PageSEOParameter.Title = model.SEOParameter.Title;
                    page.PageSEOParameter.CanonicalURL = model.SEOParameter.CanonicalURL;
                    page.PageSEOParameter.Author = model.SEOParameter.Author;
                    page.PageSEOParameter.Description = model.SEOParameter.Description;
                }

                await _pazarAtlasiDbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Page updated successfully.";
                return RedirectToAction("PageDetails", new { id = model.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the page.");
                model.AvailableLanguages = await GetAvailableLanguagesAsync();
                return View(model);
            }
        }

        /// <summary>
        /// Save page as draft
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveDraft(int id, [FromBody] PageEditViewModel model)
        {
            try
            {
                var page = await _pazarAtlasiDbContext.Pages.FindAsync(id);
                if (page == null)
                {
                    return Json(new { success = false, message = "Page not found." });
                }

                page.Status = Domain.Common.Status.Draft;
                page.UpdatedAt = DateTime.UtcNow;

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Page saved as draft." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while saving draft." });
            }
        }

        /// <summary>
        /// Publish page
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PublishPage(int id)
        {
            try
            {
                var page = await _pazarAtlasiDbContext.Pages.FindAsync(id);
                if (page == null)
                {
                    return Json(new { success = false, message = "Page not found." });
                }

                page.Status = Domain.Common.Status.Active;
                page.UpdatedAt = DateTime.UtcNow;

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Page published successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while publishing page." });
            }
        }

        /// <summary>
        /// Remove section from page
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RemoveSection(int sectionId)
        {
            try
            {
                var section = await _pazarAtlasiDbContext.Sections
                    .Include(s => s.SectionItemFieldValues)
                        .ThenInclude(fv => fv.SectionItem)
                        .ThenInclude(si => si.Translations)
                    .Include(s => s.Translations)
                    .FirstOrDefaultAsync(s => s.Id == sectionId);

                if (section == null)
                {
                    return Json(new { success = false, message = "Section not found." });
                }

                // Remove related data
                var sectionItemFieldValueTranslations = section.SectionItemFieldValues
                    .SelectMany(fv => fv.Translations);
                _pazarAtlasiDbContext.SectionItemFieldValueTranslations.RemoveRange(sectionItemFieldValueTranslations);

                var sectionItemTranslations = section.SectionItemFieldValues
                    .Select(fv => fv.SectionItem)
                    .SelectMany(si => si.Translations);
                _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(sectionItemTranslations);

                _pazarAtlasiDbContext.SectionItemFieldValues.RemoveRange(section.SectionItemFieldValues);
                _pazarAtlasiDbContext.SectionTranslations.RemoveRange(section.Translations);
                _pazarAtlasiDbContext.Sections.Remove(section);

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Section removed successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while removing section." });
            }
        }

        /// <summary>
        /// Get templates partial view
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetTemplatesPartial(int sectionType)
        {
            try
            {
                var templates = await _pazarAtlasiDbContext.Templates
                    .Where(t => t.IsActive && !t.IsDeleted)
                    .OrderBy(t => t.SortOrder)
                    .ToListAsync();

                return PartialView("~/Views/Shared/Content/_TemplatesGridPartial.cshtml", templates);
            }
            catch (Exception ex)
            {
                return Content("<div class='text-red-500'>Error loading templates</div>");
            }
        }

        [HttpGet]
        public IActionResult WebUrl()
        {
            return View();
        }

        #region Section Item Management

        /// <summary>
        /// Create or update section item
        /// </summary>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SaveSectionItem([FromForm] SectionItemRequest request)
        {
            try
            {
                if (request.Id > 0)
                {
                    // Update existing item
                    var sectionItem = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                        .FirstOrDefaultAsync(si => si.Id == request.Id && !si.IsDeleted);

                    if (sectionItem == null)
                    {
                        return Json(new { success = false, message = "Section item not found." });
                    }

                    // Update section item properties
                    sectionItem.Type = request.Type;
                    sectionItem.MediaType = request.MediaType;
                    sectionItem.SortOrder = request.SortOrder;
                    sectionItem.Status = request.Status;
                    sectionItem.UpdatedAt = DateTime.UtcNow;

                    // Update translations
                    if (request.Translations != null)
                    {
                        // Remove existing translations
                        _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(sectionItem.Translations);

                        // Add new translations
                        var newTranslations = request.Translations.Select(t => new SectionItemTranslation
                        {
                            Id = 0,
                            SectionItemId = sectionItem.Id,
                            LanguageId = t.LanguageId,
                            Title = t.Title,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                        _pazarAtlasiDbContext.SectionItemTranslations.AddRange(newTranslations);
                    }

                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    return Json(new { success = true, message = "Section item updated successfully.", data = new SectionItemSaveResponseDto { Id = sectionItem.Id, Message = "Updated successfully" } });
                }
                else
                {
                    // Create new item
                    // Check if section exists
                    var sectionExists = await _pazarAtlasiDbContext.Sections.AnyAsync(s => s.Id == request.SectionId);
                    if (!sectionExists)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    // Add translations
                    if (request.Translations != null && request.Translations.Any())
                    {
                        var translations = request.Translations.Select(t => new SectionItemTranslation
                        {
                            Id = 0,
                            SectionItemId = t.SectionItemId,
                            LanguageId = t.LanguageId,
                            Title = t.Title,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                        _pazarAtlasiDbContext.SectionItemTranslations.AddRange(translations);
                        await _pazarAtlasiDbContext.SaveChangesAsync();
                    }

                    return Json(new { success = true, message = "Section item created successfully.", data = new SectionItemSaveResponseDto { Id = 1, Message = "Created successfully" } });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message, error = ex.ToString() });
            }
        }

        #endregion

        #region Media Upload

        /// <summary>
        /// Upload image file
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, string? folder = null)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "No file provided." });
                }

                var result = await _mediaUploadService.UploadImageAsync(file, folder);

                return Json(new
                {
                    success = result.Success,
                    message = result.Message,
                    url = result.Url,
                    fileName = result.FileName,
                    errors = result.Errors
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Upload video file
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UploadVideo(IFormFile file, string? folder = null)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "No file provided." });
                }

                var result = await _mediaUploadService.UploadVideoAsync(file, folder);

                return Json(new
                {
                    success = result.Success,
                    message = result.Message,
                    url = result.Url,
                    fileName = result.FileName,
                    errors = result.Errors
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Delete media file
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteMedia(string url)
        {
            try
            {
                var result = await _mediaUploadService.DeleteMediaAsync(url);

                return Json(new
                {
                    success = result,
                    message = result ? "Media deleted successfully." : "Media not found or could not be deleted."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        #endregion

        #region Section Management

        /// <summary>
        /// Get section modal for editing/creating with items
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSectionModal(int id, int pageId = 0)
        {
            try
            {
                SectionViewModel model;

                if (id > 0)
                {
                    Section section;

                    if (pageId > 0)
                    {
                        // Load section from PageSection (for page-specific sections)
                        var pageSection = await _pazarAtlasiDbContext.PageSections
                            .Include(ps => ps.Section)
                                .ThenInclude(s => s.Translations)
                                .ThenInclude(t => t.Language)
                            .FirstOrDefaultAsync(ps => ps.SectionId == id && ps.PageId == pageId);

                        section = pageSection?.Section;
                    }
                    else
                    {
                        // Load section directly (for standalone/reusable sections)
                        section = await _pazarAtlasiDbContext.Sections
                            .Include(s => s.Translations)
                                .ThenInclude(t => t.Language)
                            .FirstOrDefaultAsync(s => s.Id == id);
                    }

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    // Get SectionItemValues for this section (only root items)
                    var sectionItemValues = await _pazarAtlasiDbContext.SectionItemValues
                        .Include(siv => siv.SectionItem)
                            .ThenInclude(si => si.SectionItemFields)
                            .ThenInclude(f => f.Translations)
                        .Include(siv => siv.SectionItem)
                            .ThenInclude(si => si.Translations)
                            .ThenInclude(t => t.Language)
                        .Where(siv => siv.SectionId == section.Id && !siv.IsDeleted)
                        .OrderBy(siv => siv.SectionItem.SortOrder)
                        .ToListAsync();

                    // Get all child section items recursively
                    var rootSectionItemIds = sectionItemValues.Select(siv => siv.SectionItemId).ToList();
                    var allSectionItems = await GetAllChildSectionItemsRecursively(rootSectionItemIds);

                    // Get all field IDs from all section items (root + children)
                    var fieldIds = allSectionItems
                        .SelectMany(si => si.SectionItemFields)
                        .Select(f => f.Id)
                        .ToList();

                    // Get all SectionItemFieldValues for these fields
                    var fieldValues = await _pazarAtlasiDbContext.SectionItemFieldValues
                        .Include(fv => fv.SectionItemField)
                        .Include(fv => fv.Translations)
                            .ThenInclude(t => t.Language)
                        .Where(fv => fieldIds.Contains(fv.SectionItemFieldId) && fv.SectionId == section.Id && !fv.IsDeleted)
                        .ToListAsync();

                    // Build nested structure and map to view models
                    var sectionItems = BuildNestedSectionItemViewModelsOptimized(sectionItemValues, allSectionItems, fieldValues);

                    model = new SectionViewModel
                    {
                        Id = section.Id,
                        PageId = pageId,
                        Type = section.Type,
                        Key = section.Key,
                        Attributes = section.Attributes,
                        SortOrder = section.SortOrder,
                        Configure = section.Configure,
                        Status = section.Status,
                        SectionItems = sectionItems,
                        Translations = section.Translations.Select(st => new SectionTranslationViewModel
                        {
                            Id = st.Id,
                            LanguageId = st.LanguageId,
                            LanguageName = st.Language.Name,
                            LanguageCode = st.Language.Code,
                            Name = st.Name,
                            Title = st.Title,
                            Description = st.Description
                        }).ToList()
                    };
                }
                else
                {
                    model = new SectionViewModel
                    {
                        Id = 0,
                        PageId = pageId,
                        Type = SectionType.None,
                        Key = "",
                        SortOrder = 1,
                        Status = Domain.Common.Status.Active
                    };
                }

                // Get available languages
                model.AvailableLanguages = await _pazarAtlasiDbContext.Languages
                    .Where(l => !l.IsDeleted)
                    .Select(l => new LanguageViewModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Code = l.Code,
                        IsDefault = l.IsDefault
                    })
                    .ToListAsync();

                return PartialView("~/Views/Content/_SectionModal.cshtml", model);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Get available templates by section type
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetTemplatesBySectionType(int sectionType)
        {
            try
            {
                var templates = await _pazarAtlasiDbContext.SectionTypeTemplates
                    .Where(st => (int)st.SectionType == sectionType && !st.IsDeleted && st.Template.IsActive && !st.Template.IsDeleted)
                    .Include(st => st.Template)
                    .OrderBy(st => st.Template.SortOrder)
                    .Select(st => new
                    {
                        id = st.Template.Id,  // Template ID, not SectionTypeTemplate ID
                        name = st.Template.Translations.Any() ? st.Template.Translations.First().Name : "No Name",
                        key = st.Template.TemplateKey
                    })
                    .ToListAsync();

                return Json(new { success = true, templates });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error loading templates." });
            }
        }


        /// <summary>
        /// Get a single new section item card as HTML (for adding items individually with different templates)
        /// NOW READS FROM DATABASE using TemplateConfigurationProvider
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetNewSectionItemCard(int templateId, int sectionId = 0, int currentCount = 0)
        {
            try
            {
                // Get template from database
                var template = await _pazarAtlasiDbContext.Templates
                    .FirstOrDefaultAsync(t => t.Id == templateId && t.IsActive && !t.IsDeleted);

                if (template == null)
                {
                    return Content("<div class='bg-red-50 border border-red-200 rounded-lg p-4'><p class='text-red-600'>Template not found.</p></div>", "text/html");
                }

                var availableLanguages = await _pazarAtlasiDbContext.Languages
                    .Where(l => !l.IsDeleted)
                    .Select(l => new LanguageViewModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Code = l.Code,
                        IsDefault = l.IsDefault
                    })
                    .ToListAsync();

                ViewBag.AvailableLanguages = availableLanguages;

                // Get SectionItemViewModel directly from TemplateConfigurationProvider (no more mapping needed!)
                var sectionItemViewModel = await GetConfigurationAsync(template.Id, template.TemplateKey, availableLanguages);
                if (sectionItemViewModel == null)
                {
                    return Content("<div class='bg-red-50 border border-red-200 rounded-lg p-4'><p class='text-red-600'>Template configuration not found.</p></div>", "text/html");
                }

                // Set section-specific properties
                sectionItemViewModel.SectionId = sectionId;
                sectionItemViewModel.SortOrder = currentCount + 1;



                return PartialView("~/Views/Content/_SectionItemCard.cshtml", sectionItemViewModel);
            }
            catch (Exception ex)
            {
                return Content($"<div class='bg-red-50 border border-red-200 rounded-lg p-4'><p class='text-red-600'>Error: {ex.Message}</p></div>", "text/html");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAvailablePages()
        {
            try
            {
                var pages = await _pazarAtlasiDbContext.Pages
                    .Where(p => p.Status == Status.Active)
                    .Select(p => new AvailablePageDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Slug = p.Slug
                    })
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                return Json(new { success = true, pages = pages });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetContentByType(PageType pageType)
        {
            try
            {
                var content = new List<ContentItemDto>();

                switch (pageType)
                {
                    case PageType.Blog:
                        // For now, return existing pages of blog type as placeholder
                        // In a real implementation, you would query your blog/article entities
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Blog && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Product:
                        // Placeholder for product content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Product && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Article:
                        // Placeholder for article content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Article && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Category:
                        // Placeholder for category content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Category && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Brand:
                        // Placeholder for brand content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Brand && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Tag:
                        // Placeholder for tag content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Tag && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Catalog:
                        // Placeholder for catalog content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Catalog && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    case PageType.Document:
                        // Placeholder for document content
                        content = await _pazarAtlasiDbContext.Pages
                            .Where(p => p.PageType == PageType.Document && p.Status == Status.Active)
                            .Select(p => new ContentItemDto { Id = p.Id, Name = p.Name, Title = p.Name })
                            .ToListAsync();
                        break;

                    default:
                        // For other types, return empty list
                        break;
                }

                return Json(new { success = true, content = content });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        #endregion

        #region Sections Management

        /// <summary>
        /// Sections list with pagination
        /// </summary>
        public async Task<IActionResult> Sections(int page = 1, int pageSize = 10)
        {
            var relatedPage = await _pazarAtlasiDbContext.Pages
                .Where(p => p.Id == page && p.Status == Status.Active)
                .FirstOrDefaultAsync();

            var totalCount = await _pazarAtlasiDbContext.Sections.CountAsync();

            var sections = await _pazarAtlasiDbContext.Sections
                .Include(s => s.SectionItemValues)
                    .ThenInclude(siv => siv.SectionItem)
                .Include(s => s.Translations)
                .OrderByDescending(s => s.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new SectionListViewModel
                {
                    Id = s.Id,
                    Name = s.Translations.FirstOrDefault() != null ? s.Translations.FirstOrDefault()!.Title : $"Section {s.Id}",
                    Type = s.Type,
                    Status = s.Status,
                    ItemsCount = s.SectionItemValues.Count(),
                    PageName = relatedPage != null ? relatedPage.Name : null,
                    PageId = page,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                })
                .ToListAsync();

            var model = new SectionListResponse
            {
                Sections = sections,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Section details with all related data
        /// </summary>
        public async Task<IActionResult> SectionDetails(int id)
        {
            var section = await _pazarAtlasiDbContext.Sections
                .Include(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
                    .ThenInclude(siv => siv.SectionItem)
                    .ThenInclude(si => si.Translations)
                .Include(s => s.Translations)
                    .ThenInclude(st => st.Language)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (section == null)
            {
                return NotFound();
            }

            // Get pages where this section is used (for reusable sections)
            var usedInPages = new List<PageUsageViewModel>();

            var model = new SectionDetailsViewModel
            {
                Id = section.Id,
                Name = section.Translations.FirstOrDefault()?.Title ?? $"Section {section.Id}",
                Description = section.Translations.FirstOrDefault()?.Description,
                Type = section.Type,
                Status = section.Status,
                SortOrder = section.SortOrder,
                Attributes = section.Attributes,
                Configure = section.Configure,
                CreatedAt = section.CreatedAt,
                UpdatedAt = section.UpdatedAt,
                SectionItems = section.SectionItemValues
                    .Select(siv => new SectionItemDetailsViewModel
                    {
                        Id = siv.SectionItem.Id,
                        Type = siv.SectionItem.Type,
                        MediaType = siv.SectionItem.MediaType,
                        SortOrder = siv.SectionItem.SortOrder,
                        Title = siv.SectionItem.Translations.FirstOrDefault()?.Title,
                        Description = siv.SectionItem.Translations.FirstOrDefault()?.Description
                    }).ToList(),
                Translations = section.Translations.Select(st => new SectionTranslationViewModel
                {
                    Id = st.Id,
                    LanguageId = st.LanguageId,
                    LanguageCode = st.Language?.Code,
                    LanguageName = st.Language?.Name,
                    Name = st.Name,
                    Title = st.Title,
                    Description = st.Description
                }).ToList(),
                UsedInPages = usedInPages
            };

            return View(model);
        }

        /// <summary>
        /// Create a new reusable section
        /// </summary>
        [HttpGet]
        public IActionResult CreateSection()
        {
            var model = new SectionDetailsViewModel
            {
                Status = Status.Draft,
                IsReusable = true,
                Type = SectionType.ContentBlock,
            };

            return View(model);
        }

        /// <summary>
        /// Save section with items and nested items
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveSectionAjax([FromBody] SectionRequest request)
        {
            try
            {
                // Handle case where PageId is null or 0 (for reusable sections)
                bool isReusableSection = request.PageId == null || request.PageId == 0;

                if (request.Id > 0)
                {
                    // Update existing section
                    var section = await _pazarAtlasiDbContext.Sections
                        .Include(s => s.SectionItemFieldValues)
                            .ThenInclude(fv => fv.SectionItem)
                            .ThenInclude(si => si.Translations)
                        .Include(s => s.SectionItemFieldValues)
                            .ThenInclude(fv => fv.SectionItemField)
                        .Include(s => s.SectionItemFieldValues)
                            .ThenInclude(fv => fv.Translations)
                        .Include(s => s.Translations)
                        .FirstOrDefaultAsync(s => s.Id == request.Id);

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    // Update section properties
                    section.Type = request.Type;
                    section.Key = request.Key;
                    section.Attributes = request.Attributes;
                    section.Configure = request.Configure;
                    section.Status = request.Status;
                    section.UpdatedAt = DateTime.UtcNow;

                    // Remove existing field values and their translations
                    foreach (var existingFieldValue in section.SectionItemFieldValues.ToList())
                    {
                        // Remove field value translations
                        _pazarAtlasiDbContext.SectionItemFieldValueTranslations.RemoveRange(existingFieldValue.Translations);
                        _pazarAtlasiDbContext.SectionItemFieldValues.Remove(existingFieldValue);
                    }

                    // Remove existing section item translations
                    var existingSectionItems = section.SectionItemFieldValues.Select(fv => fv.SectionItem).Distinct().ToList();
                    foreach (var existingItem in existingSectionItems)
                    {
                        _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(existingItem.Translations);
                    }

                    // Add new items
                    await ProcessSectionItems(request.SectionItems, section.Id);

                    // Save SectionItemValues for parent section items
                    await SaveSectionItemValues(request.SectionItems, section.Id);

                    // Update section translations
                    if (request.Translations != null)
                    {
                        // Remove existing translations
                        _pazarAtlasiDbContext.SectionTranslations.RemoveRange(section.Translations);

                        // Add new translations
                        var newTranslations = request.Translations.Select(t => new SectionTranslation
                        {
                            SectionId = section.Id,
                            LanguageId = t.LanguageId,
                            Name = t.Name,
                            Title = t.Title,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                        _pazarAtlasiDbContext.SectionTranslations.AddRange(newTranslations);
                    }

                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    return Json(new { success = true, message = "Section updated successfully.", sectionId = section.Id });
                }
                else
                {
                    // Create new section
                    var newSection = new Section
                    {
                        Type = request.Type,
                        Key = request.Key,
                        Attributes = request.Attributes ?? "{}",
                        SortOrder = request.SortOrder,
                        Configure = request.Configure ?? "{}",
                        Status = request.Status,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    };

                    _pazarAtlasiDbContext.Sections.Add(newSection);
                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Only add to PageSection if PageId is provided (not for reusable sections)
                    if (!isReusableSection)
                    {
                        _pazarAtlasiDbContext.PageSections.Add(new PageSection
                        {
                            PageId = request.PageId.Value,
                            SectionId = newSection.Id,
                            SortOrder = request.SortOrder,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        });

                        await _pazarAtlasiDbContext.SaveChangesAsync();
                    }

                    // Add section translations
                    if (request.Translations != null)
                    {
                        var newTranslations = request.Translations.Select(t => new SectionTranslation
                        {
                            SectionId = newSection.Id,
                            LanguageId = t.LanguageId,
                            Name = t.Name,
                            Title = t.Title,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                        _pazarAtlasiDbContext.SectionTranslations.AddRange(newTranslations);
                    }

                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Add section items
                    await ProcessSectionItems(request.SectionItems, newSection.Id);

                    // Save SectionItemValues for parent section items
                    await SaveSectionItemValues(request.SectionItems, newSection.Id);

                    string successMessage = isReusableSection
                        ? "Reusable section created successfully."
                        : "Section created successfully.";

                    return Json(new { success = true, message = successMessage, sectionId = newSection.Id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaveSectionAjax: {ex}");
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Save a new or existing section
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSection(SectionDetailsViewModel model)
        {
            try
            {
                Domain.Entities.Content.Section section;

                if (model.Id == 0)
                {
                    // Create new section
                    section = new Domain.Entities.Content.Section
                    {
                        Type = model.Type,
                        Key = model.Key,
                        Status = model.Status,
                        SortOrder = model.SortOrder,
                        Attributes = model.Attributes ?? "{}",
                        Configure = model.Configure ?? "{}",
                        CreatedAt = DateTime.UtcNow
                    };

                    _pazarAtlasiDbContext.Sections.Add(section);
                }
                else
                {
                    // Update existing section
                    section = await _pazarAtlasiDbContext.Sections
                        .FirstOrDefaultAsync(s => s.Id == model.Id);

                    if (section == null)
                    {
                        return NotFound();
                    }

                    section.Type = model.Type;
                    section.Key = model.Key;
                    section.Status = model.Status;
                    section.SortOrder = model.SortOrder;
                    section.Attributes = model.Attributes ?? "{}";
                    section.Configure = model.Configure ?? "{}";
                    section.UpdatedAt = DateTime.UtcNow;
                }

                await _pazarAtlasiDbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = model.Id == 0 ? "Section created successfully!" : "Section updated successfully!";
                return RedirectToAction(nameof(SectionDetails), new { id = section.Id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while saving the section: " + ex.Message;
                return View("CreateSection", model);
            }
        }

        /// <summary>
        /// Delete a section
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSection(int id)
        {
            try
            {
                var section = await _pazarAtlasiDbContext.Sections
                    .Include(s => s.SectionItemFieldValues)
                        .ThenInclude(fv => fv.SectionItem)
                        .ThenInclude(si => si.Translations)
                    .Include(s => s.SectionItemFieldValues)
                        .ThenInclude(fv => fv.Translations)
                    .Include(s => s.Translations)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (section == null)
                {
                    return Json(new { success = false, message = "Section not found." });
                }

                // Remove related data
                var sectionItemFieldValueTranslations = section.SectionItemFieldValues
                    .SelectMany(fv => fv.Translations);
                _pazarAtlasiDbContext.SectionItemFieldValueTranslations.RemoveRange(sectionItemFieldValueTranslations);

                var sectionItemTranslations = section.SectionItemFieldValues
                    .Select(fv => fv.SectionItem)
                    .SelectMany(si => si.Translations);
                _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(sectionItemTranslations);

                _pazarAtlasiDbContext.SectionItemFieldValues.RemoveRange(section.SectionItemFieldValues);
                _pazarAtlasiDbContext.SectionTranslations.RemoveRange(section.Translations);
                _pazarAtlasiDbContext.Sections.Remove(section);

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Section deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Get reusable sections for page creation
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetReusableSections()
        {
            try
            {
                var sections = await _pazarAtlasiDbContext.Sections
                    .Where(s => s.Status == Status.Active) // Reusable and active sections
                    .Include(s => s.Translations)
                    .Include(s => s.SectionTemplates)
                        .ThenInclude(st => st.Template)
                    .Select(s => new ReusableSectionDto
                    {
                        Id = s.Id,
                        Name = s.Translations.FirstOrDefault() != null ? s.Translations.FirstOrDefault()!.Title : $"Section {s.Id}",
                        Type = s.Type.ToString(),
                        TemplateType = s.SectionTemplates.FirstOrDefault() != null ? s.SectionTemplates.FirstOrDefault()!.Template.TemplateKey.ToString() : "Default",
                        Description = s.Translations.FirstOrDefault() != null ? s.Translations.FirstOrDefault()!.Description : ""
                    })
                    .OrderBy(s => s.Name)
                    .ToListAsync();

                return Json(new { success = true, sections = sections });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Add a reusable section to a page
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReusableSection(int pageId, int sectionId)
        {
            try
            {
                // Get the original reusable section
                var originalSection = await _pazarAtlasiDbContext.Sections
                    .Include(s => s.SectionItemFieldValues)
                        .ThenInclude(fv => fv.SectionItem)
                        .ThenInclude(si => si.Translations)
                    .Include(s => s.SectionItemFieldValues)
                        .ThenInclude(fv => fv.Translations)
                    .Include(s => s.Translations)
                    .FirstOrDefaultAsync(s => s.Id == sectionId);

                if (originalSection == null)
                {
                    return Json(new { success = false, message = "Reusable section not found." });
                }

                // Check if page exists
                var page = await _pazarAtlasiDbContext.Pages.FindAsync(pageId);
                if (page == null)
                {
                    return Json(new { success = false, message = "Page not found." });
                }

                // Get the next sort order for this page
                var maxSortOrder = await _pazarAtlasiDbContext.Sections
                    .MaxAsync(s => (int?)s.SortOrder) ?? 0;

                // Create a copy of the section for this page
                var newSection = new Domain.Entities.Content.Section
                {
                    Type = originalSection.Type,
                    Status = originalSection.Status,
                    SortOrder = maxSortOrder + 1,
                    Attributes = originalSection.Attributes,
                    Configure = originalSection.Configure,
                    CreatedAt = DateTime.UtcNow
                };

                _pazarAtlasiDbContext.Sections.Add(newSection);
                await _pazarAtlasiDbContext.SaveChangesAsync();

                // Copy section translations
                foreach (var translation in originalSection.Translations)
                {
                    var newTranslation = new Domain.Entities.Content.SectionTranslation
                    {
                        SectionId = newSection.Id,
                        LanguageId = translation.LanguageId,
                        Name = translation.Name,
                        Title = translation.Title,
                        Description = translation.Description
                    };
                    _pazarAtlasiDbContext.SectionTranslations.Add(newTranslation);
                }

                // Copy section field values and their related data
                foreach (var originalFieldValue in originalSection.SectionItemFieldValues)
                {
                    var newFieldValue = new SectionItemFieldValue
                    {
                        SectionId = newSection.Id,
                        SectionItemId = originalFieldValue.SectionItemId,
                        SectionItemFieldId = originalFieldValue.SectionItemFieldId,
                        Value = originalFieldValue.Value,
                        JsonValue = originalFieldValue.JsonValue,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    };

                    _pazarAtlasiDbContext.SectionItemFieldValues.Add(newFieldValue);
                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Copy field value translations
                    foreach (var translation in originalFieldValue.Translations)
                    {
                        var newTranslation = new SectionItemFieldValueTranslation
                        {
                            SectionItemFieldValueId = newFieldValue.Id,
                            LanguageId = translation.LanguageId,
                            Value = translation.Value,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        };
                        _pazarAtlasiDbContext.SectionItemFieldValueTranslations.Add(newTranslation);
                    }
                }

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Reusable section added successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        #endregion

        #region Layout Management

        /// <summary>
        /// Layouts list with pagination
        /// </summary>
        public async Task<IActionResult> Layouts(int page = 1, int pageSize = 10)
        {
            var totalCount = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>().CountAsync();

            var layouts = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>()
                .Include(l => l.LayoutSections)
                .Include(l => l.Pages)
                .OrderByDescending(l => l.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LayoutListViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Status = l.Status,
                    IsDefault = l.IsDefault,
                    SectionsCount = l.LayoutSections.Count,
                    PagesUsingCount = l.Pages.Count,
                    CreatedAt = l.CreatedAt,
                    UpdatedAt = l.UpdatedAt
                })
                .ToListAsync();

            var model = new LayoutListResponse
            {
                Layouts = layouts,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Layout details with all related data
        /// </summary>
        public async Task<IActionResult> LayoutDetails(int id)
        {
            var layout = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>()
                .Include(l => l.LayoutSections.OrderBy(ls => ls.SortOrder))
                    .ThenInclude(ls => ls.Section)
                        .ThenInclude(s => s.Translations)
                .Include(l => l.Pages)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (layout == null)
            {
                return NotFound();
            }

            var model = new LayoutViewModel
            {
                Id = layout.Id,
                Name = layout.Name,
                Description = layout.Description,
                Status = layout.Status,
                IsDefault = layout.IsDefault,
                CreatedAt = layout.CreatedAt,
                UpdatedAt = layout.UpdatedAt,
                LayoutSections = layout.LayoutSections.Select(ls => new LayoutSectionViewModel
                {
                    Id = ls.Id,
                    LayoutId = ls.LayoutId,
                    SectionId = ls.SectionId,
                    SectionName = ls.Section.Translations.FirstOrDefault()?.Title ?? $"Section {ls.SectionId}",
                    SectionType = ls.Section.Type,
                    SortOrder = ls.SortOrder,
                    IsRequired = ls.IsRequired,
                    Position = ls.Position
                }).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// Create a new layout
        /// </summary>
        [HttpGet]
        public IActionResult CreateLayout()
        {
            var model = new CreateLayoutViewModel
            {
                Status = Status.Draft,
                IsDefault = false
            };

            return View(model);
        }

        /// <summary>
        /// Save a new or existing layout
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLayout(CreateLayoutViewModel model)
        {
            try
            {
                Domain.Entities.Content.Layout layout;

                if (model.Id == 0)
                {
                    // Create new layout
                    layout = new Domain.Entities.Content.Layout
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Status = model.Status,
                        IsDefault = model.IsDefault,
                        CreatedAt = DateTime.UtcNow
                    };

                    _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>().Add(layout);
                }
                else
                {
                    // Update existing layout
                    layout = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>()
                        .Include(l => l.LayoutSections)
                        .FirstOrDefaultAsync(l => l.Id == model.Id);

                    if (layout == null)
                    {
                        return NotFound();
                    }

                    layout.Name = model.Name;
                    layout.Description = model.Description;
                    layout.Status = model.Status;
                    layout.IsDefault = model.IsDefault;
                    layout.UpdatedAt = DateTime.UtcNow;

                    // Remove existing layout sections
                    _pazarAtlasiDbContext.Set<Domain.Entities.Content.LayoutSection>().RemoveRange(layout.LayoutSections);
                }

                await _pazarAtlasiDbContext.SaveChangesAsync();

                // Add layout sections
                if (model.Sections != null && model.Sections.Any())
                {
                    foreach (var section in model.Sections)
                    {
                        var layoutSection = new Domain.Entities.Content.LayoutSection
                        {
                            LayoutId = layout.Id,
                            SectionId = section.SectionId,
                            Position = section.Position,
                            SortOrder = section.SortOrder,
                            IsRequired = section.IsRequired
                        };
                        _pazarAtlasiDbContext.Set<Domain.Entities.Content.LayoutSection>().Add(layoutSection);
                    }
                    await _pazarAtlasiDbContext.SaveChangesAsync();
                }

                // If this is set as default, remove default from others
                if (model.IsDefault)
                {
                    var otherLayouts = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>()
                        .Where(l => l.Id != layout.Id && l.IsDefault)
                        .ToListAsync();

                    foreach (var otherLayout in otherLayouts)
                    {
                        otherLayout.IsDefault = false;
                    }
                    await _pazarAtlasiDbContext.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = model.Id == 0 ? "Layout created successfully!" : "Layout updated successfully!";
                return RedirectToAction(nameof(LayoutDetails), new { id = layout.Id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while saving the layout: " + ex.Message;
                return View("CreateLayout", model);
            }
        }

        /// <summary>
        /// Delete a layout
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLayout(int id)
        {
            try
            {
                var layout = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>()
                    .Include(l => l.LayoutSections)
                    .Include(l => l.Pages)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (layout == null)
                {
                    return Json(new { success = false, message = "Layout not found." });
                }

                // Check if layout is being used by pages
                if (layout.Pages.Any())
                {
                    return Json(new { success = false, message = $"Cannot delete layout. It is being used by {layout.Pages.Count} page(s)." });
                }

                // Remove layout sections
                _pazarAtlasiDbContext.Set<Domain.Entities.Content.LayoutSection>().RemoveRange(layout.LayoutSections);
                _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>().Remove(layout);

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Layout deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Get available layouts for page selection
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAvailableLayouts()
        {
            try
            {
                var layouts = await _pazarAtlasiDbContext.Set<Domain.Entities.Content.Layout>()
                    .Where(l => l.Status == Status.Active)
                    .Select(l => new AvailableLayoutDto
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Description = l.Description,
                        IsDefault = l.IsDefault
                    })
                    .OrderByDescending(l => l.IsDefault)
                    .ThenBy(l => l.Name)
                    .ToListAsync();

                return Json(new { success = true, layouts = layouts });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Get layout sections with their configuration
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetLayoutSections(int layoutId)
        {
            try
            {
                var layoutSections = await _pazarAtlasiDbContext.Set<LayoutSection>()
                    .Include(ls => ls.Section)
                    .Where(ls => ls.LayoutId == layoutId && ls.Section.Status == Status.Active)
                    .OrderBy(ls => ls.SortOrder)
                    .Select(ls => new
                    {
                        sectionType = ls.Section.Type.ToString(),
                        position = ls.Position,
                        sortOrder = ls.SortOrder,
                        isRequired = ls.IsRequired
                    })
                    .ToListAsync();

                return Json(new { success = true, sections = layoutSections });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        #endregion

        #region Template Actions

        /// <summary>
        /// Template list view
        /// </summary>
        public async Task<IActionResult> Template()
        {
            var templates = await _pazarAtlasiDbContext.Templates
                .Include(t => t.Translations)
                    .ThenInclude(tt => tt.Language)
                .Include(t => t.SectionTypeTemplates)
                .Where(t => !t.IsDeleted)
                .OrderBy(t => t.SortOrder)
                .ThenBy(t => t.Id)
                .Select(t => new TemplateDto
                {
                    Id = t.Id,
                    TemplateKey = t.TemplateKey,
                    ConfigurationSchema = t.ConfigurationSchema,
                    IsActive = t.IsActive,
                    SortOrder = t.SortOrder,
                    SectionTypes = t.SectionTypeTemplates.Select(st => st.SectionType).ToList(),
                    Translations = t.Translations.Select(tt => new TemplateTranslationDto
                    {
                        Id = tt.Id,
                        TemplateId = tt.TemplateId,
                        LanguageId = tt.LanguageId,
                        LanguageName = tt.Language.Name,
                        LanguageCode = tt.Language.Code,
                        Name = tt.Name,
                        Description = tt.Description
                    }).ToList()
                })
                .ToListAsync();

            return View(templates);
        }

        /// <summary>
        /// Template create view - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> TemplateCreate()
        {
            var languages = await _pazarAtlasiDbContext.Languages
                .Where(l => !l.IsDeleted)
                .OrderByDescending(l => l.IsDefault) // Default language first
                .ThenBy(l => l.Name)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault
                })
                .ToListAsync();

            // Get all available section types except None
            var availableSectionTypes = Enum.GetValues<SectionType>()
                .Where(st => st != SectionType.None)
                .Select(st => new SectionTypeViewModel
                {
                    Value = st,
                    Name = GetSectionTypeDisplayName(st),
                    IsSelected = false
                })
                .OrderBy(st => st.Name)
                .ToList();

            var viewModel = new TemplateCreateViewModel
            {
                IsActive = true,
                SortOrder = 0,
                SelectedSectionTypes = new List<SectionType>(),
                AvailableSectionTypes = availableSectionTypes,
                AvailableLanguages = languages,
                Translations = languages.Select(l => new TemplateTranslationCreateViewModel
                {
                    LanguageId = l.Id,
                    LanguageName = l.Name,
                    LanguageCode = l.Code,
                    IsDefault = l.IsDefault
                }).ToList()
            };

            return View(viewModel);
        }

        /// <summary>
        /// Template create POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateCreate(TemplateCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await ReloadTemplateCreateViewModelData(model);
                return View(model);
            }

            try
            {
                // Check if template key already exists
                var existingTemplate = await _pazarAtlasiDbContext.Templates
                    .FirstOrDefaultAsync(t => t.TemplateKey == model.TemplateKey && !t.IsDeleted);

                if (existingTemplate != null)
                {
                    ModelState.AddModelError("TemplateKey", "A template with this key already exists.");
                    await ReloadTemplateCreateViewModelData(model);
                    return View(model);
                }

                // Create new template
                var template = new Template
                {
                    TemplateKey = model.TemplateKey,
                    ConfigurationSchema = model.ConfigurationSchema,
                    IsActive = model.IsActive,
                    SortOrder = model.SortOrder,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                _pazarAtlasiDbContext.Templates.Add(template);
                await _pazarAtlasiDbContext.SaveChangesAsync();

                // Add translations
                if (model.Translations != null && model.Translations.Any())
                {
                    var translations = model.Translations
                        .Where(t => !string.IsNullOrWhiteSpace(t.Name)) // Only add translations with names
                        .Select(t => new TemplateTranslation
                        {
                            TemplateId = template.Id,
                            LanguageId = t.LanguageId,
                            Name = t.Name,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                    if (translations.Any())
                    {
                        _pazarAtlasiDbContext.TemplateTranslations.AddRange(translations);
                        await _pazarAtlasiDbContext.SaveChangesAsync();
                    }
                }

                // Add section type templates
                if (model.SelectedSectionTypes != null && model.SelectedSectionTypes.Any())
                {
                    var sectionTypeTemplates = model.SelectedSectionTypes.Select(sectionType => new SectionTypeTemplate
                    {
                        SectionType = sectionType,
                        TemplateId = template.Id,
                        Status = Status.Active,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    }).ToList();

                    _pazarAtlasiDbContext.SectionTypeTemplates.AddRange(sectionTypeTemplates);
                    await _pazarAtlasiDbContext.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = "Template başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Template));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata oluştu: {ex.Message}";
                await ReloadTemplateCreateViewModelData(model);
                return View(model);
            }
        }

        /// <summary>
        /// Template edit view
        /// </summary>
        public async Task<IActionResult> TemplateEdit(int id)
        {
            var template = await _pazarAtlasiDbContext.Templates
                .Include(t => t.Translations)
                    .ThenInclude(tt => tt.Language)
                .Include(t => t.SectionTypeTemplates)
                .FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);

            if (template == null)
            {
                return NotFound();
            }

            var languages = await _pazarAtlasiDbContext.Languages
                .Where(l => !l.IsDeleted)
                .OrderByDescending(l => l.IsDefault) // Default language first
                .ThenBy(l => l.Name)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault
                })
                .ToListAsync();

            // Get all available section types except None
            var selectedSectionTypes = template.SectionTypeTemplates.Select(st => st.SectionType).ToList();
            var availableSectionTypes = Enum.GetValues<SectionType>()
                .Where(st => st != SectionType.None)
                .Select(st => new SectionTypeViewModel
                {
                    Value = st,
                    Name = GetSectionTypeDisplayName(st),
                    IsSelected = selectedSectionTypes.Contains(st)
                })
                .OrderBy(st => st.Name)
                .ToList();

            var viewModel = new TemplateEditViewModel
            {
                Id = template.Id,
                TemplateKey = template.TemplateKey,
                ConfigurationSchema = template.ConfigurationSchema,
                IsActive = template.IsActive,
                SortOrder = template.SortOrder,
                CreatedAt = template.CreatedAt,
                UpdatedAt = template.UpdatedAt,
                SelectedSectionTypes = selectedSectionTypes,
                AvailableSectionTypes = availableSectionTypes,
                AvailableLanguages = languages,
                Translations = languages.Select(l =>
                {
                    var existingTranslation = template.Translations.FirstOrDefault(t => t.LanguageId == l.Id);
                    return new TemplateTranslationEditViewModel
                    {
                        Id = existingTranslation?.Id ?? 0,
                        TemplateId = template.Id,
                        LanguageId = l.Id,
                        Name = existingTranslation?.Name ?? string.Empty,
                        Description = existingTranslation?.Description,
                        LanguageName = l.Name,
                        LanguageCode = l.Code,
                        IsDefault = l.IsDefault
                    };
                }).ToList()
            };

            return View(viewModel);
        }

        /// <summary>
        /// Template edit POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateEdit(TemplateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await ReloadTemplateEditViewModelData(model);
                return View(model);
            }

            try
            {
                var template = await _pazarAtlasiDbContext.Templates
                    .Include(t => t.Translations)
                    .Include(t => t.SectionTypeTemplates)
                    .FirstOrDefaultAsync(t => t.Id == model.Id && !t.IsDeleted);

                if (template == null)
                {
                    return NotFound();
                }

                // Update template properties
                template.TemplateKey = model.TemplateKey;
                template.ConfigurationSchema = model.ConfigurationSchema;
                template.IsActive = model.IsActive;
                template.SortOrder = model.SortOrder;
                template.UpdatedAt = DateTime.UtcNow;

                // Update translations
                foreach (var translationDto in model.Translations.Where(t => !string.IsNullOrWhiteSpace(t.Name)))
                {
                    var translation = template.Translations.FirstOrDefault(t => t.LanguageId == translationDto.LanguageId);
                    if (translation != null)
                    {
                        translation.Name = translationDto.Name;
                        translation.Description = translationDto.Description;
                        translation.UpdatedAt = DateTime.UtcNow;
                    }
                    else
                    {
                        // Add new translation
                        template.Translations.Add(new TemplateTranslation
                        {
                            TemplateId = template.Id,
                            LanguageId = translationDto.LanguageId,
                            Name = translationDto.Name,
                            Description = translationDto.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        });
                    }
                }

                // Remove translations that are now empty
                var emptyTranslations = template.Translations
                    .Where(t => !model.Translations.Any(mt => mt.LanguageId == t.LanguageId && !string.IsNullOrWhiteSpace(mt.Name)))
                    .ToList();

                foreach (var emptyTranslation in emptyTranslations)
                {
                    _pazarAtlasiDbContext.TemplateTranslations.Remove(emptyTranslation);
                }

                // Update section type templates
                var existingSectionTypeTemplates = await _pazarAtlasiDbContext.SectionTypeTemplates
                    .Where(st => st.TemplateId == template.Id)
                    .ToListAsync();

                // Remove existing section type templates
                _pazarAtlasiDbContext.SectionTypeTemplates.RemoveRange(existingSectionTypeTemplates);

                // Add new section type templates
                if (model.SelectedSectionTypes != null && model.SelectedSectionTypes.Any())
                {
                    var newSectionTypeTemplates = model.SelectedSectionTypes.Select(sectionType => new SectionTypeTemplate
                    {
                        SectionType = sectionType,
                        TemplateId = template.Id,
                        Status = Status.Active,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    }).ToList();

                    _pazarAtlasiDbContext.SectionTypeTemplates.AddRange(newSectionTypeTemplates);
                }

                await _pazarAtlasiDbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Template başarıyla güncellendi.";
                return RedirectToAction(nameof(Template));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata oluştu: {ex.Message}";
                await ReloadTemplateEditViewModelData(model);
                return View(model);
            }
        }

        #endregion Template Actions

        #region SectionItems Actions

        /// <summary>
        /// SectionItems list view
        /// </summary>
        public async Task<IActionResult> SectionItems()
        {
            var sectionItems = await _pazarAtlasiDbContext.SectionItems
                .Include(si => si.Template)
                .Include(si => si.Translations)
                    .ThenInclude(t => t.Language)
                .Include(si => si.ParentSectionItem)
                .Include(si => si.SectionItemFields)
                    .ThenInclude(f => f.Translations)
                .Include(si => si.SectionItemFieldValues)
                    .ThenInclude(fv => fv.Translations)
                .Where(si => !si.IsDeleted)
                .OrderBy(si => si.SortOrder)
                .ThenBy(si => si.CreatedAt)
                .ToListAsync();

            // Build hierarchical tree structure
            var hierarchicalItems = BuildSectionItemTree(sectionItems);

            // Flatten the tree for display with proper indentation
            var flattenedItems = new List<SectionItemDto>();
            FlattenSectionItemTree(hierarchicalItems, flattenedItems, 0);

            return View(flattenedItems);
        }

        /// <summary>
        /// Unified SectionItem form (GET) - handles both create and edit
        /// </summary>
        public async Task<IActionResult> SectionItemForm(int? id)
        {
            try
            {
                var viewModel = new SectionItemFormViewModel();

                // Load dropdown data
                viewModel.AvailableLanguages = await _pazarAtlasiDbContext.Languages
                    .Where(l => !l.IsDeleted)
                    .Select(l => new LanguageViewModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Code = l.Code,
                        IsDefault = l.IsDefault
                    })
                    .OrderBy(l => l.Name)
                    .ToListAsync();

                var templates = await _pazarAtlasiDbContext.Templates
                    .Include(t => t.Translations)
                    .Where(t => t.IsActive && !t.IsDeleted)
                    .OrderBy(t => t.SortOrder)
                    .ToListAsync();

                viewModel.Templates = templates.Select(t => new TemplateDto
                {
                    Id = t.Id,
                    TemplateKey = t.TemplateKey,
                    ConfigurationSchema = t.ConfigurationSchema,
                    IsActive = t.IsActive,
                    SortOrder = t.SortOrder,
                    Translations = t.Translations.Select(tt => new TemplateTranslationDto
                    {
                        Id = tt.Id,
                        TemplateId = tt.TemplateId,
                        LanguageId = tt.LanguageId,
                        Name = tt.Name,
                        Description = tt.Description
                    }).ToList()
                }).ToList();

                viewModel.SectionItemTypes = Enum.GetValues<SectionItemType>().Select(e => e.ToString()).ToList();
                viewModel.MediaTypes = Enum.GetValues<MediaType>().Select(e => e.ToString()).ToList();

                if (id.HasValue && id.Value > 0)
                {
                    // Edit mode - load existing item
                    var sectionItem = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                        .Include(si => si.SectionItemFields)
                            .ThenInclude(f => f.Translations)
                        .Include(si => si.SectionItemFieldValues)
                            .ThenInclude(fv => fv.Translations)
                        .FirstOrDefaultAsync(si => si.Id == id.Value && !si.IsDeleted);

                    if (sectionItem == null)
                    {
                        TempData["ErrorMessage"] = "Section item not found.";
                        return RedirectToAction(nameof(SectionItems));
                    }

                    // Map to DTO
                    viewModel.SectionItem = new SectionItemUpdateDto
                    {
                        Id = sectionItem.Id,
                        ParentSectionItemId = sectionItem.ParentSectionItemId,
                        TemplateId = sectionItem.TemplateId,
                        Type = sectionItem.Type,
                        MediaType = sectionItem.MediaType,
                        SortOrder = sectionItem.SortOrder,
                        Title = sectionItem.Title,
                        Key = sectionItem.Key,
                        Description = sectionItem.Description,
                        AllowReorder = sectionItem.AllowReorder,
                        AllowRemove = sectionItem.AllowRemove,
                        IconClass = sectionItem.IconClass,
                        Translations = viewModel.AvailableLanguages.Select(l =>
                        {
                            var existingTranslation = sectionItem.Translations.FirstOrDefault(t => t.LanguageId == l.Id);
                            return new SectionItemTranslationUpdateDto
                            {
                                Id = existingTranslation?.Id ?? 0,
                                SectionItemId = sectionItem.Id,
                                LanguageId = l.Id,
                                Title = existingTranslation?.Title ?? "",
                                Description = existingTranslation?.Description ?? ""
                            };
                        }).ToList(),
                        Fields = sectionItem.SectionItemFields.Select(f => new SectionItemFieldUpdateDto
                        {
                            Id = f.Id,
                            SectionItemId = f.SectionItemId,
                            FieldKey = f.FieldKey,
                            FieldName = f.FieldName,
                            Type = f.Type,
                            Required = f.Required,
                            MaxLength = f.MaxLength,
                            Placeholder = f.Placeholder,
                            DefaultValue = f.DefaultValue,
                            IsTranslatable = f.IsTranslatable,
                            OptionsJson = f.OptionsJson,
                            SortOrder = f.SortOrder,
                            FieldTypes = GetSectionItemFieldTypes(),
                            Translations = f.Translations.Select(ft => new SectionItemFieldTranslationUpdateDto
                            {
                                Id = ft.Id,
                                SectionItemFieldId = ft.SectionItemFieldId,
                                LanguageId = ft.LanguageId,
                                Label = ft.Label,
                                Description = ft.Description,
                                Placeholder = ft.Placeholder
                            }).ToList()
                        }).ToList(),
                        FieldValues = sectionItem.SectionItemFieldValues.Select(fv => new SectionItemFieldValueUpdateDto
                        {
                            Id = fv.Id,
                            SectionId = fv.SectionId,
                            SectionItemId = fv.SectionItemId,
                            SectionItemFieldId = fv.SectionItemFieldId,
                            Value = fv.Value,
                            Translations = fv.Translations.Select(fvt => new SectionItemFieldValueTranslationUpdateDto
                            {
                                Id = fvt.Id,
                                SectionItemFieldValueId = fvt.SectionItemFieldValueId,
                                LanguageId = fvt.LanguageId,
                                Value = fvt.Value
                            }).ToList()
                        }).ToList()
                    };

                    // Load parent items (excluding current item and its children)
                    viewModel.ParentSectionItems = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                        .Where(si => !si.IsDeleted && si.Id != id.Value)
                        .Select(si => new SectionItemDto
                        {
                            Id = si.Id,
                            Title = si.Title,
                            Translations = si.Translations.Select(t => new SectionItemTranslationDto
                            {
                                Id = t.Id,
                                LanguageId = t.LanguageId,
                                Title = t.Title,
                                Description = t.Description
                            }).ToList()
                        })
                        .OrderBy(si => si.Title)
                        .ToListAsync();

                    // Load parent item if exists
                    if (sectionItem.ParentSectionItemId.HasValue)
                    {
                        var parentItem = await _pazarAtlasiDbContext.SectionItems
                            .Include(si => si.Translations)
                            .FirstOrDefaultAsync(si => si.Id == sectionItem.ParentSectionItemId.Value && !si.IsDeleted);

                        if (parentItem != null)
                        {
                            viewModel.ParentItem = new SectionItemDto
                            {
                                Id = parentItem.Id,
                                Title = parentItem.Title,
                                Type = parentItem.Type,
                                MediaType = parentItem.MediaType,
                                SortOrder = parentItem.SortOrder,
                                Key = parentItem.Key,
                                Description = parentItem.Description,
                                IconClass = parentItem.IconClass,
                                Translations = parentItem.Translations.Select(t => new SectionItemTranslationDto
                                {
                                    Id = t.Id,
                                    LanguageId = t.LanguageId,
                                    Title = t.Title,
                                    Description = t.Description
                                }).ToList()
                            };
                        }
                    }

                    // Load child items
                    var childItems = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                        .Where(si => si.ParentSectionItemId == id.Value && !si.IsDeleted)
                        .OrderBy(si => si.SortOrder)
                        .ToListAsync();

                    viewModel.ChildItems = childItems.Select(ci => new SectionItemDto
                    {
                        Id = ci.Id,
                        Title = ci.Title,
                        Type = ci.Type,
                        MediaType = ci.MediaType,
                        SortOrder = ci.SortOrder,
                        Key = ci.Key,
                        Description = ci.Description,
                        IconClass = ci.IconClass,
                        Translations = ci.Translations.Select(t => new SectionItemTranslationDto
                        {
                            Id = t.Id,
                            LanguageId = t.LanguageId,
                            Title = t.Title,
                            Description = t.Description
                        }).ToList()
                    }).ToList();
                }
                else
                {
                    // Create mode - initialize empty item
                    viewModel.SectionItem = new SectionItemUpdateDto
                    {
                        SortOrder = 0,
                        AllowReorder = true,
                        AllowRemove = true,
                        Translations = viewModel.AvailableLanguages.Select(l => new SectionItemTranslationUpdateDto
                        {
                            LanguageId = l.Id,
                            Title = "",
                            Description = ""
                        }).ToList()
                    };

                    // Load all items as potential parents
                    viewModel.ParentSectionItems = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                        .Where(si => !si.IsDeleted)
                        .Select(si => new SectionItemDto
                        {
                            Id = si.Id,
                            Title = si.Title,
                            Translations = si.Translations.Select(t => new SectionItemTranslationDto
                            {
                                Id = t.Id,
                                LanguageId = t.LanguageId,
                                Title = t.Title,
                                Description = t.Description
                            }).ToList()
                        })
                        .OrderBy(si => si.Title)
                        .ToListAsync();
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction(nameof(SectionItems));
            }
        }

        /// <summary>
        /// Unified SectionItem form (POST) - handles both create and edit
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionItemForm(SectionItemFormViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Reload dropdown data
                    await LoadSectionItemFormDropdownData(viewModel);
                    return View(viewModel);
                }

                var model = viewModel.SectionItem;

                if (model.Id > 0)
                {
                    // Update existing item
                    var sectionItem = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                        .Include(si => si.SectionItemFields)
                            .ThenInclude(f => f.Translations)
                        .FirstOrDefaultAsync(si => si.Id == model.Id && !si.IsDeleted);

                    if (sectionItem == null)
                    {
                        viewModel.ErrorMessage = "Section item not found.";
                        await LoadSectionItemFormDropdownData(viewModel);
                        return View(viewModel);
                    }

                    // Update properties
                    sectionItem.ParentSectionItemId = model.ParentSectionItemId;
                    sectionItem.TemplateId = model.TemplateId;
                    sectionItem.Type = model.Type;
                    sectionItem.MediaType = model.MediaType;
                    sectionItem.SortOrder = model.SortOrder;
                    sectionItem.Title = model.Title;
                    sectionItem.Key = model.Key;
                    sectionItem.Description = model.Description;
                    sectionItem.AllowReorder = model.AllowReorder;
                    sectionItem.AllowRemove = model.AllowRemove;
                    sectionItem.IconClass = model.IconClass;
                    sectionItem.UpdatedAt = DateTime.UtcNow;

                    // Update translations
                    _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(sectionItem.Translations);

                    foreach (var translationDto in model.Translations.Where(t => !string.IsNullOrEmpty(t.Title) || !string.IsNullOrEmpty(t.Description)))
                    {
                        sectionItem.Translations.Add(new SectionItemTranslation
                        {
                            SectionItemId = sectionItem.Id,
                            LanguageId = translationDto.LanguageId,
                            Title = translationDto.Title,
                            Description = translationDto.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        });
                    }

                    // Update fields
                    await UpdateSectionItemFields(sectionItem, model.Fields);

                    await _pazarAtlasiDbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Section item updated successfully.";
                }
                else
                {
                    // Create new item
                    var sectionItem = new SectionItem
                    {
                        ParentSectionItemId = model.ParentSectionItemId,
                        TemplateId = model.TemplateId,
                        Type = model.Type,
                        MediaType = model.MediaType,
                        SortOrder = model.SortOrder,
                        Title = model.Title,
                        Key = model.Key,
                        Description = model.Description,
                        AllowReorder = model.AllowReorder,
                        AllowRemove = model.AllowRemove,
                        IconClass = model.IconClass,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    };

                    _pazarAtlasiDbContext.SectionItems.Add(sectionItem);
                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Add translations
                    foreach (var translationDto in model.Translations.Where(t => !string.IsNullOrEmpty(t.Title) || !string.IsNullOrEmpty(t.Description)))
                    {
                        sectionItem.Translations.Add(new SectionItemTranslation
                        {
                            SectionItemId = sectionItem.Id,
                            LanguageId = translationDto.LanguageId,
                            Title = translationDto.Title,
                            Description = translationDto.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        });
                    }

                    // Add fields
                    await UpdateSectionItemFields(sectionItem, model.Fields);

                    await _pazarAtlasiDbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Section item created successfully.";
                }

                return RedirectToAction(nameof(SectionItems));
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = $"An error occurred: {ex.Message}";
                await LoadSectionItemFormDropdownData(viewModel);
                return View(viewModel);
            }
        }

        /// <summary>
        /// Helper method to load dropdown data for SectionItemForm
        /// </summary>
        private async Task LoadSectionItemFormDropdownData(SectionItemFormViewModel viewModel)
        {
            viewModel.AvailableLanguages = await _pazarAtlasiDbContext.Languages
                .Where(l => !l.IsDeleted)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault
                })
                .OrderBy(l => l.Name)
                .ToListAsync();

            var templates = await _pazarAtlasiDbContext.Templates
                .Include(t => t.Translations)
                .Where(t => t.IsActive && !t.IsDeleted)
                .OrderBy(t => t.SortOrder)
                .ToListAsync();

            viewModel.Templates = templates.Select(t => new TemplateDto
            {
                Id = t.Id,
                TemplateKey = t.TemplateKey,
                ConfigurationSchema = t.ConfigurationSchema,
                IsActive = t.IsActive,
                SortOrder = t.SortOrder
            }).ToList();

            viewModel.ParentSectionItems = await _pazarAtlasiDbContext.SectionItems
                .Include(si => si.Translations)
                .Where(si => !si.IsDeleted && si.Id != viewModel.SectionItem.Id)
                .Select(si => new SectionItemDto
                {
                    Id = si.Id,
                    Title = si.Title,
                    Translations = si.Translations.Select(t => new SectionItemTranslationDto
                    {
                        Id = t.Id,
                        LanguageId = t.LanguageId,
                        Title = t.Title,
                        Description = t.Description
                    }).ToList()
                })
                .OrderBy(si => si.Title)
                .ToListAsync();

            viewModel.SectionItemTypes = Enum.GetValues<SectionItemType>().Select(e => e.ToString()).ToList();
            viewModel.MediaTypes = Enum.GetValues<MediaType>().Select(e => e.ToString()).ToList();
        }

        /// <summary>
        /// Backward compatibility - redirect to SectionItemForm
        /// </summary>
        public IActionResult SectionItemCreate()
        {
            return RedirectToAction(nameof(SectionItemForm));
        }

        /// <summary>
        /// Backward compatibility - redirect to SectionItemForm with id
        /// </summary>
        public IActionResult SectionItemEdit(int id)
        {
            return RedirectToAction(nameof(SectionItemForm), new { id });
        }

        #endregion SectionItems Actions

        /// <summary>
        /// Get new field partial view for adding fields dynamically
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetNewFieldPartial(int fieldIndex)
        {
            try
            {
                var languages = await GetAvailableLanguagesAsync();

                var newField = new SectionItemFieldUpdateDto
                {
                    Id = 0,
                    SectionItemId = 0,
                    FieldKey = "",
                    FieldName = "",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    IsTranslatable = false,
                    SortOrder = fieldIndex + 1,
                    FieldTypes = GetSectionItemFieldTypes(),
                    Translations = languages.Select(l => new SectionItemFieldTranslationUpdateDto
                    {
                        Id = 0,
                        SectionItemFieldId = 0,
                        LanguageId = l.Id,
                        Label = "",
                        Description = "",
                        Placeholder = ""
                    }).ToList()
                };

                ViewBag.Languages = languages;
                ViewBag.FieldIndex = fieldIndex;

                return PartialView("_SectionItemDetailField", newField);
            }
            catch (Exception ex)
            {
                return Content($"<div class='text-red-500'>Error: {ex.Message}</div>");
            }
        }


        #region Helper Methods

        /// <summary>
        /// Map section items to view model with nested structure
        /// </summary>
        private List<SectionItemEditViewModel> MapSectionItemsToViewModel(List<SectionItem> sectionItems)
        {
            // Only map root level items (parentId == null)
            // Child items will be mapped recursively in MapSingleSectionItemToViewModel
            var rootItems = sectionItems.Where(si => si.ParentSectionItemId == null).ToList();
            return rootItems.Select(si => MapSingleSectionItemToViewModel(si, sectionItems)).ToList();
        }

        /// <summary>
        /// Map a single section item to view model
        /// </summary>
        private SectionItemEditViewModel MapSingleSectionItemToViewModel(SectionItem si, List<SectionItem> allItems)
        {
            return new SectionItemEditViewModel
            {
                Id = si.Id,
                ParentSectionItemId = si.ParentSectionItemId,
                Type = si.Type,
                MediaType = si.MediaType,
                SortOrder = si.SortOrder,
                Status = si.Status,
                Fields = si.SectionItemFields?.Select(fv => new SectionItemFieldEditViewModel
                {
                    Id = fv.Id,
                    SectionItemId = fv.SectionItemId,
                    FieldType = fv?.Type ?? SectionItemFieldType.Text,
                    FieldKey = fv?.FieldKey ?? "",
                    FieldValue = fv.DefaultValue,
                }).ToList() ?? new List<SectionItemFieldEditViewModel>(),
                Translations = si.Translations?.Select(sit => new SectionItemTranslationEditViewModel
                {
                    Id = sit.Id,
                    LanguageId = sit.LanguageId,
                    Title = sit.Title,
                    Description = sit.Description
                }).ToList() ?? new List<SectionItemTranslationEditViewModel>(),
                ChildItems = GetChildSectionItems(si, allItems)
            };
        }

        /// <summary>
        /// Recursively get child section items
        /// </summary>
        private List<SectionItemEditViewModel> GetChildSectionItems(SectionItem parent, List<SectionItem> allItems)
        {
            var childItems = allItems.Where(si => si.ParentSectionItemId == parent.Id).ToList();

            return childItems.Select(child => MapSingleSectionItemToViewModel(child, allItems)).ToList();
        }


        /// <summary>
        /// Process section items and their nested items recursively
        /// </summary>
        private async Task ProcessSectionItems(List<SectionItemRequest> itemRequests, int sectionId, int? parentItemId = null)
        {
            if (itemRequests == null || !itemRequests.Any())
                return;

            foreach (var itemRequest in itemRequests)
            {
                // Process field values (both translatable and non-translatable)
                if (itemRequest.Fields != null && itemRequest.Fields.Any())
                {
                    foreach (var fieldRequest in itemRequest.Fields)
                    {
                        try
                        {
                            SectionItemFieldValue fieldValue;

                            if (fieldRequest.Id > 0)
                            {
                                // Update existing field value
                                fieldValue = await _pazarAtlasiDbContext.SectionItemFieldValues
                                    .Include(fv => fv.Translations)
                                    .FirstOrDefaultAsync(fv => fv.SectionItemFieldId == fieldRequest.Id);

                                if (fieldValue != null)
                                {
                                    // Update existing field value
                                    var sectionItemField = await _pazarAtlasiDbContext.SectionItemFields
                                        .FirstOrDefaultAsync(f => f.Id == fieldValue.SectionItemFieldId);
                                    
                                    fieldValue.Value = ProcessFieldValue(fieldRequest.FieldValue, sectionItemField?.Type ?? SectionItemFieldType.Text);
                                    fieldValue.UpdatedAt = DateTime.UtcNow;

                                    // Remove existing translations
                                    _pazarAtlasiDbContext.SectionItemFieldValueTranslations.RemoveRange(fieldValue.Translations);
                                }
                                else
                                {
                                    // Field value not found, create new one
                                    // We need to find the SectionItemField by FieldKey to get the correct SectionItemFieldId
                                    var sectionItemField = await _pazarAtlasiDbContext.SectionItemFields
                                        .FirstOrDefaultAsync(f => f.Id == fieldRequest.Id && !f.IsDeleted);

                                    if (sectionItemField == null)
                                    {
                                        Console.WriteLine($"SectionItemField not found for FieldKey: {fieldRequest.FieldKey}");
                                        continue;
                                    }

                                    fieldValue = new SectionItemFieldValue
                                    {
                                        SectionId = sectionId,
                                        SectionItemId = itemRequest.Id,
                                        SectionItemFieldId = sectionItemField.Id,
                                        Value = fieldRequest.FieldValue ?? string.Empty,
                                        CreatedAt = DateTime.UtcNow,
                                        IsDeleted = false
                                    };
                                    _pazarAtlasiDbContext.SectionItemFieldValues.Add(fieldValue);
                                }
                            }
                            else
                            {
                                // Create new field value
                                // We need to find the SectionItemField by FieldKey to get the correct SectionItemFieldId
                                var sectionItemField = await _pazarAtlasiDbContext.SectionItemFields
                                    .FirstOrDefaultAsync(f => f.FieldKey == fieldRequest.FieldKey && !f.IsDeleted);

                                if (sectionItemField == null)
                                {
                                    Console.WriteLine($"SectionItemField not found for FieldKey: {fieldRequest.FieldKey}");
                                    continue;
                                }

                                fieldValue = new SectionItemFieldValue
                                {
                                    SectionId = sectionId,
                                    SectionItemId = itemRequest.Id,
                                    SectionItemFieldId = sectionItemField.Id,
                                    Value = ProcessFieldValue(fieldRequest.FieldValue, sectionItemField.Type),
                                    CreatedAt = DateTime.UtcNow,
                                    IsDeleted = false
                                };
                                _pazarAtlasiDbContext.SectionItemFieldValues.Add(fieldValue);
                            }

                            await _pazarAtlasiDbContext.SaveChangesAsync(); // Save to get field value ID

                            // Process field value translations if they exist
                            if (fieldRequest.Translations != null && fieldRequest.Translations.Any())
                            {
                                var fieldValueTranslations = fieldRequest.Translations.Select(t => new SectionItemFieldValueTranslation
                                {
                                    SectionItemFieldValueId = fieldValue.Id,
                                    LanguageId = t.LanguageId,
                                    Value = t.Value ?? string.Empty,
                                    CreatedAt = DateTime.UtcNow,
                                    IsDeleted = false
                                }).ToList();

                                _pazarAtlasiDbContext.SectionItemFieldValueTranslations.AddRange(fieldValueTranslations);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log error but continue processing
                            Console.WriteLine($"Error processing field {fieldRequest.FieldKey}: {ex.Message}");
                        }
                    }

                    await _pazarAtlasiDbContext.SaveChangesAsync();
                }

                // Process section item translations
                if (itemRequest.Translations != null && itemRequest.Translations.Any())
                {
                    var itemTranslations = itemRequest.Translations.Select(t => new SectionItemTranslation
                    {
                        SectionItemId = itemRequest.Id,
                        LanguageId = t.LanguageId,
                        Title = t.Title,
                        Description = t.Description,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    }).ToList();

                    _pazarAtlasiDbContext.SectionItemTranslations.AddRange(itemTranslations);
                    await _pazarAtlasiDbContext.SaveChangesAsync();
                }

                // Process nested items recursively
                if (itemRequest.NestedItems != null && itemRequest.NestedItems.Any())
                {
                    await ProcessSectionItems(itemRequest.NestedItems, sectionId, itemRequest.Id);
                }
            }
        }

        private async Task<PageEditViewModel> MapToPageEditViewModel(Page page, List<LanguageViewModel> languages)
        {
            var model = new PageEditViewModel
            {
                Id = page.Id,
                Name = page.Name,
                Code = page.Code,
                PageType = page.PageType,
                Description = page.Description,
                Status = page.Status,
                ParentPageId = page.ParentPageId,
                ParentPageName = page.ParentPage?.Name,
                SEOParameter = page.PageSEOParameter != null ? new PageSEOParameterEditViewModel
                {
                    Id = page.PageSEOParameter.Id,
                    MetaTitle = page.PageSEOParameter.MetaTitle,
                    MetaDescription = page.PageSEOParameter.MetaDescription,
                    MetaKeywords = page.PageSEOParameter.MetaKeywords,
                    Title = page.PageSEOParameter.Title,
                    CanonicalURL = page.PageSEOParameter.CanonicalURL,
                    Author = page.PageSEOParameter.Author,
                    Description = page.PageSEOParameter.Description
                } : new PageSEOParameterEditViewModel(),
                Sections = page.PageSections.Select(ps => ps.Section).Select(s => new SectionEditViewModel
                {
                    Id = s.Id,
                    Type = s.Type,
                    Key = s.Key,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = MapSectionItemsToViewModel(s.SectionItemValues.Select(s => s.SectionItem).ToList()),
                    Translations = s.Translations.Select(st => new SectionTranslationEditViewModel
                    {
                        Id = st.Id,
                        LanguageId = st.LanguageId,
                        Name = st.Name,
                        Title = st.Title,
                        Description = st.Description
                    }).ToList()
                }).ToList(),
                Translations = page.PageTranslations.Select(pt => new PageTranslationEditViewModel
                {
                    Id = pt.Id,
                    LanguageId = pt.LanguageId,
                    LanguageName = pt.Language.Name,
                    LanguageCode = pt.Language.Code,
                    Value = pt.Value
                }).ToList(),
                AvailableLanguages = languages
            };

            // Load available parent pages
            model.AvailableParentPages = await GetAvailableParentPagesAsync(page.Id);

            return model;
        }

        private async Task<List<LanguageViewModel>> GetAvailableLanguagesAsync()
        {
            return await _pazarAtlasiDbContext.Languages
                .Where(l => !l.IsDeleted)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault
                })
                .ToListAsync();
        }

        /// <summary>
        /// Get SectionItemFieldTypes as SelectListItem list
        /// </summary>
        private List<SelectListItem> GetSectionItemFieldTypes()
        {
            return Enum.GetValues<SectionItemFieldType>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                })
                .ToList();
        }

        /// <summary>
        /// Build hierarchical tree structure from flat list
        /// </summary>
        private List<SectionItemDto> BuildSectionItemTree(List<SectionItem> sectionItems)
        {
            var itemDictionary = new Dictionary<int, SectionItemDto>();
            var rootItems = new List<SectionItemDto>();

            // First pass: Create all DTOs
            foreach (var item in sectionItems)
            {
                var dto = MapSectionItemToDto(item);
                itemDictionary[item.Id] = dto;
            }

            // Second pass: Build parent-child relationships
            foreach (var item in sectionItems)
            {
                var dto = itemDictionary[item.Id];

                if (item.ParentSectionItemId.HasValue && itemDictionary.ContainsKey(item.ParentSectionItemId.Value))
                {
                    var parent = itemDictionary[item.ParentSectionItemId.Value];
                    parent.Children.Add(dto);
                    parent.HasChildren = true;
                    dto.IsChild = true;
                    dto.ParentTitle = parent.Title;
                }
                else
                {
                    rootItems.Add(dto);
                }
            }

            return rootItems.OrderBy(r => r.SortOrder).ToList();
        }

        /// <summary>
        /// Flatten tree structure for display with proper indentation levels
        /// </summary>
        private void FlattenSectionItemTree(List<SectionItemDto> items, List<SectionItemDto> flatList, int level)
        {
            foreach (var item in items.OrderBy(i => i.SortOrder))
            {
                item.Level = level;
                flatList.Add(item);

                if (item.Children.Any())
                {
                    FlattenSectionItemTree(item.Children, flatList, level + 1);
                }
            }
        }

        /// <summary>
        /// Map SectionItem to DTO
        /// </summary>
        private SectionItemDto MapSectionItemToDto(SectionItem si)
        {
            return new SectionItemDto
            {
                Id = si.Id,
                ParentSectionItemId = si.ParentSectionItemId,
                TemplateId = si.TemplateId,
                TemplateName = si.Template?.Translations.FirstOrDefault()?.Name ?? "No Template",
                Type = si.Type,
                MediaType = si.MediaType,
                SortOrder = si.SortOrder,
                Title = si.Translations.FirstOrDefault()?.Title ?? si.Title,
                Key = si.Key,
                Description = si.Translations.FirstOrDefault()?.Description ?? si.Description,
                AllowReorder = si.AllowReorder,
                AllowRemove = si.AllowRemove,
                IconClass = si.IconClass,
                Translations = si.Translations.Select(t => new SectionItemTranslationDto
                {
                    Id = t.Id,
                    SectionItemId = t.SectionItemId,
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language?.Name ?? "Unknown",
                    LanguageCode = t.Language?.Code ?? "N/A",
                    Title = t.Title,
                    Description = t.Description
                }).ToList(),
                Fields = si.SectionItemFields.Select(f => new SectionItemFieldDto
                {
                    Id = f.Id,
                    SectionItemId = f.SectionItemId,
                    FieldKey = f.FieldKey,
                    FieldName = f.Translations.FirstOrDefault()?.Label ?? f.FieldKey,
                    Type = f.Type,
                    Required = f.Required,
                    MaxLength = f.MaxLength,
                    Placeholder = f.Translations.FirstOrDefault()?.Placeholder ?? f.Placeholder,
                    DefaultValue = f.DefaultValue,
                    IsTranslatable = f.IsTranslatable,
                    OptionsJson = f.OptionsJson,
                    SortOrder = f.SortOrder,
                    Translations = f.Translations.Select(ft => new SectionItemFieldTranslationDto
                    {
                        Id = ft.Id,
                        SectionItemFieldId = ft.SectionItemFieldId,
                        LanguageId = ft.LanguageId,
                        LanguageName = ft.Language?.Name ?? "Unknown",
                        LanguageCode = ft.Language?.Code ?? "N/A",
                        Label = ft.Label,
                        Description = ft.Description,
                        Placeholder = ft.Placeholder
                    }).ToList()
                }).ToList(),
                FieldValues = si.SectionItemFieldValues.Select(fv => new SectionItemFieldValueDto
                {
                    Id = fv.Id,
                    SectionId = fv.SectionId,
                    SectionItemId = fv.SectionItemId,
                    SectionItemFieldId = fv.SectionItemFieldId,
                    Value = fv.Value,
                    JsonValue = fv.JsonValue,
                    Translations = fv.Translations.Select(fvt => new SectionItemFieldValueTranslationDto
                    {
                        Id = fvt.Id,
                        SectionItemFieldValueId = fvt.SectionItemFieldValueId,
                        LanguageId = fvt.LanguageId,
                        LanguageName = fvt.Language?.Name ?? "Unknown",
                        LanguageCode = fvt.Language?.Code ?? "N/A",
                        Value = fvt.Value,
                        JsonValue = fvt.JsonValue
                    }).ToList()
                }).ToList()
            };
        }

        /// <summary>
        /// Build nested section item view models from SectionItemValues and FieldValues (Optimized)
        /// </summary>
        private List<SectionItemViewModel> BuildNestedSectionItemViewModelsOptimized(
            List<SectionItemValue> sectionItemValues,
            List<SectionItem> allSectionItems,
            List<SectionItemFieldValue> fieldValues)
        {
            var result = new List<SectionItemViewModel>();

            // Get root items (items without parent)
            var rootItems = sectionItemValues.Where(siv => siv.SectionItem.ParentSectionItemId == null).ToList();

            foreach (var rootItemValue in rootItems)
            {
                var rootViewModel = BuildSectionItemViewModelOptimized(rootItemValue.SectionItem, allSectionItems, fieldValues, rootItemValue.SectionId);
                result.Add(rootViewModel);
            }

            return result.OrderBy(r => r.SortOrder).ToList();
        }

        /// <summary>
        /// Build nested section item view models from SectionItemValues and FieldValues (Legacy)
        /// </summary>
        private List<SectionItemViewModel> BuildNestedSectionItemViewModels(
            List<SectionItemValue> sectionItemValues,
            List<SectionItemFieldValue> fieldValues)
        {
            var result = new List<SectionItemViewModel>();

            // Get root items (items without parent)
            var rootItems = sectionItemValues.Where(siv => siv.SectionItem.ParentSectionItemId == null).ToList();

            foreach (var rootItemValue in rootItems)
            {
                var rootViewModel = BuildSectionItemViewModel(rootItemValue, sectionItemValues, fieldValues);
                result.Add(rootViewModel);
            }

            return result.OrderBy(r => r.SortOrder).ToList();
        }

        /// <summary>
        /// Build a single section item view model with its children recursively (Optimized)
        /// </summary>
        private SectionItemViewModel BuildSectionItemViewModelOptimized(
            SectionItem sectionItem,
            List<SectionItem> allSectionItems,
            List<SectionItemFieldValue> allFieldValues,
            int sectionId)
        {
            // Get field values for this specific section item
            var itemFieldValues = allFieldValues.Where(fv => fv.SectionItemId == sectionItem.Id).ToList();

            // Build field view models
            var fieldViewModels = new List<SectionItemFieldViewModel>();

            // Get all fields defined for this section item (from template)
            foreach (var field in sectionItem.SectionItemFields)
            {
                // Find existing field value for this field
                var existingFieldValue = itemFieldValues.FirstOrDefault(fv => fv.SectionItemFieldId == field.Id);

                var fieldViewModel = new SectionItemFieldViewModel
                {
                    Id = existingFieldValue?.Id ?? 0,
                    SectionItemId = sectionItem.Id,
                    FieldType = field.Type,
                    FieldKey = field.FieldKey,
                    FieldValue = existingFieldValue?.Value ?? field.DefaultValue ?? "",
                    IsTranslatable = field.IsTranslatable,
                    Translations = new List<SectionItemFieldTranslationViewModel>()
                };

                // Add field translations
                if (existingFieldValue != null && existingFieldValue.Translations.Any())
                {
                    fieldViewModel.Translations = existingFieldValue.Translations.Select(ft => new SectionItemFieldTranslationViewModel
                    {
                        Id = ft.Id,
                        SectionItemFieldId = ft.SectionItemFieldValueId,
                        LanguageId = ft.LanguageId,
                        LanguageCode = ft.Language?.Code ?? "",
                        LanguageName = ft.Language?.Name ?? "",
                        Label = ft.Value,
                        Description = ft.Value,
                        Placeholder = ft.Value
                    }).ToList();
                }
                else
                {
                    // Use field template translations as placeholders
                    fieldViewModel.Translations = field.Translations?.Select(ft => new SectionItemFieldTranslationViewModel
                    {
                        Id = 0,
                        SectionItemFieldId = 0,
                        LanguageId = ft.LanguageId,
                        LanguageCode = ft.Language?.Code ?? "",
                        LanguageName = ft.Language?.Name ?? "",
                        Label = ft.Label ?? field.FieldName,
                        Description = ft.Description ?? "",
                        Placeholder = ft.Placeholder ?? field.Placeholder ?? ""
                    }).ToList() ?? new List<SectionItemFieldTranslationViewModel>();
                }

                fieldViewModels.Add(fieldViewModel);
            }

            // Build child items recursively
            var childItems = allSectionItems.Where(si => si.ParentSectionItemId == sectionItem.Id).ToList();
            var childViewModels = new List<SectionItemViewModel>();

            foreach (var childItem in childItems)
            {
                var childViewModel = BuildSectionItemViewModelOptimized(childItem, allSectionItems, allFieldValues, sectionId);
                childViewModels.Add(childViewModel);
            }

            // Create the main view model
            var viewModel = new SectionItemViewModel
            {
                Id = sectionItem.Id,
                SectionId = sectionId,
                Type = sectionItem.Type,
                MediaType = sectionItem.MediaType,
                SortOrder = sectionItem.SortOrder,
                Status = sectionItem.Status,
                Title = sectionItem.Title,
                Description = sectionItem.Description,
                AllowReorder = sectionItem.AllowReorder,
                AllowRemove = sectionItem.AllowRemove,
                IconClass = sectionItem.IconClass,
                TemplateId = sectionItem.TemplateId,
                Fields = fieldViewModels,
                ChildItems = childViewModels.OrderBy(c => c.SortOrder).ToList(),
                Translations = sectionItem.Translations.Select(t => new SectionItemTranslationViewModel
                {
                    Id = t.Id,
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language?.Name,
                    LanguageCode = t.Language?.Code,
                    Title = t.Title,
                    Description = t.Description
                }).ToList()
            };

            return viewModel;
        }

        /// <summary>
        /// Build a single section item view model with its children recursively (Legacy)
        /// </summary>
        private SectionItemViewModel BuildSectionItemViewModel(
            SectionItemValue sectionItemValue,
            List<SectionItemValue> allSectionItemValues,
            List<SectionItemFieldValue> allFieldValues)
        {
            var sectionItem = sectionItemValue.SectionItem;

            // Get field values for this specific section item
            var itemFieldValues = allFieldValues.Where(fv => fv.SectionItemId == sectionItem.Id).ToList();

            // Build field view models
            var fieldViewModels = new List<SectionItemFieldViewModel>();

            // Get all fields defined for this section item (from template)
            foreach (var field in sectionItem.SectionItemFields)
            {
                // Find existing field value for this field
                var existingFieldValue = itemFieldValues.FirstOrDefault(fv => fv.SectionItemFieldId == field.Id);

                var fieldViewModel = new SectionItemFieldViewModel
                {
                    Id = existingFieldValue?.Id ?? 0,
                    SectionItemId = sectionItem.Id,
                    FieldType = field.Type,
                    FieldKey = field.FieldKey,
                    FieldValue = existingFieldValue?.Value ?? field.DefaultValue ?? "",
                    IsTranslatable = field.IsTranslatable,
                    Translations = new List<SectionItemFieldTranslationViewModel>()
                };

                // Add field translations
                if (existingFieldValue != null && existingFieldValue.Translations.Any())
                {
                    fieldViewModel.Translations = existingFieldValue.Translations.Select(ft => new SectionItemFieldTranslationViewModel
                    {
                        Id = ft.Id,
                        SectionItemFieldId = ft.SectionItemFieldValueId,
                        LanguageId = ft.LanguageId,
                        LanguageCode = ft.Language?.Code ?? "",
                        LanguageName = ft.Language?.Name ?? "",
                        Label = ft.Value,
                        Description = ft.Value,
                        Placeholder = ft.Value
                    }).ToList();
                }
                else
                {
                    // Use field template translations as placeholders
                    fieldViewModel.Translations = field.Translations?.Select(ft => new SectionItemFieldTranslationViewModel
                    {
                        Id = 0,
                        SectionItemFieldId = 0,
                        LanguageId = ft.LanguageId,
                        LanguageCode = ft.Language?.Code ?? "",
                        LanguageName = ft.Language?.Name ?? "",
                        Label = ft.Label ?? field.FieldName,
                        Description = ft.Description ?? "",
                        Placeholder = ft.Placeholder ?? field.Placeholder ?? ""
                    }).ToList() ?? new List<SectionItemFieldTranslationViewModel>();
                }

                fieldViewModels.Add(fieldViewModel);
            }

            // Build child items recursively
            var childItemValues = allSectionItemValues.Where(siv => siv.SectionItem.ParentSectionItemId == sectionItem.Id).ToList();
            var childViewModels = new List<SectionItemViewModel>();

            foreach (var childItemValue in childItemValues)
            {
                var childViewModel = BuildSectionItemViewModel(childItemValue, allSectionItemValues, allFieldValues);
                childViewModels.Add(childViewModel);
            }

            // Create the main view model
            var viewModel = new SectionItemViewModel
            {
                Id = sectionItem.Id,
                SectionId = sectionItemValue.SectionId,
                Type = sectionItem.Type,
                MediaType = sectionItem.MediaType,
                SortOrder = sectionItem.SortOrder,
                Status = sectionItem.Status,
                Title = sectionItem.Title,
                Description = sectionItem.Description,
                AllowReorder = sectionItem.AllowReorder,
                AllowRemove = sectionItem.AllowRemove,
                IconClass = sectionItem.IconClass,
                TemplateId = sectionItem.TemplateId,
                Fields = fieldViewModels,
                ChildItems = childViewModels.OrderBy(c => c.SortOrder).ToList(),
                Translations = sectionItem.Translations.Select(t => new SectionItemTranslationViewModel
                {
                    Id = t.Id,
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language?.Name,
                    LanguageCode = t.Language?.Code,
                    Title = t.Title,
                    Description = t.Description
                }).ToList()
            };

            return viewModel;
        }

        /// <summary>
        /// Get all child section items recursively for given root section item IDs
        /// </summary>
        private async Task<List<SectionItem>> GetAllChildSectionItemsRecursively(List<int> rootSectionItemIds)
        {
            var allSectionItems = new List<SectionItem>();
            var currentLevelIds = rootSectionItemIds.ToList();

            while (currentLevelIds.Any())
            {
                // Get section items for current level
                var currentLevelItems = await _pazarAtlasiDbContext.SectionItems
                    .Include(si => si.SectionItemFields)
                        .ThenInclude(f => f.Translations)
                    .Include(si => si.Translations)
                        .ThenInclude(t => t.Language)
                    .Where(si => currentLevelIds.Contains(si.Id) && !si.IsDeleted)
                    .ToListAsync();

                allSectionItems.AddRange(currentLevelItems);

                // Get child IDs for next level
                currentLevelIds = await _pazarAtlasiDbContext.SectionItems
                    .Where(si => currentLevelItems.Select(cli => cli.Id).Contains(si.ParentSectionItemId ?? 0) && !si.IsDeleted)
                    .Select(si => si.Id)
                    .ToListAsync();
            }

            return allSectionItems;
        }

        /// <summary>
        /// Save SectionItemValues for parent section items (not nested ones)
        /// </summary>
        private async Task SaveSectionItemValues(List<SectionItemRequest> itemRequests, int sectionId)
        {
            if (itemRequests == null || !itemRequests.Any())
                return;

            // First, remove existing SectionItemValues for this section
            var existingSectionItemValues = await _pazarAtlasiDbContext.SectionItemValues
                .Where(siv => siv.SectionId == sectionId)
                .ToListAsync();

            _pazarAtlasiDbContext.SectionItemValues.RemoveRange(existingSectionItemValues);
            await _pazarAtlasiDbContext.SaveChangesAsync();

            // Add new SectionItemValues for parent items only (not nested)
            foreach (var itemRequest in itemRequests)
            {
                // Only save parent items (items that don't have nested structure or are top-level)
                var sectionItemValue = new SectionItemValue
                {
                    SectionId = sectionId,
                    SectionItemId = itemRequest.Id,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                    Status = Status.Active
                };

                _pazarAtlasiDbContext.SectionItemValues.Add(sectionItemValue);
            }

            await _pazarAtlasiDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get template configuration as SectionItemViewModel with proper child structure
        /// Fields are only inside Items, not at template level
        /// SectionItemları çekip onların child yapısını doğru şekilde oluşturur
        /// </summary>
        public async Task<SectionItemViewModel?> GetConfigurationAsync(int templateId, string templateKey, List<LanguageViewModel> availableLanguages)
        {
            // Get the template
            var template = await _pazarAtlasiDbContext.Templates
                .FirstOrDefaultAsync(t => t.Id == templateId && t.TemplateKey == templateKey && t.IsActive);

            if (template == null)
                return null;

            // Get ALL section items that use this template (without field includes for performance)
            var allSectionItems = await _pazarAtlasiDbContext.SectionItems
                .Include(si => si.Translations)
                .Where(si => si.TemplateId == templateId && !si.IsDeleted)
                .OrderBy(si => si.SortOrder)
                .ToListAsync();

            // If no existing section items, create a default one from template fields
            if (!allSectionItems.Any())
            {
                return await CreateDefaultSectionItemFromTemplate(template, availableLanguages);
            }

            // Get all section item IDs for field query
            var sectionItemIds = allSectionItems.Select(si => si.Id).ToList();

            // Get ALL field values for these section items in a separate query
            var allFieldValues = await _pazarAtlasiDbContext.SectionItemFields
                .Include(f => f.Translations)
                .Where(fv => sectionItemIds.Contains(fv.SectionItemId) && !fv.IsDeleted)
                .ToListAsync();

            // Get root level section items (items without parent) and build hierarchy
            var rootSectionItems = allSectionItems
                .Where(si => si.ParentSectionItemId == null)
                .Select(item => MapToSectionItemViewModel(item, allSectionItems, allFieldValues, availableLanguages))
                .ToList();

            // Return the first root item as example (or create a new one based on the first existing item)
            return rootSectionItems.FirstOrDefault() ?? await CreateDefaultSectionItemFromTemplate(template, availableLanguages);
        }

        /// <summary>
        /// Create default SectionItemViewModel from template configuration
        /// </summary>
        private async Task<SectionItemViewModel> CreateDefaultSectionItemFromTemplate(Template template, List<LanguageViewModel> availableLanguages)
        {
            // Get template fields directly from template
            var fields = await _pazarAtlasiDbContext.SectionItemFields
                .Include(f => f.Translations)
                .Where(f => f.SectionItem.TemplateId == template.Id && !f.IsDeleted)
                .OrderBy(f => f.SortOrder)
                .ToListAsync();

            var viewModel = new SectionItemViewModel
            {
                Id = 0, // New item
                TemplateId = template.Id,
                TemplateKey = template.TemplateKey,
                Type = SectionItemType.None,
                MediaType = MediaType.None,
                SortOrder = 1,
                Status = Status.Active,
                AllowReorder = true,
                AllowRemove = true,
                AvailableLanguages = availableLanguages,
                Fields = fields.Select(f => MapToSectionItemFieldViewModel(f, availableLanguages)).ToList(),
                ChildItems = new List<SectionItemViewModel>(),
                Translations = new List<SectionItemTranslationViewModel>()
            };

            return viewModel;
        }

        /// <summary>
        /// Map SectionItem to SectionItemViewModel with proper child hierarchy
        /// </summary>
        private SectionItemViewModel MapToSectionItemViewModel(SectionItem sectionItem, List<SectionItem> allSectionItems, List<SectionItemField> allFields, List<LanguageViewModel> availableLanguages)
        {
            // Get child items for this section item
            var childItems = allSectionItems
                .Where(si => si.ParentSectionItemId == sectionItem.Id)
                .Select(child => MapToSectionItemViewModel(child, allSectionItems, allFields, availableLanguages))
                .ToList();

            // Get field values for this specific section item
            var itemFields = allFields.Where(fv => fv.SectionItemId == sectionItem.Id).ToList();

            return new SectionItemViewModel
            {
                Id = sectionItem.Id,
                ParentSectionItemId = sectionItem.ParentSectionItemId,
                TemplateId = sectionItem.TemplateId,
                TemplateKey = sectionItem.Template?.TemplateKey ?? "",
                Type = sectionItem.Type,
                MediaType = sectionItem.MediaType,
                SortOrder = sectionItem.SortOrder,
                Status = sectionItem.Status,
                Title = sectionItem.Title,
                Description = sectionItem.Description,
                AllowReorder = sectionItem.AllowReorder,
                AllowRemove = sectionItem.AllowRemove,
                IconClass = sectionItem.IconClass,
                AvailableLanguages = availableLanguages,
                Fields = itemFields.Select(fv => new SectionItemFieldViewModel
                {
                    Id = fv.Id,
                    SectionItemId = fv.SectionItemId,
                    FieldType = fv?.Type ?? SectionItemFieldType.Text,
                    FieldKey = fv?.FieldKey ?? "",
                    FieldValue = fv.DefaultValue,
                    IsTranslatable = fv?.IsTranslatable ?? false,
                    ShowInUI = fv?.ShowInUI ?? true,
                    Translations = fv?.Translations?.Select(ft => new SectionItemFieldTranslationViewModel
                    {
                        Id = ft.Id,
                        SectionItemFieldId = ft.SectionItemFieldId,
                        LanguageId = ft.LanguageId,
                        LanguageCode = availableLanguages.FirstOrDefault(l => l.Id == ft.LanguageId)?.Code ?? "",
                        LanguageName = availableLanguages.FirstOrDefault(l => l.Id == ft.LanguageId)?.Name ?? "",
                        Label = ft.Label,
                        Description = ft.Description,
                        Placeholder = ft.Placeholder
                    }).ToList() ?? new List<SectionItemFieldTranslationViewModel>()
                }).ToList(),
                ChildItems = childItems, // Recursive child items
                Translations = sectionItem.Translations?.Select(sit => new SectionItemTranslationViewModel
                {
                    Id = sit.Id,
                    LanguageId = sit.LanguageId,
                    LanguageName = availableLanguages.FirstOrDefault(l => l.Id == sit.LanguageId)?.Name ?? "",
                    LanguageCode = availableLanguages.FirstOrDefault(l => l.Id == sit.LanguageId)?.Code ?? "",
                    Title = sit.Title,
                    Description = sit.Description
                }).ToList() ?? new List<SectionItemTranslationViewModel>()
            };
        }

        /// <summary>
        /// Map SectionItemField to SectionItemFieldViewModel
        /// </summary>
        private SectionItemFieldViewModel MapToSectionItemFieldViewModel(SectionItemField field, List<LanguageViewModel> availableLanguages)
        {
            return new SectionItemFieldViewModel
            {
                Id = 0, // New field value
                SectionItemId = 0, // Will be set when item is saved
                FieldType = field.Type,
                FieldKey = field.FieldKey,
                FieldValue = field.DefaultValue ?? "",
                IsTranslatable = field.IsTranslatable,
                Translations = field.Translations?.Select(ft => new SectionItemFieldTranslationViewModel
                {
                    Id = ft.Id,
                    SectionItemFieldId = ft.SectionItemFieldId,
                    LanguageId = ft.LanguageId,
                    LanguageCode = availableLanguages.FirstOrDefault(l => l.Id == ft.LanguageId)?.Code ?? "",
                    LanguageName = availableLanguages.FirstOrDefault(l => l.Id == ft.LanguageId)?.Name ?? "",
                    Label = ft.Label ?? field.FieldName,
                    Description = ft.Description ?? "",
                    Placeholder = ft.Placeholder ?? field.Placeholder ?? ""
                }).ToList() ?? new List<SectionItemFieldTranslationViewModel>(),
            };
        }

        /// <summary>
        /// Update section item fields and their translations
        /// </summary>
        private async Task UpdateSectionItemFields(SectionItem sectionItem, List<SectionItemFieldUpdateDto> fieldDtos)
        {
            if (fieldDtos == null || !fieldDtos.Any())
                return;

            // Remove existing fields and their translations
            var existingFields = await _pazarAtlasiDbContext.SectionItemFields
                .Include(f => f.Translations)
                .Where(f => f.SectionItemId == sectionItem.Id)
                .ToListAsync();

            foreach (var existingField in existingFields)
            {
                _pazarAtlasiDbContext.SectionItemFieldTranslations.RemoveRange(existingField.Translations);
                _pazarAtlasiDbContext.SectionItemFields.Remove(existingField);
            }

            // Add new fields
            foreach (var fieldDto in fieldDtos.Where(f => !string.IsNullOrEmpty(f.FieldKey)))
            {
                var newField = new SectionItemField
                {
                    SectionItemId = sectionItem.Id,
                    FieldKey = fieldDto.FieldKey,
                    FieldName = fieldDto.FieldName,
                    Type = fieldDto.Type,
                    Required = fieldDto.Required,
                    MaxLength = fieldDto.MaxLength,
                    Placeholder = fieldDto.Placeholder,
                    DefaultValue = fieldDto.DefaultValue,
                    IsTranslatable = fieldDto.IsTranslatable,
                    ShowInUI = fieldDto.ShowInUI,
                    OptionsJson = fieldDto.OptionsJson,
                    AcceptedFileTypes = fieldDto.AcceptedFileTypes,
                    MaxFileSize = fieldDto.MaxFileSize,
                    SortOrder = fieldDto.SortOrder,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                _pazarAtlasiDbContext.SectionItemFields.Add(newField);
                await _pazarAtlasiDbContext.SaveChangesAsync(); // Save to get the ID

                // Add field translations if the field is translatable
                if (fieldDto.IsTranslatable && fieldDto.Translations != null && fieldDto.Translations.Any())
                {
                    foreach (var translationDto in fieldDto.Translations.Where(t =>
                        !string.IsNullOrEmpty(t.Label) ||
                        !string.IsNullOrEmpty(t.Description) ||
                        !string.IsNullOrEmpty(t.Placeholder)))
                    {
                        var fieldTranslation = new SectionItemFieldTranslation
                        {
                            SectionItemFieldId = newField.Id,
                            LanguageId = translationDto.LanguageId,
                            Label = translationDto.Label ?? "",
                            Description = translationDto.Description,
                            Placeholder = translationDto.Placeholder,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        };

                        _pazarAtlasiDbContext.SectionItemFieldTranslations.Add(fieldTranslation);
                    }
                }
            }
        }

        /// <summary>
        /// Process field value based on field type
        /// </summary>
        private string ProcessFieldValue(string fieldValue, SectionItemFieldType fieldType)
        {
            if (string.IsNullOrEmpty(fieldValue))
                return string.Empty;

            switch (fieldType)
            {
                case SectionItemFieldType.Image:
                case SectionItemFieldType.Video:
                case SectionItemFieldType.FileUpload:
                    // For media fields, validate URL format and ensure it's a valid path
                    if (Uri.TryCreate(fieldValue, UriKind.RelativeOrAbsolute, out Uri uri))
                    {
                        // If it's a relative path (uploaded file), ensure it starts with /
                        if (!uri.IsAbsoluteUri && !fieldValue.StartsWith("/"))
                        {
                            return "/" + fieldValue.TrimStart('/');
                        }
                        return fieldValue;
                    }
                    // If not a valid URI, return empty (invalid media URL)
                    return string.Empty;

                case SectionItemFieldType.URL:
                    // For URL fields, validate URL format
                    if (Uri.TryCreate(fieldValue, UriKind.Absolute, out Uri urlUri))
                    {
                        return fieldValue;
                    }
                    // Try to add http:// if missing
                    if (Uri.TryCreate("http://" + fieldValue, UriKind.Absolute, out Uri httpUri))
                    {
                        return "http://" + fieldValue;
                    }
                    return fieldValue; // Return as-is if can't validate

                case SectionItemFieldType.Boolean:
                case SectionItemFieldType.Checkbox:
                    // Normalize boolean values
                    var lowerValue = fieldValue.ToLower();
                    return (lowerValue == "true" || lowerValue == "1" || lowerValue == "on") ? "true" : "false";

                case SectionItemFieldType.Number:
                    // Validate and normalize number format
                    if (decimal.TryParse(fieldValue, out decimal number))
                    {
                        return number.ToString();
                    }
                    return "0"; // Default to 0 for invalid numbers

                case SectionItemFieldType.Color:
                    // Validate hex color format
                    if (fieldValue.StartsWith("#") && (fieldValue.Length == 4 || fieldValue.Length == 7))
                    {
                        return fieldValue;
                    }
                    // Try to add # if missing
                    if (fieldValue.Length == 3 || fieldValue.Length == 6)
                    {
                        return "#" + fieldValue;
                    }
                    return "#000000"; // Default to black for invalid colors

                case SectionItemFieldType.Text:
                case SectionItemFieldType.TextArea:
                case SectionItemFieldType.Title:
                case SectionItemFieldType.Description:
                case SectionItemFieldType.Paragraph:
                case SectionItemFieldType.RichText:
                case SectionItemFieldType.Dropdown:
                case SectionItemFieldType.MultiSelect:
                case SectionItemFieldType.Icon:
                default:
                    // For text fields, just trim and return
                    return fieldValue.Trim();
            }
        }

        #endregion Helper Methods

        #region Template Helper Methods

        /// <summary>
        /// Reload TemplateCreateViewModel data for error scenarios
        /// </summary>
        private async Task ReloadTemplateCreateViewModelData(TemplateCreateViewModel model)
        {
            var languages = await _pazarAtlasiDbContext.Languages
                .Where(l => !l.IsDeleted)
                .OrderByDescending(l => l.IsDefault) // Default language first
                .ThenBy(l => l.Name)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault
                })
                .ToListAsync();

            model.AvailableLanguages = languages;
            model.AvailableSectionTypes = GetAvailableSectionTypes(model.SelectedSectionTypes);

            // Ensure translations exist for all languages
            foreach (var language in languages)
            {
                if (!model.Translations.Any(t => t.LanguageId == language.Id))
                {
                    model.Translations.Add(new TemplateTranslationCreateViewModel
                    {
                        LanguageId = language.Id,
                        LanguageName = language.Name,
                        LanguageCode = language.Code,
                        IsDefault = language.IsDefault
                    });
                }
                else
                {
                    var translation = model.Translations.First(t => t.LanguageId == language.Id);
                    translation.LanguageName = language.Name;
                    translation.LanguageCode = language.Code;
                    translation.IsDefault = language.IsDefault;
                }
            }
        }

        /// <summary>
        /// Reload TemplateEditViewModel data for error scenarios
        /// </summary>
        private async Task ReloadTemplateEditViewModelData(TemplateEditViewModel model)
        {
            var languages = await _pazarAtlasiDbContext.Languages
                .Where(l => !l.IsDeleted)
                .OrderBy(l => l.Name)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault
                })
                .ToListAsync();

            model.AvailableLanguages = languages;
            model.AvailableSectionTypes = GetAvailableSectionTypes(model.SelectedSectionTypes);

            // Update language information in translations
            foreach (var translation in model.Translations)
            {
                var language = languages.FirstOrDefault(l => l.Id == translation.LanguageId);
                if (language != null)
                {
                    translation.LanguageName = language.Name;
                    translation.LanguageCode = language.Code;
                    translation.IsDefault = language.IsDefault;
                }
            }
        }

        #endregion Template Helper Methods

        #region Page Hierarchy Helper Methods

        /// <summary>
        /// Build hierarchical page structure from flat list
        /// </summary>
        private List<PageListViewModel> BuildPageHierarchy(List<PageListViewModel> allPages)
        {
            var pageDictionary = allPages.ToDictionary(p => p.Id);
            var rootPages = new List<PageListViewModel>();

            foreach (var page in allPages)
            {
                if (page.ParentPageId.HasValue && pageDictionary.ContainsKey(page.ParentPageId.Value))
                {
                    var parent = pageDictionary[page.ParentPageId.Value];
                    parent.ChildPages.Add(page);
                    parent.HasChildren = true;
                }
                else
                {
                    rootPages.Add(page);
                }
            }

            return rootPages.OrderBy(p => p.Name).ToList();
        }

        /// <summary>
        /// Flatten hierarchical page structure for display with proper indentation
        /// </summary>
        private void FlattenPageHierarchy(List<PageListViewModel> pages, List<PageListViewModel> flatList, int level)
        {
            foreach (var page in pages.OrderBy(p => p.Name))
            {
                page.Level = level;
                flatList.Add(page);

                if (page.ChildPages.Any())
                {
                    FlattenPageHierarchy(page.ChildPages, flatList, level + 1);
                }
            }
        }

        /// <summary>
        /// Get available parent pages for page edit (excluding current page and its descendants)
        /// </summary>
        private async Task<List<AvailableParentPageViewModel>> GetAvailableParentPagesAsync(int? currentPageId = null)
        {
            var allPages = await _pazarAtlasiDbContext.Pages
                .Where(p => p.Status == Status.Active)
                .OrderBy(p => p.ParentPageId ?? 0)
                .ThenBy(p => p.Name)
                .Select(p => new AvailableParentPageViewModel
                {
                    Id = p.Id,
                    Name = p.Name ?? "",
                    Code = p.Code ?? "",
                    PageType = p.PageType
                })
                .ToListAsync();

            // Build hierarchy
            var hierarchicalPages = BuildAvailableParentHierarchy(allPages);

            // Flatten with levels
            var flattenedPages = new List<AvailableParentPageViewModel>();
            FlattenAvailableParentHierarchy(hierarchicalPages, flattenedPages, 0);

            // Exclude current page and its descendants if editing
            if (currentPageId.HasValue)
            {
                var excludeIds = GetDescendantPageIds(currentPageId.Value, allPages);
                excludeIds.Add(currentPageId.Value);
                flattenedPages = flattenedPages.Where(p => !excludeIds.Contains(p.Id)).ToList();
            }

            return flattenedPages;
        }

        /// <summary>
        /// Build hierarchy for available parent pages
        /// </summary>
        private List<AvailableParentPageViewModel> BuildAvailableParentHierarchy(List<AvailableParentPageViewModel> allPages)
        {
            // This is a simplified version - in real implementation you'd need ParentPageId in the ViewModel
            // For now, return flat list ordered by name
            return allPages.OrderBy(p => p.Name).ToList();
        }

        /// <summary>
        /// Flatten available parent hierarchy
        /// </summary>
        private void FlattenAvailableParentHierarchy(List<AvailableParentPageViewModel> pages, List<AvailableParentPageViewModel> flatList, int level)
        {
            foreach (var page in pages)
            {
                page.Level = level;
                flatList.Add(page);
            }
        }

        /// <summary>
        /// Get all descendant page IDs for a given page
        /// </summary>
        private List<int> GetDescendantPageIds(int pageId, List<AvailableParentPageViewModel> allPages)
        {
            var descendants = new List<int>();
            // This would need to be implemented with proper parent-child relationships
            // For now, return empty list
            return descendants;
        }

        #endregion Page Hierarchy Helper Methods

        /// <summary>
        /// Get display name for SectionType enum
        /// </summary>
        /// 
        private string GetSectionTypeDisplayName(SectionType sectionType)
        {
            return sectionType switch
            {
                SectionType.Navbar => "Navigation Bar",
                SectionType.Header => "Header",
                SectionType.Hero => "Hero Section",
                SectionType.Catalog => "Catalog",
                SectionType.Favorite => "Favorites",
                SectionType.Featured => "Featured Content",
                SectionType.Newsletter => "Newsletter",
                SectionType.ContentBlock => "Content Block",
                SectionType.Contact => "Contact",
                SectionType.Footer => "Footer",
                SectionType.Sidebar => "Sidebar",
                SectionType.MainContent => "Main Content",
                SectionType.RelatedContent => "Related Content",
                SectionType.Advertisement => "Advertisement",
                SectionType.Search => "Search",
                SectionType.ContactForm => "Contact Form",
                SectionType.WhyUs => "Why Choose Us",
                SectionType.SocialMediaLinks => "Social Media Links",
                SectionType.Testimonials => "Testimonials",
                SectionType.CallToAction => "Call to Action",
                SectionType.Breadcrumbs => "Breadcrumbs",
                SectionType.Pagination => "Pagination",
                SectionType.Map => "Map",
                SectionType.Gallery => "Gallery",
                _ => sectionType.ToString()
            };
        }

        /// <summary>
        /// Get available section types with selection status
        /// </summary>
        private List<SectionTypeViewModel> GetAvailableSectionTypes(List<SectionType> selectedTypes)
        {
            return Enum.GetValues<SectionType>()
                .Where(st => st != SectionType.None)
                .Select(st => new SectionTypeViewModel
                {
                    Value = st,
                    Name = GetSectionTypeDisplayName(st),
                    IsSelected = selectedTypes.Contains(st)
                })
                .OrderBy(st => st.Name)
                .ToList();
        }

    }
}