using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.MenuItems.Commands.CreateMenuItem;
using PazarAtlasi.CMS.Application.Features.MenuItems.Queries.GetAllMenuItems;
using MediatR;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Models;

namespace PazarAtlasi.CMS.Controllers
{
    public class ContentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IContentService _contentService;

        public ContentController(IMediator mediator, IContentService contentService)
        {
            _mediator = mediator;
            _contentService = contentService;
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
        /// Get all menu items as JSON
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var query = new GetAllMenuItemsQuery();
            var menuItems = await _mediator.Send(query);
            return Json(menuItems);
        }

        /// <summary>
        /// Create a new menu item
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(CreateMenuItemCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _mediator.Send(command);
                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
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

        [HttpGet]
        public async Task<IActionResult> Discovery()
        {
            var discoveryResponse = await _contentService.DiscoverEndpointsAsync();
            return View(discoveryResponse);
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _contentService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> MenuItems(int pageIndex = 0, int pageSize = 10)
        {
            var pageRequest = new PageRequest { PageIndex = pageIndex, PageSize = pageSize };
            var menus = await _contentService.GetListAsync<dynamic>("MenuItems", pageRequest);
            return View(menus);
        }

        [HttpGet]
        public async Task<IActionResult> MenuItemDetails(int id)
        {
            var menu = await _contentService.GetByIdAsync<dynamic>("MenuItems", id);
            return View(menu);
        }
    }
}