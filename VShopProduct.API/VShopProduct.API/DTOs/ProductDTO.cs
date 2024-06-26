﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShopProduct.API.Models;

namespace VShopProduct.API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The price is Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The stock is Required")]
        [Range(1,9999)]
        public long Stock { get; set; }
        public string? ImageURL { get; set; }
        public string? CategoryName { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
