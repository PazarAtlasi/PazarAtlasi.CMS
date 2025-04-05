using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int StockQuantity { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string FrameType { get; set; }
        public string LensType { get; set; }
        public string LensColor { get; set; }
        public string LensMaterial { get; set; }
        public string PrescriptionType { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation properties
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
} 