using ShopManagement.Application.Contracts.ProductApp;

namespace DiscountManagement.Application.Contracts.CustomerDiscountApp
{
    public class DefineCustomerDiscountCommand
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DiscountReason { get; set; }
        public List<ProductViewModel> ProductsItem { get; set; }
    }
}
