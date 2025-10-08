using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Models.ViewModels;

namespace PazarAtlasi.CMS.Controllers
{
    public class ContentController : Controller
    {
        private readonly PazarAtlasiDbContext _pazarAtlasiDbContext;

        public ContentController(PazarAtlasiDbContext pazarAtlasiDbContext)
        {
            _pazarAtlasiDbContext = pazarAtlasiDbContext;
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
                    Code = s.Code,
                    Type = s.Type,
                    TemplateType = s.TemplateType,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = s.SectionItems.Select(si => new SectionItemViewModel
                    {
                        Id = si.Id,
                        Code = si.Code,
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
        /// Page edit form
        /// </summary>
        public async Task<IActionResult> PageEdit(int id)
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

            var model = new PageEditViewModel
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
                } : null,
                Sections = page.Sections.Select(s => new SectionEditViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Type = s.Type,
                    TemplateType = s.TemplateType,
                    Attributes = s.Attributes,
                    SortOrder = s.SortOrder,
                    Configure = s.Configure,
                    Status = s.Status,
                    SectionItems = s.SectionItems.Select(si => new SectionItemEditViewModel
                    {
                        Id = si.Id,
                        Code = si.Code,
                        Type = si.Type,
                        PictureUrl = si.PictureUrl,
                        RedirectUrl = si.RedirectUrl,
                        Icon = si.Icon,
                        SortOrder = si.SortOrder,
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

            return View(model);
        }

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
    }
}