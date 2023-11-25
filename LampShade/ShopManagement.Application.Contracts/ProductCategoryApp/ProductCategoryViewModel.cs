

namespace ShopManagement.Application.Contracts.ProductCategoryApp
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public string ProductsCount { get; set; } = string.Empty;
        public bool IsRemove { get; set; }
         


    }
}
