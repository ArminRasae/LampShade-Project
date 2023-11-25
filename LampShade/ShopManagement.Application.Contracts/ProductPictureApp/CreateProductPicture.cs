

using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopManagement.Application.Contracts.ProductApp;

namespace ShopManagement.Application.Contracts.ProductPictureApp
{
    public class CreateProductPicture
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)] 
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }
}
