using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategoryApp
{
    public class CreateProductCategoryCommand
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxFileSize(0 , ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; } 
        public string PictureAlt { get; set; } 
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; } 
    }
}
