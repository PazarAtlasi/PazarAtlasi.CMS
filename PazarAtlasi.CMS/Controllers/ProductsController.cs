using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Products.Queries;
using PazarAtlasi.CMS.Application.Features.Categories.Queries;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PazarAtlasi.CMS.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int? categoryId = null)
        {
            // Dummy data for eyeglasses products
            var products = new List<ProductDto>
            {
                new ProductDto
                {
                    Id = 1,
                    Name = "Classic Round Metal Frame",
                    Description = "Timeless round metal frame with a vintage look",
                    Slug = "classic-round-metal-frame",
                    ImageUrl = "/images/products/classic-round-metal-frame.jpg",
                    Price = 129.99m,
                    DiscountedPrice = 99.99m,
                    StockQuantity = 15,
                    SKU = "CRMF-001",
                    Brand = "Vintage Optics",
                    Model = "Round Classic",
                    Color = "Gold",
                    Material = "Metal",
                    FrameType = "Full Rim",
                    LensType = "Single Vision",
                    LensColor = "Clear",
                    LensMaterial = "CR-39",
                    PrescriptionType = "Single Vision",
                    IsActive = true,
                    IsFeatured = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    CategoryId = 2,
                    CategoryName = "Single Vision",
                    Images = new List<ProductImageDto>
                    {
                        new ProductImageDto
                        {
                            Id = 1,
                            ImageUrl = "/images/products/classic-round-metal-frame-1.jpg",
                            AltText = "Classic Round Metal Frame Front View",
                            DisplayOrder = 1,
                            IsMain = true
                        },
                        new ProductImageDto
                        {
                            Id = 2,
                            ImageUrl = "/images/products/classic-round-metal-frame-2.jpg",
                            AltText = "Classic Round Metal Frame Side View",
                            DisplayOrder = 2,
                            IsMain = false
                        }
                    }
                },
                new ProductDto
                {
                    Id = 2,
                    Name = "Modern Square Acetate Frame",
                    Description = "Contemporary square acetate frame with a bold look",
                    Slug = "modern-square-acetate-frame",
                    ImageUrl = "/images/products/modern-square-acetate-frame.jpg",
                    Price = 149.99m,
                    DiscountedPrice = null,
                    StockQuantity = 20,
                    SKU = "MSAF-001",
                    Brand = "Urban Eyewear",
                    Model = "Square Modern",
                    Color = "Tortoise",
                    Material = "Acetate",
                    FrameType = "Full Rim",
                    LensType = "Single Vision",
                    LensColor = "Clear",
                    LensMaterial = "CR-39",
                    PrescriptionType = "Single Vision",
                    IsActive = true,
                    IsFeatured = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    CategoryId = 2,
                    CategoryName = "Single Vision",
                    Images = new List<ProductImageDto>
                    {
                        new ProductImageDto
                        {
                            Id = 3,
                            ImageUrl = "/images/products/modern-square-acetate-frame-1.jpg",
                            AltText = "Modern Square Acetate Frame Front View",
                            DisplayOrder = 1,
                            IsMain = true
                        },
                        new ProductImageDto
                        {
                            Id = 4,
                            ImageUrl = "/images/products/modern-square-acetate-frame-2.jpg",
                            AltText = "Modern Square Acetate Frame Side View",
                            DisplayOrder = 2,
                            IsMain = false
                        }
                    }
                },
                new ProductDto
                {
                    Id = 3,
                    Name = "Aviator Sunglasses",
                    Description = "Classic aviator style sunglasses with UV protection",
                    Slug = "aviator-sunglasses",
                    ImageUrl = "/images/products/aviator-sunglasses.jpg",
                    Price = 179.99m,
                    DiscountedPrice = 149.99m,
                    StockQuantity = 10,
                    SKU = "AVSG-001",
                    Brand = "Sky Optics",
                    Model = "Aviator Classic",
                    Color = "Gold/Silver",
                    Material = "Metal",
                    FrameType = "Full Rim",
                    LensType = "Non-Prescription",
                    LensColor = "Gray",
                    LensMaterial = "Polycarbonate",
                    PrescriptionType = "Non-Prescription",
                    IsActive = true,
                    IsFeatured = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    CategoryId = 7,
                    CategoryName = "Fashion Sunglasses",
                    Images = new List<ProductImageDto>
                    {
                        new ProductImageDto
                        {
                            Id = 5,
                            ImageUrl = "/images/products/aviator-sunglasses-1.jpg",
                            AltText = "Aviator Sunglasses Front View",
                            DisplayOrder = 1,
                            IsMain = true
                        },
                        new ProductImageDto
                        {
                            Id = 6,
                            ImageUrl = "/images/products/aviator-sunglasses-2.jpg",
                            AltText = "Aviator Sunglasses Side View",
                            DisplayOrder = 2,
                            IsMain = false
                        }
                    }
                },
                new ProductDto
                {
                    Id = 4,
                    Name = "Monthly Disposable Contact Lenses",
                    Description = "Comfortable monthly disposable contact lenses",
                    Slug = "monthly-disposable-contact-lenses",
                    ImageUrl = "/images/products/monthly-disposable-contact-lenses.jpg",
                    Price = 49.99m,
                    DiscountedPrice = null,
                    StockQuantity = 50,
                    SKU = "MDCL-001",
                    Brand = "Clear Vision",
                    Model = "Monthly Comfort",
                    Color = "Clear",
                    Material = "Hydrogel",
                    FrameType = "N/A",
                    LensType = "Monthly Disposable",
                    LensColor = "Clear",
                    LensMaterial = "Hydrogel",
                    PrescriptionType = "Single Vision",
                    IsActive = true,
                    IsFeatured = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    CategoryId = 9,
                    CategoryName = "Monthly Contact Lenses",
                    Images = new List<ProductImageDto>
                    {
                        new ProductImageDto
                        {
                            Id = 7,
                            ImageUrl = "/images/products/monthly-disposable-contact-lenses-1.jpg",
                            AltText = "Monthly Disposable Contact Lenses Package",
                            DisplayOrder = 1,
                            IsMain = true
                        }
                    }
                },
                new ProductDto
                {
                    Id = 5,
                    Name = "Leather Eyeglass Case",
                    Description = "Premium leather case for eyeglasses",
                    Slug = "leather-eyeglass-case",
                    ImageUrl = "/images/products/leather-eyeglass-case.jpg",
                    Price = 29.99m,
                    DiscountedPrice = 24.99m,
                    StockQuantity = 30,
                    SKU = "LEC-001",
                    Brand = "Leather Craft",
                    Model = "Classic Case",
                    Color = "Brown",
                    Material = "Genuine Leather",
                    FrameType = "N/A",
                    LensType = "N/A",
                    LensColor = "N/A",
                    LensMaterial = "N/A",
                    PrescriptionType = "N/A",
                    IsActive = true,
                    IsFeatured = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    CategoryId = 12,
                    CategoryName = "Cases",
                    Images = new List<ProductImageDto>
                    {
                        new ProductImageDto
                        {
                            Id = 8,
                            ImageUrl = "/images/products/leather-eyeglass-case-1.jpg",
                            AltText = "Leather Eyeglass Case Front View",
                            DisplayOrder = 1,
                            IsMain = true
                        },
                        new ProductImageDto
                        {
                            Id = 9,
                            ImageUrl = "/images/products/leather-eyeglass-case-2.jpg",
                            AltText = "Leather Eyeglass Case Open View",
                            DisplayOrder = 2,
                            IsMain = false
                        }
                    }
                }
            };

            // Filter by category if specified
            if (categoryId.HasValue)
            {
                products = products.FindAll(p => p.CategoryId == categoryId.Value);
            }

            // Dummy data for categories dropdown
            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Prescription Glasses" },
                new SelectListItem { Value = "2", Text = "Single Vision" },
                new SelectListItem { Value = "3", Text = "Bifocal" },
                new SelectListItem { Value = "4", Text = "Progressive" },
                new SelectListItem { Value = "5", Text = "Reading Glasses" },
                new SelectListItem { Value = "6", Text = "Computer Glasses" },
                new SelectListItem { Value = "7", Text = "Fashion Sunglasses" },
                new SelectListItem { Value = "8", Text = "Sports Sunglasses" },
                new SelectListItem { Value = "9", Text = "Monthly Contact Lenses" },
                new SelectListItem { Value = "10", Text = "Daily Contact Lenses" },
                new SelectListItem { Value = "11", Text = "Contact Lens Solutions" },
                new SelectListItem { Value = "12", Text = "Cases" },
                new SelectListItem { Value = "13", Text = "Cleaning Kits" },
                new SelectListItem { Value = "14", Text = "Accessories" }
            };

            return View(products);
        }

        public IActionResult Create()
        {
            // Dummy data for categories dropdown
            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Prescription Glasses" },
                new SelectListItem { Value = "2", Text = "Single Vision" },
                new SelectListItem { Value = "3", Text = "Bifocal" },
                new SelectListItem { Value = "4", Text = "Progressive" },
                new SelectListItem { Value = "5", Text = "Reading Glasses" },
                new SelectListItem { Value = "6", Text = "Computer Glasses" },
                new SelectListItem { Value = "7", Text = "Fashion Sunglasses" },
                new SelectListItem { Value = "8", Text = "Sports Sunglasses" },
                new SelectListItem { Value = "9", Text = "Monthly Contact Lenses" },
                new SelectListItem { Value = "10", Text = "Daily Contact Lenses" },
                new SelectListItem { Value = "11", Text = "Contact Lens Solutions" },
                new SelectListItem { Value = "12", Text = "Cases" },
                new SelectListItem { Value = "13", Text = "Cleaning Kits" },
                new SelectListItem { Value = "14", Text = "Accessories" }
            };

            return View();
        }

        public IActionResult Edit(int id)
        {
            // Dummy data for editing
            var product = new ProductDto
            {
                Id = id,
                Name = "Classic Round Metal Frame",
                Description = "Timeless round metal frame with a vintage look",
                Slug = "classic-round-metal-frame",
                ImageUrl = "/images/products/classic-round-metal-frame.jpg",
                Price = 129.99m,
                DiscountedPrice = 99.99m,
                StockQuantity = 15,
                SKU = "CRMF-001",
                Brand = "Vintage Optics",
                Model = "Round Classic",
                Color = "Gold",
                Material = "Metal",
                FrameType = "Full Rim",
                LensType = "Single Vision",
                LensColor = "Clear",
                LensMaterial = "CR-39",
                PrescriptionType = "Single Vision",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System",
                CategoryId = 2,
                CategoryName = "Single Vision",
                Images = new List<ProductImageDto>
                {
                    new ProductImageDto
                    {
                        Id = 1,
                        ImageUrl = "/images/products/classic-round-metal-frame-1.jpg",
                        AltText = "Classic Round Metal Frame Front View",
                        DisplayOrder = 1,
                        IsMain = true
                    },
                    new ProductImageDto
                    {
                        Id = 2,
                        ImageUrl = "/images/products/classic-round-metal-frame-2.jpg",
                        AltText = "Classic Round Metal Frame Side View",
                        DisplayOrder = 2,
                        IsMain = false
                    }
                }
            };

            // Dummy data for categories dropdown
            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Prescription Glasses" },
                new SelectListItem { Value = "2", Text = "Single Vision" },
                new SelectListItem { Value = "3", Text = "Bifocal" },
                new SelectListItem { Value = "4", Text = "Progressive" },
                new SelectListItem { Value = "5", Text = "Reading Glasses" },
                new SelectListItem { Value = "6", Text = "Computer Glasses" },
                new SelectListItem { Value = "7", Text = "Fashion Sunglasses" },
                new SelectListItem { Value = "8", Text = "Sports Sunglasses" },
                new SelectListItem { Value = "9", Text = "Monthly Contact Lenses" },
                new SelectListItem { Value = "10", Text = "Daily Contact Lenses" },
                new SelectListItem { Value = "11", Text = "Contact Lens Solutions" },
                new SelectListItem { Value = "12", Text = "Cases" },
                new SelectListItem { Value = "13", Text = "Cleaning Kits" },
                new SelectListItem { Value = "14", Text = "Accessories" }
            };

            return View(product);
        }
    }
} 