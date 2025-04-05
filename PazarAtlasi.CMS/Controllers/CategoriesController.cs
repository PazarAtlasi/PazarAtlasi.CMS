using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Categories.Queries;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PazarAtlasi.CMS.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            // Dummy data for eyeglasses categories
            var categories = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Name = "Prescription Glasses",
                    Description = "All types of prescription eyewear",
                    Slug = "prescription-glasses",
                    ImageUrl = "/images/categories/prescription-glasses.jpg",
                    ParentId = null,
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ProductCount = 150,
                    Children = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = 2,
                            Name = "Single Vision",
                            Description = "Standard single vision prescription glasses",
                            Slug = "single-vision",
                            ImageUrl = "/images/categories/single-vision.jpg",
                            ParentId = 1,
                            ParentName = "Prescription Glasses",
                            DisplayOrder = 1,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 50
                        },
                        new CategoryDto
                        {
                            Id = 3,
                            Name = "Bifocal",
                            Description = "Bifocal prescription glasses",
                            Slug = "bifocal",
                            ImageUrl = "/images/categories/bifocal.jpg",
                            ParentId = 1,
                            ParentName = "Prescription Glasses",
                            DisplayOrder = 2,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 30
                        },
                        new CategoryDto
                        {
                            Id = 4,
                            Name = "Progressive",
                            Description = "Progressive prescription glasses",
                            Slug = "progressive",
                            ImageUrl = "/images/categories/progressive.jpg",
                            ParentId = 1,
                            ParentName = "Prescription Glasses",
                            DisplayOrder = 3,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 40
                        }
                    }
                },
                new CategoryDto
                {
                    Id = 5,
                    Name = "Sunglasses",
                    Description = "All types of sunglasses",
                    Slug = "sunglasses",
                    ImageUrl = "/images/categories/sunglasses.jpg",
                    ParentId = null,
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ProductCount = 100,
                    Children = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = 6,
                            Name = "Prescription Sunglasses",
                            Description = "Sunglasses with prescription lenses",
                            Slug = "prescription-sunglasses",
                            ImageUrl = "/images/categories/prescription-sunglasses.jpg",
                            ParentId = 5,
                            ParentName = "Sunglasses",
                            DisplayOrder = 1,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 40
                        },
                        new CategoryDto
                        {
                            Id = 7,
                            Name = "Fashion Sunglasses",
                            Description = "Stylish non-prescription sunglasses",
                            Slug = "fashion-sunglasses",
                            ImageUrl = "/images/categories/fashion-sunglasses.jpg",
                            ParentId = 5,
                            ParentName = "Sunglasses",
                            DisplayOrder = 2,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 60
                        }
                    }
                },
                new CategoryDto
                {
                    Id = 8,
                    Name = "Contact Lenses",
                    Description = "All types of contact lenses",
                    Slug = "contact-lenses",
                    ImageUrl = "/images/categories/contact-lenses.jpg",
                    ParentId = null,
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ProductCount = 80,
                    Children = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = 9,
                            Name = "Monthly Contact Lenses",
                            Description = "Monthly disposable contact lenses",
                            Slug = "monthly-contact-lenses",
                            ImageUrl = "/images/categories/monthly-contact-lenses.jpg",
                            ParentId = 8,
                            ParentName = "Contact Lenses",
                            DisplayOrder = 1,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 30
                        },
                        new CategoryDto
                        {
                            Id = 10,
                            Name = "Daily Contact Lenses",
                            Description = "Daily disposable contact lenses",
                            Slug = "daily-contact-lenses",
                            ImageUrl = "/images/categories/daily-contact-lenses.jpg",
                            ParentId = 8,
                            ParentName = "Contact Lenses",
                            DisplayOrder = 2,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 50
                        }
                    }
                },
                new CategoryDto
                {
                    Id = 11,
                    Name = "Accessories",
                    Description = "Eyewear accessories and maintenance products",
                    Slug = "accessories",
                    ImageUrl = "/images/categories/accessories.jpg",
                    ParentId = null,
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ProductCount = 120,
                    Children = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = 12,
                            Name = "Cases",
                            Description = "Eyewear cases and holders",
                            Slug = "cases",
                            ImageUrl = "/images/categories/cases.jpg",
                            ParentId = 11,
                            ParentName = "Accessories",
                            DisplayOrder = 1,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 40
                        },
                        new CategoryDto
                        {
                            Id = 13,
                            Name = "Cleaning Products",
                            Description = "Lens cleaning solutions and cloths",
                            Slug = "cleaning-products",
                            ImageUrl = "/images/categories/cleaning-products.jpg",
                            ParentId = 11,
                            ParentName = "Accessories",
                            DisplayOrder = 2,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 30
                        },
                        new CategoryDto
                        {
                            Id = 14,
                            Name = "Repair Kits",
                            Description = "Eyewear repair and maintenance kits",
                            Slug = "repair-kits",
                            ImageUrl = "/images/categories/repair-kits.jpg",
                            ParentId = 11,
                            ParentName = "Accessories",
                            DisplayOrder = 3,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            CreatedBy = "System",
                            UpdatedBy = "System",
                            ProductCount = 20
                        }
                    }
                }
            };

            return View(categories);
        }

        public IActionResult Create()
        {
            // Dummy data for parent categories dropdown
            ViewBag.ParentCategories = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Ana Kategori" },
                new SelectListItem { Value = "1", Text = "Prescription Glasses" },
                new SelectListItem { Value = "5", Text = "Sunglasses" },
                new SelectListItem { Value = "8", Text = "Contact Lenses" },
                new SelectListItem { Value = "11", Text = "Accessories" }
            };

            return View();
        }

        public IActionResult Edit(int id)
        {
            // Dummy data for editing
            var category = new CategoryDto
            {
                Id = id,
                Name = "Single Vision",
                Description = "Standard single vision prescription glasses",
                Slug = "single-vision",
                ImageUrl = "/images/categories/single-vision.jpg",
                ParentId = 1,
                ParentName = "Prescription Glasses",
                DisplayOrder = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System",
                ProductCount = 50
            };

            // Dummy data for parent categories dropdown
            ViewBag.ParentCategories = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Ana Kategori" },
                new SelectListItem { Value = "1", Text = "Prescription Glasses" },
                new SelectListItem { Value = "5", Text = "Sunglasses" },
                new SelectListItem { Value = "8", Text = "Contact Lenses" },
                new SelectListItem { Value = "11", Text = "Accessories" }
            };

            return View(category);
        }
    }
} 