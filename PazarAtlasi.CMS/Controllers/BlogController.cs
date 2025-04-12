using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PazarAtlasi.CMS.Controllers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            // Test verisi
            var testBlogs = new List<Blog>
            {
                new Blog
                {
                    Id = 1,
                    Title = "Gözlük Seçiminde Dikkat Edilmesi Gerekenler",
                    Topic = "Sağlık",
                    Summary = "Doğru gözlük seçimi için önemli ipuçları ve püf noktaları.",
                    Content = "Gözlük seçerken dikkat edilmesi gereken birçok faktör vardır...",
                    ImageUrl = "/images/blog/glasses1.jpg",
                    PublishDate = DateTime.Now.AddDays(-5),
                    IsActive = true,
                    AuthorId = "1",
                    AuthorName = "Dr. Ahmet Yılmaz",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new Blog
                {
                    Id = 2,
                    Title = "Güneş Gözlüğü Modelleri 2024",
                    Topic = "Moda",
                    Summary = "2024 yılının en trend güneş gözlüğü modelleri ve stilleri.",
                    Content = "Bu yaz sezonunda öne çıkan güneş gözlüğü modelleri...",
                    ImageUrl = "/images/blog/sunglasses1.jpg",
                    PublishDate = DateTime.Now.AddDays(-3),
                    IsActive = true,
                    AuthorId = "2",
                    AuthorName = "Ayşe Kaya",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new Blog
                {
                    Id = 3,
                    Title = "Çocuk Gözlükleri ve Göz Sağlığı",
                    Topic = "Sağlık",
                    Summary = "Çocuklarda göz sağlığı ve gözlük kullanımı hakkında bilmeniz gerekenler.",
                    Content = "Çocuklarda göz sağlığı çok önemlidir...",
                    ImageUrl = "/images/blog/kids-glasses1.jpg",
                    PublishDate = DateTime.Now.AddDays(-1),
                    IsActive = true,
                    AuthorId = "1",
                    AuthorName = "Dr. Ahmet Yılmaz",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new Blog
                {
                    Id = 4,
                    Title = "Kontakt Lens Kullanım Rehberi",
                    Topic = "Sağlık",
                    Summary = "Kontakt lens kullanımında dikkat edilmesi gereken önemli noktalar.",
                    Content = "Kontakt lens kullanırken hijyen çok önemlidir...",
                    ImageUrl = "/images/blog/contact-lens1.jpg",
                    PublishDate = DateTime.Now,
                    IsActive = false,
                    AuthorId = "3",
                    AuthorName = "Dr. Mehmet Demir",
                    CreatedAt = DateTime.Now
                }
            };

            return View(testBlogs);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                // TODO: Blog kaydetme işlemi
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            // TODO: Blog getirme işlemi
            var blog = new Blog
            {
                Id = id,
                Title = "Örnek Blog",
                Content = "Örnek içerik",
                Topic = "Örnek konu",
                Summary = "Örnek özet",
                ImageUrl = "/images/blog/example.jpg",
                PublishDate = DateTime.Now,
                IsActive = true,
                AuthorId = "1",
                AuthorName = "Örnek Yazar",
                CreatedAt = DateTime.Now
            };
            return View(blog);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // TODO: Blog güncelleme işlemi
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            // TODO: Blog getirme işlemi
            var blog = new Blog
            {
                Id = id,
                Title = "Örnek Blog",
                Content = "Örnek içerik",
                Topic = "Örnek konu",
                Summary = "Örnek özet",
                ImageUrl = "/images/blog/example.jpg",
                PublishDate = DateTime.Now,
                IsActive = true,
                AuthorId = "1",
                AuthorName = "Örnek Yazar",
                CreatedAt = DateTime.Now
            };
            return View(blog);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            // TODO: Blog silme işlemi
            return RedirectToAction(nameof(Index));
        }
    }
} 