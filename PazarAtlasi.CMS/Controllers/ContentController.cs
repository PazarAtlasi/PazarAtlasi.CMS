using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PazarAtlasi.CMS.Persistence.Context;

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
        /// Main view for menu management
        /// </summary>
        public IActionResult Pages()
        {
            return View();
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