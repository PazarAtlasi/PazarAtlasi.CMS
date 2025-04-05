using MediatR;
using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.Products.Queries
{
    public class ProductDto
    {
        public int Id { get; set; }
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
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }

    public class ProductImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsMain { get; set; }
    }

    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public int? CategoryId { get; set; }
    }

    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }

    public class CreateProductCommand : IRequest<ProductDto>
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
        public int CategoryId { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }

    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
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
        public int CategoryId { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }

    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
} 