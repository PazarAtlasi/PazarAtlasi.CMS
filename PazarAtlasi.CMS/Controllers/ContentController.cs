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

namespace PazarAtlasi.CMS.Controllers
{
    public class ContentController : Controller
    {
        private readonly PazarAtlasiDbContext _pazarAtlasiDbContext;
        private readonly IMediaUploadService _mediaUploadService;
        private readonly ITemplateConfigurationProvider _templateConfigurationProvider;

        public ContentController(
            PazarAtlasiDbContext pazarAtlasiDbContext,
            IMediaUploadService mediaUploadService,
            ITemplateConfigurationProvider templateConfigurationProvider)
        {
            _pazarAtlasiDbContext = pazarAtlasiDbContext;
            _mediaUploadService = mediaUploadService;
            _templateConfigurationProvider = templateConfigurationProvider;
        }

        /// <summary>
        /// Main view for menu management
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Pages list with pagination
        /// </summary>
        public async Task<IActionResult> Pages(int page = 1, int pageSize = 10)
        {
            var totalCount = await _pazarAtlasiDbContext.Pages.CountAsync();

            var pages = await _pazarAtlasiDbContext.Pages
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PageListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    PageType = p.PageType,
                    Description = p.Description,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .ToListAsync();

            var model = new PageListResponse
            {
                Pages = pages,
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
                    .ThenInclude(s => s.Section)
                    .ThenInclude(s => s.SectionItems.OrderBy(si => si.SortOrder))
                        .ThenInclude(si => si.Fields)
                        .ThenInclude(f => f.Translations)
                .Include(p => p.PageSections)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(s => s.SectionItems)
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
                Sections = page.PageSections.Select(t => t.Section).Select(s => new SectionViewModel
                {
                    Id = s.Id,
                    Type = s.Type,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = s.SectionItems.Select(si => new SectionItemViewModel
                    {
                        Id = si.Id,
                        Type = si.Type,
                        SortOrder = si.SortOrder,
                        Status = si.Status,
                        Fields = si.Fields.Select(f => new SectionItemFieldViewModel
                        {
                            Id = f.Id,
                            SectionItemId = f.SectionItemId,
                            FieldType = f.FieldType,
                            FieldKey = f.FieldKey,
                            FieldValue = f.FieldValue,
                            Translations = f.Translations.Select(ft => new SectionItemFieldTranslationViewModel
                            {
                                Id = ft.Id,
                                SectionItemFieldId = ft.SectionItemFieldId,
                                LanguageId = ft.LanguageId,
                                //Name = ft.Name,
                                //Description = ft.Description
                            }).ToList()
                        }).ToList(),
                        Translations = si.Translations.Select(sit => new SectionItemTranslationViewModel
                        {
                            Id = sit.Id,
                            LanguageId = sit.LanguageId,
                            Name = sit.Name,
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

                    // Tüm section item'larını tek query ile yükle (daha performanslı)
                    if (page.PageSections.Select(t => t.Section).Any())
                    {
                        var sectionIds = page.PageSections.Select(t => t.Section).Select(s => s.Id).ToList();
                        var allSectionItems = await _pazarAtlasiDbContext.SectionItems
                            .Include(si => si.Translations)
                            .Include(si => si.Fields)
                                .ThenInclude(f => f.Translations)
                            .Where(si => sectionIds.Contains(si.SectionId))
                            .OrderBy(si => si.SortOrder)
                            .ToListAsync();

                        // Section item'larını ilgili section'lara dağıt
                        foreach (var section in page.PageSections.Select(t => t.Section))
                        {
                            section.SectionItems = allSectionItems
                                .Where(si => si.SectionId == section.Id)
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

                var model = MapToPageEditViewModel(page, languages);
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
                        .ThenInclude(s => s.SectionItems)
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
                    .Include(s => s.SectionItems)
                        .ThenInclude(si => si.Translations)
                    .Include(s => s.Translations)
                    .FirstOrDefaultAsync(s => s.Id == sectionId);

                if (section == null)
                {
                    return Json(new { success = false, message = "Section not found." });
                }

                // Remove related data
                _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(
                    section.SectionItems.SelectMany(si => si.Translations));
                _pazarAtlasiDbContext.SectionItems.RemoveRange(section.SectionItems);
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
                            Name = t.Name,
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

                    var sectionItem = new SectionItem
                    {
                        Id = 0,
                        SectionId = request.SectionId,
                        Type = request.Type,
                        MediaType = request.MediaType,
                        SortOrder = request.SortOrder,
                        Status = request.Status,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    };

                    _pazarAtlasiDbContext.SectionItems.Add(sectionItem);
                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Add translations
                    if (request.Translations != null && request.Translations.Any())
                    {
                        var translations = request.Translations.Select(t => new SectionItemTranslation
                        {
                            Id = 0,
                            SectionItemId = sectionItem.Id,
                            LanguageId = t.LanguageId,
                            Name = t.Name,
                            Title = t.Title,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                        _pazarAtlasiDbContext.SectionItemTranslations.AddRange(translations);
                        await _pazarAtlasiDbContext.SaveChangesAsync();
                    }

                    return Json(new { success = true, message = "Section item created successfully.", data = new SectionItemSaveResponseDto { Id = sectionItem.Id, Message = "Created successfully" } });
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
        public async Task<IActionResult> GetSectionModal(int id, int pageId)
        {
            try
            {
                SectionViewModel model;

                if (id > 0)
                {
                    var pageSection = await _pazarAtlasiDbContext.PageSections
                        .Include(ps => ps.Section)
                        .ThenInclude(s => s.SectionItems)
                        .ThenInclude(si => si.Fields)
                        .ThenInclude(f => f.Translations)
                        .Include(ps => ps.Section)
                        .ThenInclude(s => s.SectionItems)
                        .ThenInclude(si => si.Translations)
                        .ThenInclude(t => t.Language)
                        .FirstOrDefaultAsync(ps => ps.SectionId == id && ps.PageId == pageId);

                    var section = pageSection?.Section;

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    model = new SectionViewModel
                    {
                        Id = section.Id,
                        Type = section.Type,
                        Attributes = section.Attributes,
                        SortOrder = section.SortOrder,
                        Configure = section.Configure,
                        Status = section.Status,
                        SectionItems = section.SectionItems.Select(si => new SectionItemViewModel
                        {
                            Id = si.Id,
                            SectionId = si.SectionId,
                            Type = si.Type,
                            MediaType = si.MediaType,
                            SortOrder = si.SortOrder,
                            Status = si.Status,
                            Fields = si.Fields.Select(f => new SectionItemFieldViewModel
                            {
                                Id = f.Id,
                                SectionItemId = f.SectionItemId,
                                FieldType = f.FieldType,
                                FieldKey = f.FieldKey,
                                FieldValue = f.FieldValue,
                                Translations = f.Translations.Select(ft => new SectionItemFieldTranslationViewModel
                                {
                                    Id = ft.Id,
                                    SectionItemFieldId = ft.SectionItemFieldId,
                                    LanguageId = ft.LanguageId,
                                    //Name = ft.Name,
                                    //Description = ft.Description
                                }).ToList()
                            }).ToList(),
                            Translations = si.Translations.Select(t => new SectionItemTranslationViewModel
                            {
                                Id = t.Id,
                                LanguageId = t.LanguageId,
                                LanguageName = t.Language?.Name,
                                LanguageCode = t.Language?.Code,
                                Name = t.Name,
                                Title = t.Title,
                                Description = t.Description
                            }).ToList()
                        }).ToList(),
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
                        name = st.Template.Name,
                        templateType = st.Template.TemplateType.ToString()
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

                // Get configuration from database via TemplateConfigurationProvider
                var configuration = await _templateConfigurationProvider.GetConfigurationAsync(template.Id, template.TemplateKey);
                if (configuration == null || configuration.SectionItemSetting == null)
                {
                    return Content("<div class='bg-red-50 border border-red-200 rounded-lg p-4'><p class='text-red-600'>Template configuration not found.</p></div>", "text/html");
                }

                // Get available languages
                var availableLanguages = await _pazarAtlasiDbContext.Languages
                    .Where(l => !l.IsDeleted)
                    .Select(l => new LanguageViewModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Code = l.Code,
                        IsDefault = l.IsDefault
                    })
                    .OrderByDescending(l => l.IsDefault)
                    .ThenBy(l => l.Name)
                    .ToListAsync();

                ViewBag.AvailableLanguages = availableLanguages;

                // Get the first item configuration (we'll create one item from this template's first config)
                var firstItemConfig = configuration.SectionItemSetting;

                // Create a single item with a temporary ID (negative number to indicate it's a new/temp item)
                var item = CreateDefaultSectionItem(firstItemConfig, sectionId, currentCount + 1, templateId);

                // Set ViewBag for the partial view
                item.SectionItemConfiguration = firstItemConfig;

                return PartialView("~/Views/Content/_SectionItemCard.cshtml", item);
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
                .Include(s => s.SectionItems)
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
                    ItemsCount = s.SectionItems.Count,
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
                .Include(s => s.SectionItems.OrderBy(si => si.SortOrder))
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
                SectionItems = section.SectionItems.Select(si => new SectionItemDetailsViewModel
                {
                    Id = si.Id,
                    Type = si.Type,
                    MediaType = si.MediaType,
                    SortOrder = si.SortOrder,
                    Title = si.Translations.FirstOrDefault()?.Title,
                    Description = si.Translations.FirstOrDefault()?.Description
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
                if (request.Id > 0)
                {
                    // Update existing section
                    var section = await _pazarAtlasiDbContext.Sections
                        .Include(s => s.SectionItems)
                            .ThenInclude(si => si.Translations)
                        .Include(s => s.SectionItems)
                            .ThenInclude(si => si.Fields)
                                .ThenInclude(ni => ni.Translations)
                        .Include(s => s.Translations)
                        .FirstOrDefaultAsync(s => s.Id == request.Id);

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    // Update section properties
                    section.Type = request.Type;
                    section.Attributes = request.Attributes;
                    section.Configure = request.Configure;
                    section.Status = request.Status;
                    section.UpdatedAt = DateTime.UtcNow;

                    // Remove existing items and nested items
                    foreach (var existingItem in section.SectionItems.ToList())
                    {
                        // Remove nested items and their translations
                        foreach (var nestedItem in existingItem.Fields.ToList())
                        {
                            //_pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(nestedItem.Translations);
                            //_pazarAtlasiDbContext.SectionItems.Remove(nestedItem);
                        }

                        // Remove item translations
                        _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(existingItem.Translations);
                        _pazarAtlasiDbContext.SectionItems.Remove(existingItem);
                    }

                    // Add new items
                    await ProcessSectionItems(request.SectionItems, section.Id);

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
                        Attributes = request.Attributes ?? "{}",
                        SortOrder = request.SortOrder,
                        Configure = request.Configure ?? "{}",
                        Status = request.Status,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    };

                    _pazarAtlasiDbContext.Sections.Add(newSection);
                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Add section items
                    await ProcessSectionItems(request.SectionItems, newSection.Id);

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

                    return Json(new { success = true, message = "Section created successfully.", sectionId = newSection.Id });
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
                    .Include(s => s.SectionItems)
                    .Include(s => s.Translations)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (section == null)
                {
                    return Json(new { success = false, message = "Section not found." });
                }

                // Remove related data
                _pazarAtlasiDbContext.SectionItems.RemoveRange(section.SectionItems);
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
                        TemplateType = s.SectionTemplates.FirstOrDefault() != null ? s.SectionTemplates.FirstOrDefault()!.Template.TemplateType.ToString() : "Default",
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
                    .Include(s => s.SectionItems)
                        .ThenInclude(si => si.Translations)
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

                // Copy section items
                foreach (var item in originalSection.SectionItems)
                {
                    var newItem = new Domain.Entities.Content.SectionItem
                    {
                        SectionId = newSection.Id,
                        Type = item.Type,
                        MediaType = item.MediaType,
                        LinkedPageId = item.LinkedPageId,
                        SortOrder = item.SortOrder,
                        Status = item.Status
                    };

                    _pazarAtlasiDbContext.SectionItems.Add(newItem);
                    await _pazarAtlasiDbContext.SaveChangesAsync();

                    // Copy item translations
                    foreach (var itemTranslation in item.Translations)
                    {
                        var newItemTranslation = new Domain.Entities.Content.SectionItemTranslation
                        {
                            SectionItemId = newItem.Id,
                            LanguageId = itemTranslation.LanguageId,
                            Name = itemTranslation.Name,
                            Title = itemTranslation.Title,
                            Description = itemTranslation.Description
                        };
                        _pazarAtlasiDbContext.SectionItemTranslations.Add(newItemTranslation);
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
                Fields = si.Fields?.Select(f => new SectionItemFieldEditViewModel
                {
                    Id = f.Id,
                    SectionItemId = f.SectionItemId,
                    FieldType = f.FieldType,
                    FieldKey = f.FieldKey,
                    FieldValue = f.FieldValue,
                    Translations = f.Translations?.Select(ft => new SectionItemFieldTranslationEditViewModel
                    {
                        Id = ft.Id,
                        SectionItemFieldId = ft.SectionItemFieldId,
                        LanguageId = ft.LanguageId,
                        FieldValue = ft.Name // SectionItemFieldTranslation uses Name property for field value
                    }).ToList() ?? new List<SectionItemFieldTranslationEditViewModel>()
                }).ToList() ?? new List<SectionItemFieldEditViewModel>(),
                Translations = si.Translations?.Select(sit => new SectionItemTranslationEditViewModel
                {
                    Id = sit.Id,
                    LanguageId = sit.LanguageId,
                    Name = sit.Name,
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
        /// NEW: Helper method to create default section item from SectionItemConfiguration (recursive)
        /// </summary>
        private SectionItemViewModel CreateDefaultSectionItem(SectionItemSettingDto itemConfig, int sectionId, int sortOrder, int templateId)
        {
            var item = new SectionItemViewModel
            {
                Id = 0,
                SectionId = sectionId,
                TemplateId = templateId, // This will be used for section items, not sections
                SortOrder = sortOrder,
                Type = itemConfig.ItemType,
                Status = Status.Active,
                Fields = new List<SectionItemFieldViewModel>(),
                ChildItems = new List<SectionItemViewModel>()
            };

            // Add default field values from field configuration
            if (itemConfig.Fields != null)
            {
                foreach (var field in itemConfig.Fields)
                {
                    var fieldViewModel = new SectionItemFieldViewModel
                    {
                        Id = 0,
                        SectionItemId = 0,
                        FieldKey = field.FieldKey,
                        FieldType = field.Type,
                        FieldValue = field.DefaultValue ?? string.Empty,
                        Translations = new List<SectionItemFieldTranslationViewModel>()
                    };
                    item.Fields.Add(fieldViewModel);
                }
            }

            // NEW: Recursively create nested items if configured
            // SectionItemConfiguration can have nested SectionItems (recursive structure)
            if (itemConfig.ChildSectionItemSettings != null && itemConfig.ChildSectionItemSettings.Any())
            {
                foreach (var nestedConfig in itemConfig.ChildSectionItemSettings)
                {
                    // Recursive call to create nested items
                    var nestedItem = CreateDefaultSectionItem(nestedConfig, sectionId, sortOrder, templateId);
                    item.ChildItems.Add(nestedItem);
                }
            }

            return item;
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
                Console.WriteLine($"Item type: {itemRequest.Type}");
                Console.WriteLine($"Item templateId: {itemRequest.TemplateId}");
                Console.WriteLine($"Item fields count: {itemRequest.Fields?.Count ?? 0}");
                Console.WriteLine($"Item translations count: {itemRequest.Translations?.Count ?? 0}");
                Console.WriteLine($"Nested items count: {itemRequest.NestedItems?.Count ?? 0}");

                var newItem = new SectionItem
                {
                    SectionId = sectionId,
                    ParentSectionItemId = parentItemId, // Set parent relationship
                    TemplateId = itemRequest.TemplateId,
                    Type = itemRequest.Type,
                    MediaType = itemRequest.MediaType,
                    SortOrder = itemRequest.SortOrder,
                    Status = itemRequest.Status,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                try
                {

                    _pazarAtlasiDbContext.SectionItems.Add(newItem);
                    await _pazarAtlasiDbContext.SaveChangesAsync(); // Save to get ID
                }
                catch (Exception ex)
                {

                }

                Console.WriteLine($"Created item with ID: {newItem.Id}");

                // Process fields (both translatable and non-translatable)
                if (itemRequest.Fields != null && itemRequest.Fields.Any())
                {
                    foreach (var fieldRequest in itemRequest.Fields)
                    {
                        var fieldType = fieldRequest.FieldType;

                        // Create the field
                        var field = new SectionItemField
                        {
                            SectionItemId = newItem.Id,
                            FieldType = fieldType,
                            FieldKey = fieldRequest.FieldKey,
                            FieldValue = fieldRequest.FieldValue ?? string.Empty,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        };

                        _pazarAtlasiDbContext.SectionItemFields.Add(field);
                        await _pazarAtlasiDbContext.SaveChangesAsync(); // Save to get field ID

                        // Process field translations if they exist
                        if (fieldRequest.Translations != null && fieldRequest.Translations.Any())
                        {
                            var fieldTranslations = fieldRequest.Translations.Select(t => new SectionItemFieldTranslation
                            {
                                SectionItemFieldId = field.Id,
                                LanguageId = t.LanguageId,
                                Name = t.Value ?? string.Empty, // Use Value instead of Name
                                Description = string.Empty,
                                CreatedAt = DateTime.UtcNow,
                                IsDeleted = false
                            }).ToList();

                            _pazarAtlasiDbContext.SectionItemFieldTranslations.AddRange(fieldTranslations);
                        }
                    }

                    await _pazarAtlasiDbContext.SaveChangesAsync();
                    Console.WriteLine($"Added {itemRequest.Fields.Count} fields for item {newItem.Id}");
                }

                // Process nested items recursively
                if (itemRequest.NestedItems != null && itemRequest.NestedItems.Any())
                {
                    Console.WriteLine($"Processing {itemRequest.NestedItems.Count} nested items for parent {newItem.Id}");
                    await ProcessSectionItems(itemRequest.NestedItems, sectionId, newItem.Id);
                }
            }
        }

        private PageEditViewModel MapToPageEditViewModel(Page page, List<LanguageViewModel> languages)
        {
            return new PageEditViewModel
            {
                Id = page.Id,
                Name = page.Name,
                Code = page.Code,
                PageType = page.PageType,
                Description = page.Description,
                Status = page.Status,
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
                Sections = page.PageSections.Select(t => t.Section).Select(s => new SectionEditViewModel
                {
                    Id = s.Id,
                    Type = s.Type,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = MapSectionItemsToViewModel(s.SectionItems.ToList()),
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

        #endregion Helper Methods
    }
}