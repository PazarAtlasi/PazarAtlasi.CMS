using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
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
    }
}