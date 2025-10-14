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
        /// Menu items management view
        /// </summary>
        public IActionResult MenuItems()
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
                .Include(p => p.Sections.OrderBy(s => s.SortOrder))
                    .ThenInclude(s => s.SectionItems.OrderBy(si => si.SortOrder))
                        .ThenInclude(si => si.Translations)
                .Include(p => p.Sections)
                    .ThenInclude(s => s.Translations)
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
                Sections = page.Sections.Select(s => new SectionViewModel
                {
                    Id = s.Id,
                    Type = s.Type,
                    SectionTemplateType = s.SectionTemplateType,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = s.SectionItems.Select(si => new SectionItemViewModel
                    {
                        Id = si.Id,
                        Type = si.Type,
                        PictureUrl = si.PictureUrl,
                        RedirectUrl = si.RedirectUrl,
                        Icon = si.Icon,
                        SortOrder = si.SortOrder,
                        Status = si.Status,
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
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.PageSEOParameter)
                    .Include(p => p.Sections.OrderBy(s => s.SortOrder))
                        .ThenInclude(s => s.SectionItems.OrderBy(si => si.SortOrder))
                            .ThenInclude(si => si.Translations)
                    .Include(p => p.Sections)
                        .ThenInclude(s => s.Translations)
                    .Include(p => p.PageTranslations)
                        .ThenInclude(pt => pt.Language)
                    .FirstOrDefaultAsync(p => p.Id == id);

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
                    .Include(p => p.Sections)
                        .ThenInclude(s => s.SectionItems)
                            .ThenInclude(si => si.Translations)
                    .Include(p => p.Sections)
                        .ThenInclude(s => s.Translations)
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

        #region Helper Methods

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
                Sections = page.Sections.Select(s => new SectionEditViewModel
                {
                    Id = s.Id,
                    Type = s.Type,
                    SectionTemplateType = s.SectionTemplateType,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = s.SectionItems.Select(si => new SectionItemEditViewModel
                    {
                        Id = si.Id,
                        Type = si.Type,
                        MediaType = si.MediaType,
                        PictureUrl = si.PictureUrl,
                        VideoUrl = si.VideoUrl,
                        RedirectUrl = si.RedirectUrl,
                        Icon = si.Icon,
                        SortOrder = si.SortOrder,
                        MediaAttributes = si.MediaAttributes,
                        Status = si.Status,
                        Translations = si.Translations.Select(sit => new SectionItemTranslationEditViewModel
                        {
                            Id = sit.Id,
                            LanguageId = sit.LanguageId,
                            Name = sit.Name,
                            Title = sit.Title,
                            Description = sit.Description
                        }).ToList()
                    }).ToList(),
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

        /// <summary>
        /// Add new section to page
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddSection(int pageId, string sectionType, string SectionTemplateType)
        {
            try
            {
                var page = await _pazarAtlasiDbContext.Pages
                    .Include(p => p.Sections)
                    .FirstOrDefaultAsync(p => p.Id == pageId);

                if (page == null)
                {
                    return Json(new { success = false, message = "Page not found." });
                }

                // Get next sort order
                var maxSortOrder = page.Sections.Any() ? page.Sections.Max(s => s.SortOrder) : 0;

                var newSection = new Section
                {
                    Id = 0, // EF will generate
                    PageId = pageId,
                    Type = Enum.TryParse<PazarAtlasi.CMS.Domain.Common.SectionType>(sectionType, out var parsedSectionType) 
                        ? parsedSectionType 
                        : PazarAtlasi.CMS.Domain.Common.SectionType.None,
                    SectionTemplateType = Enum.TryParse<PazarAtlasi.CMS.Domain.Common.SectionTemplateType>(SectionTemplateType, out var parsedSectionTemplateType) 
                        ? parsedSectionTemplateType 
                        : PazarAtlasi.CMS.Domain.Common.SectionTemplateType.Default,
                    SortOrder = maxSortOrder + 1,
                    Status = PazarAtlasi.CMS.Domain.Common.Status.Active,
                    Configure = "{}",
                    Attributes = "{}"
                };

                _pazarAtlasiDbContext.Sections.Add(newSection);
                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { 
                    success = true, 
                    message = "Section added successfully.",
                    sectionId = newSection.Id,
                    sectionHtml = await RenderSectionHtml(newSection)
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while adding section." });
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
        /// Render section HTML for AJAX response
        /// </summary>
        private async Task<string> RenderSectionHtml(Section section)
        {
            // This is a simplified version - in a real app you'd use a proper view rendering service
            return $@"
                <div class='section-editor border border-slate-200 rounded-lg p-6' data-section-id='{section.Id}'>
                    <div class='flex items-center justify-between mb-4'>
                        <div class='flex items-center'>
                            <div class='drag-handle cursor-move mr-3 p-2 text-slate-400 hover:text-slate-600'>
                                <i class='fas fa-grip-vertical'></i>
                            </div>
                            <div>
                                <h6 class='font-medium text-slate-800'>Section #{section.Id}</h6>
                                <p class='text-sm text-slate-500'>{section.Type} - {section.SectionTemplateType}</p>
                            </div>
                            <span class='ml-4 px-2 py-1 bg-slate-100 text-slate-600 text-xs rounded'>0 items</span>
                        </div>
                        <div class='flex items-center space-x-2'>
                            <span class='text-sm text-slate-500'>Order: {section.SortOrder}</span>
                            <button type='button' class='text-blue-600 hover:text-blue-800 p-1' onclick='toggleSectionSettings({section.Id})' title='Settings'>
                                <i class='fas fa-cog'></i>
                            </button>
                            <button type='button' class='text-green-600 hover:text-green-800 p-1' onclick='duplicateSection({section.Id})' title='Duplicate'>
                                <i class='fas fa-copy'></i>
                            </button>
                            <button type='button' class='text-red-600 hover:text-red-800 p-1' onclick='removeSection({section.Id})' title='Delete'>
                                <i class='fas fa-trash'></i>
                            </button>
                        </div>
                    </div>
                    <div class='text-center py-8 text-slate-500'>
                        <i class='fas fa-plus-circle text-3xl mb-2'></i>
                        <p class='text-sm'>No items in this section</p>
                        <button type='button' class='mt-2 text-blue-600 hover:text-blue-800 text-sm' onclick='addSectionItem({section.Id})'>
                            Add First Item
                        </button>
                    </div>
                </div>";
        }

        #endregion

        [HttpGet]
        public IActionResult WebUrl()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editor(int id = 0)
        {
            // In a real application, you would load the page data from a database
            // For now we'll just return the same view
            return View("Index");
        }

        [HttpPost]
        public IActionResult SavePage(string pageData)
        {
            // Here you would save the page data to a database
            // For now we'll just return a success message
            return Json(new { success = true, message = "Page saved successfully" });
        }

        [HttpGet]
        public IActionResult GetPageData(int id)
        {
            // Define our section types to avoid anonymous type issues
            var heroSection = new
            {
                type = "hero",
                title = "Welcome to Pazar Atlasi",
                description = "Discover our wide range of products and exclusive deals. Shop now for amazing offers!",
                buttonText = "Shop Now",
                buttonUrl = "/products",
                imageUrl = "/images/hero.jpg"
            };

            var navigationItems = new List<object>
            {
                new { text = "Home", url = "/" },
                new { text = "About", url = "/about" },
                new { text = "Products", url = "/products" },
                new { text = "Services", url = "/services" },
                new { text = "Contact", url = "/contact" }
            };

            var navigationSection = new
            {
                type = "navigation",
                items = navigationItems
            };

            var productItems = new List<object>
            {
                new { title = "Product 1", imageUrl = "/images/product1.jpg", price = "$19.99" },
                new { title = "Product 2", imageUrl = "/images/product2.jpg", price = "$29.99" }
            };

            var productSection = new
            {
                type = "products",
                title = "Featured Products",
                items = productItems
            };

            // Create a list of defined section objects
            var sections = new List<object> { heroSection, navigationSection, productSection };

            // Create the final page data object
            var pageData = new
            {
                id,
                title = "Home Page",
                sections
            };

            return Json(pageData);
        }

        /// <summary>
        /// Save menu content as JSON
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveMenuContent(string menuItemId, string contentJson)
        {
            if (string.IsNullOrEmpty(menuItemId) || string.IsNullOrEmpty(contentJson))
            {
                return BadRequest(new { success = false, message = "Menu item ID and content are required" });
            }

            // Validate JSON structure
            try
            {
                // Here we would save the menu content to the database using a command
                // For now, we'll just return success
                return Json(new { success = true, message = "Menu content saved successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get sample menu structure
        /// </summary>
        [HttpGet]
        public IActionResult GetSampleMenuStructure()
        {
            // Return the sample menu structure
            var menus = GetSampleMenuData();
            return Json(menus);
        }

        /// <summary>
        /// Helper method to generate sample menu data
        /// </summary>
        private object GetSampleMenuData()
        {
            // This would return a sample menu structure similar to the one in the examples
            return new
            {
                headerMenus = new List<object>
                {
                    new
                    {
                        id = "about",
                        label = "About",
                        type = "megamenu",
                        content = new
                        {
                            description = new
                            {
                                title = "About Our Company",
                                text = "Learn about our mission, vision, and values.",
                                linkText = "Read More",
                                linkUrl = "#"
                            },
                            quickLinks = new
                            {
                                title = "Quick Links",
                                links = new List<object>
                                {
                                    new { text = "Mission & Vision", url = "#" },
                                    new { text = "Our Team", url = "#" },
                                    new { text = "Careers", url = "#" },
                                    new { text = "Press", url = "#" }
                                }
                            },
                            features = new
                            {
                                title = "Why Choose Us",
                                items = new List<object>
                                {
                                    new
                                    {
                                        title = "Years of Experience",
                                        description = "Over 10 years in the industry"
                                    },
                                    new
                                    {
                                        title = "Certified Team",
                                        description = "Experts in their fields"
                                    },
                                    new
                                    {
                                        title = "Completed Projects",
                                        description = "Over 500 successful projects"
                                    }
                                }
                            }
                        }
                    },
                    new
                    {
                        id = "services",
                        label = "Services",
                        type = "servicetabs",
                        tabs = new List<object>
                        {
                            new
                            {
                                id = "managed",
                                label = "Managed Services",
                                icon = "Server"
                            },
                            new
                            {
                                id = "cloud",
                                label = "Cloud Services",
                                icon = "Cloud"
                            }
                        },
                        tabContent = new Dictionary<string, object>
                        {
                            ["managed"] = new List<object>
                            {
                                new
                                {
                                    id = "multi-cloud",
                                    title = "Multi-Cloud Management",
                                    icon = "Cloud",
                                    description = "Manage multiple cloud environments efficiently"
                                },
                                new
                                {
                                    id = "hybrid-cloud",
                                    title = "Hybrid Cloud Solutions",
                                    icon = "RefreshCw",
                                    description = "Integrate on-premises with cloud infrastructure"
                                }
                            },
                            ["cloud"] = new List<object>
                            {
                                new
                                {
                                    id = "public-cloud",
                                    title = "Public Cloud Services",
                                    icon = "Globe",
                                    description = "Scalable public cloud infrastructure"
                                },
                                new
                                {
                                    id = "cloud-migration",
                                    title = "Cloud Migration",
                                    icon = "RefreshCw",
                                    description = "Seamless transition to cloud environments"
                                }
                            }
                        }
                    },
                    new
                    {
                        id = "contact",
                        label = "Contact",
                        type = "link",
                        url = "/contact"
                    }
                }
            };
        }

        #region Section Item Management

        /// <summary>
        /// Get section item modal for editing
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSectionItemModal(int id, int sectionId)
        {
            try
            {
                SectionItemModalViewModel model;

                if (id > 0)
                {
                    // Edit existing item
                    var sectionItem = await _pazarAtlasiDbContext.SectionItems
                        .Include(si => si.Translations)
                            .ThenInclude(t => t.Language)
                        .Include(si => si.Section)
                        .FirstOrDefaultAsync(si => si.Id == id && !si.IsDeleted);

                    if (sectionItem == null)
                    {
                        return Json(new { success = false, message = "Section item not found." });
                    }

                    model = new SectionItemModalViewModel
                    {
                        Id = sectionItem.Id,
                        SectionId = sectionItem.SectionId,
                        SectionCode = $"Section #{sectionItem.Section?.Id}",
                        SectionType = sectionItem.Section?.Type ?? SectionType.None,
                        Type = sectionItem.Type,
                        MediaType = sectionItem.MediaType,
                        PictureUrl = sectionItem.PictureUrl,
                        VideoUrl = sectionItem.VideoUrl,
                        RedirectUrl = sectionItem.RedirectUrl,
                        Icon = sectionItem.Icon,
                        SortOrder = sectionItem.SortOrder,
                        MediaAttributes = sectionItem.MediaAttributes,
                        Status = sectionItem.Status,
                        Translations = sectionItem.Translations.Select(t => new SectionItemTranslationModalViewModel
                        {
                            Id = t.Id,
                            SectionItemId = t.SectionItemId,
                            LanguageId = t.LanguageId,
                            LanguageName = t.Language?.Name,
                            LanguageCode = t.Language?.Code,
                            Name = t.Name,
                            Title = t.Title,
                            Description = t.Description
                        }).ToList()
                    };
                }
                else
                {
                    // Create new item
                    var section = await _pazarAtlasiDbContext.Sections
                        .FirstOrDefaultAsync(s => s.Id == sectionId);

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    var maxSortOrder = await _pazarAtlasiDbContext.SectionItems
                        .Where(si => si.SectionId == sectionId)
                        .MaxAsync(si => (int?)si.SortOrder) ?? 0;

                    model = new SectionItemModalViewModel
                    {
                        Id = 0,
                        SectionId = sectionId,
                        SectionCode = $"Section #{section.Id}",
                        SectionType = section.Type,
                        SortOrder = maxSortOrder + 1,
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

                return PartialView("~/Views/Shared/Content/_SectionItemModal.cshtml", model);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

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
                    sectionItem.PictureUrl = request.PictureUrl;
                    sectionItem.VideoUrl = request.VideoUrl;
                    sectionItem.RedirectUrl = request.RedirectUrl;
                    sectionItem.Icon = request.Icon;
                    sectionItem.SortOrder = request.SortOrder;
                    sectionItem.MediaAttributes = request.MediaAttributes;
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
                        PictureUrl = request.PictureUrl,
                        VideoUrl = request.VideoUrl,
                        RedirectUrl = request.RedirectUrl,
                        Icon = request.Icon,
                        SortOrder = request.SortOrder,
                        MediaAttributes = request.MediaAttributes,
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

        /// <summary>
        /// Delete section item
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteSectionItem(int id)
        {
            try
            {
                var sectionItem = await _pazarAtlasiDbContext.SectionItems
                    .Include(si => si.Translations)
                    .FirstOrDefaultAsync(si => si.Id == id && !si.IsDeleted);

                if (sectionItem == null)
                {
                    return Json(new { success = false, message = "Section item not found." });
                }

                // Soft delete - mark as deleted
                sectionItem.IsDeleted = true;
                sectionItem.UpdatedAt = DateTime.UtcNow;

                // Also mark translations as deleted
                foreach (var translation in sectionItem.Translations)
                {
                    translation.IsDeleted = true;
                    translation.UpdatedAt = DateTime.UtcNow;
                }

                await _pazarAtlasiDbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Section item deleted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Get section items by section ID
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSectionItems(int sectionId)
        {
            try
            {
                var sectionItems = await _pazarAtlasiDbContext.SectionItems
                    .Include(si => si.Translations)
                        .ThenInclude(t => t.Language)
                    .Where(si => si.SectionId == sectionId && !si.IsDeleted)
                    .OrderBy(si => si.SortOrder)
                    .ToListAsync();

                var result = sectionItems.Select(si => new SectionItemResponseDto
                {
                    Id = si.Id,
                    SectionId = si.SectionId,
                    Type = si.Type,
                    MediaType = si.MediaType,
                    PictureUrl = si.PictureUrl,
                    VideoUrl = si.VideoUrl,
                    RedirectUrl = si.RedirectUrl,
                    Icon = si.Icon,
                    SortOrder = si.SortOrder,
                    MediaAttributes = si.MediaAttributes,
                    Status = si.Status,
                    Translations = si.Translations.Select(t => new SectionItemTranslationResponseDto
                    {
                        Id = t.Id,
                        SectionItemId = t.SectionItemId,
                        LanguageId = t.LanguageId,
                        LanguageName = t.Language?.Name,
                        LanguageCode = t.Language?.Code,
                        Name = t.Name,
                        Title = t.Title,
                        Description = t.Description
                    }).ToList()
                }).ToList();

                return Json(new { success = true, message = "Section items retrieved successfully.", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
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
                SectionModalViewModel model;

                if (id > 0)
                {
                    // Edit existing section
                    var section = await _pazarAtlasiDbContext.Sections
                        .Include(s => s.SectionItems)
                            .ThenInclude(si => si.Translations)
                        .Include(s => s.Translations).ThenInclude(t => t.Language)
                        .FirstOrDefaultAsync(s => s.Id == id);

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    model = new SectionModalViewModel
                    {
                        Id = section.Id,
                        PageId = section.PageId,
                        Type = section.Type,
                        SectionTemplateType = section.SectionTemplateType,
                        Attributes = section.Attributes,
                        SortOrder = section.SortOrder,
                        Configure = section.Configure,
                        Status = section.Status,
                        SectionItems = section.SectionItems.Select(si => new SectionItemModalViewModel
                        {
                            Id = si.Id,
                            SectionId = si.SectionId,
                            Type = si.Type,
                            MediaType = si.MediaType,
                            PictureUrl = si.PictureUrl,
                            VideoUrl = si.VideoUrl,
                            RedirectUrl = si.RedirectUrl,
                            Icon = si.Icon,
                            SortOrder = si.SortOrder,
                            MediaAttributes = si.MediaAttributes,
                            Status = si.Status,
                            Translations = si.Translations.Select(t => new SectionItemTranslationModalViewModel
                            {
                                Id = t.Id,
                                SectionItemId = t.SectionItemId,
                                LanguageId = t.LanguageId,
                                LanguageName = t.Language?.Name,
                                LanguageCode = t.Language?.Code,
                                Name = t.Name,
                                Title = t.Title,
                                Description = t.Description
                            }).ToList()
                        }).ToList(),
                        Translations = section.Translations.Select(st => new SectionTranslationModalViewModel
                        {
                            Id = st.Id,
                            SectionId = st.SectionId,
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
                    // Create new section
                    var maxSortOrder = await _pazarAtlasiDbContext.Sections
                        .Where(s => s.PageId == pageId)
                        .MaxAsync(s => (int?)s.SortOrder) ?? 0;

                    model = new SectionModalViewModel
                    {
                        Id = 0,
                        PageId = pageId,
                        Type = SectionType.MainContent,
                        SectionTemplateType = SectionTemplateType.Default,
                        SortOrder = maxSortOrder + 1,
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

                return PartialView("~/Views/Shared/Content/_SectionModal.cshtml", model);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Save section with items
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveSection([FromBody] SectionRequest request)
        {
            try
            {
                if (request.Id > 0)
                {
                    // Update existing section
                    var section = await _pazarAtlasiDbContext.Sections
                        .Include(s => s.SectionItems)
                            .ThenInclude(si => si.Translations)
                        .Include(s => s.Translations)
                        .FirstOrDefaultAsync(s => s.Id == request.Id);

                    if (section == null)
                    {
                        return Json(new { success = false, message = "Section not found." });
                    }

                    // Update section properties
                    section.Type = request.Type;
                    section.SectionTemplateType = request.SectionTemplateType;
                    section.Attributes = request.Attributes;
                    section.Configure = request.Configure;
                    section.Status = request.Status;
                    section.UpdatedAt = DateTime.UtcNow;

                    // Update section items
                    if (request.SectionItems != null)
                    {
                        // Remove existing items
                        _pazarAtlasiDbContext.SectionItemTranslations.RemoveRange(
                            section.SectionItems.SelectMany(si => si.Translations));
                        _pazarAtlasiDbContext.SectionItems.RemoveRange(section.SectionItems);

                        // Add new items
                        foreach (var itemRequest in request.SectionItems)
                        {
                            var newItem = new SectionItem
                            {
                                SectionId = section.Id,
                                Type = itemRequest.Type,
                                MediaType = itemRequest.MediaType,
                                PictureUrl = itemRequest.PictureUrl,
                                VideoUrl = itemRequest.VideoUrl,
                                RedirectUrl = itemRequest.RedirectUrl,
                                Icon = itemRequest.Icon,
                                SortOrder = itemRequest.SortOrder,
                                MediaAttributes = itemRequest.MediaAttributes,
                                Status = itemRequest.Status,
                                CreatedAt = DateTime.UtcNow,
                                IsDeleted = false
                            };

                            _pazarAtlasiDbContext.SectionItems.Add(newItem);
                            await _pazarAtlasiDbContext.SaveChangesAsync(); // Save to get ID

                            // Add item translations
                            if (itemRequest.Translations != null)
                            {
                                var itemTranslations = itemRequest.Translations.Select(t => new SectionItemTranslation
                                {
                                    SectionItemId = newItem.Id,
                                    LanguageId = t.LanguageId,
                                    Name = t.Name,
                                    Title = t.Title,
                                    Description = t.Description,
                                    CreatedAt = DateTime.UtcNow,
                                    IsDeleted = false
                                }).ToList();

                                _pazarAtlasiDbContext.SectionItemTranslations.AddRange(itemTranslations);
                            }
                        }
                    }

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
                        PageId = request.PageId,
                        Type = request.Type,
                        SectionTemplateType = request.SectionTemplateType,
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
                    if (request.SectionItems != null)
                    {
                        foreach (var itemRequest in request.SectionItems)
                        {
                            var newItem = new SectionItem
                            {
                                SectionId = newSection.Id,
                                Type = itemRequest.Type,
                                MediaType = itemRequest.MediaType,
                                PictureUrl = itemRequest.PictureUrl,
                                VideoUrl = itemRequest.VideoUrl,
                                RedirectUrl = itemRequest.RedirectUrl,
                                Icon = itemRequest.Icon,
                                SortOrder = itemRequest.SortOrder,
                                MediaAttributes = itemRequest.MediaAttributes,
                                Status = itemRequest.Status,
                                CreatedAt = DateTime.UtcNow,
                                IsDeleted = false
                            };

                            _pazarAtlasiDbContext.SectionItems.Add(newItem);
                            await _pazarAtlasiDbContext.SaveChangesAsync(); // Save to get ID

                            // Add item translations
                            if (itemRequest.Translations != null)
                            {
                                var itemTranslations = itemRequest.Translations.Select(t => new SectionItemTranslation
                                {
                                    SectionItemId = newItem.Id,
                                    LanguageId = t.LanguageId,
                                    Name = t.Name,
                                    Title = t.Title,
                                    Description = t.Description,
                                    CreatedAt = DateTime.UtcNow,
                                    IsDeleted = false
                                }).ToList();

                                _pazarAtlasiDbContext.SectionItemTranslations.AddRange(itemTranslations);
                            }
                        }
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

                    return Json(new { success = true, message = "Section created successfully.", sectionId = newSection.Id });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
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
            var totalCount = await _pazarAtlasiDbContext.Sections.CountAsync();
            
            var sections = await _pazarAtlasiDbContext.Sections
                .Include(s => s.Page)
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
                    SectionTemplateType = s.SectionTemplateType,
                    Status = s.Status,
                    ItemsCount = s.SectionItems.Count,
                    PageName = s.Page != null ? s.Page.Name : null,
                    PageId = s.PageId,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt,
                    IsReusable = s.PageId == null // Sections without a specific page are reusable
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
                .Include(s => s.Page)
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
            if (section.PageId == null) // Reusable section
            {
                // This would require a many-to-many relationship or a usage tracking system
                // For now, we'll leave it empty and implement later
            }

            var model = new SectionDetailsViewModel
            {
                Id = section.Id,
                Name = section.Translations.FirstOrDefault()?.Title ?? $"Section {section.Id}",
                Description = section.Translations.FirstOrDefault()?.Description,
                Type = section.Type,
                SectionTemplateType = section.SectionTemplateType,
                Status = section.Status,
                SortOrder = section.SortOrder,
                Attributes = section.Attributes,
                Configure = section.Configure,
                IsReusable = section.PageId == null,
                CreatedAt = section.CreatedAt,
                UpdatedAt = section.UpdatedAt,
                PageName = section.Page?.Name,
                PageId = section.PageId,
                SectionItems = section.SectionItems.Select(si => new SectionItemDetailsViewModel
                {
                    Id = si.Id,
                    Type = si.Type,
                    MediaType = si.MediaType,
                    PictureUrl = si.PictureUrl,
                    VideoUrl = si.VideoUrl,
                    RedirectUrl = si.RedirectUrl,
                    Icon = si.Icon,
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
                SectionTemplateType = SectionTemplateType.Default
            };

            return View(model);
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
                        SectionTemplateType = model.SectionTemplateType,
                        Status = model.Status,
                        SortOrder = model.SortOrder,
                        Attributes = model.Attributes ?? "{}",
                        Configure = model.Configure ?? "{}",
                        PageId = model.PageId.Value,
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
                    section.SectionTemplateType = model.SectionTemplateType;
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
                    .Where(s => s.PageId == null && s.Status == Status.Active) // Reusable and active sections
                    .Include(s => s.Translations)
                    .ToListAsync();

                var sectionDtos = sections.Select(s => new
                {
                    s.Id,
                    Name = s.Translations.FirstOrDefault()?.Title ?? $"Section {s.Id}",
                    s.Type,
                    s.SectionTemplateType,
                    s.Status,
                    CreatedAt = s.CreatedAt.ToString("yyyy-MM-dd"),
                    UpdatedAt = s.UpdatedAt?.ToString("yyyy-MM-dd")
                });

                return Json(new { success = true, sections = sectionDtos });
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
                    .FirstOrDefaultAsync(s => s.Id == sectionId && s.PageId == null);

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
                    .Where(s => s.PageId == pageId)
                    .MaxAsync(s => (int?)s.SortOrder) ?? 0;

                // Create a copy of the section for this page
                var newSection = new Domain.Entities.Content.Section
                {
                    PageId = pageId,
                    Type = originalSection.Type,
                    SectionTemplateType = originalSection.SectionTemplateType,
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
                        PictureUrl = item.PictureUrl,
                        VideoUrl = item.VideoUrl,
                        RedirectUrl = item.RedirectUrl,
                        LinkedPageId = item.LinkedPageId,
                        Icon = item.Icon,
                        SortOrder = item.SortOrder,
                        MediaAttributes = item.MediaAttributes,
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

        #endregion
    }
}