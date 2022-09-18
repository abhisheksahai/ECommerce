using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ProductUpsert
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public string? Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }

        [ValidateNever]
        [Display(Name = "Image")]
        public string PictureUrl { get; set; } = string.Empty;

        [ValidateNever]
        public IFormFile? FormFile { get; set; } = null;
    }
}