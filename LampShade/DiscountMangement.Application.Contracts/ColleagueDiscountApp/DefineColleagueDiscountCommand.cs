using ShopManagement.Application.Contracts.ProductApp;

namespace DiscountManagement.Application.Contracts.ColleagueDiscountApp
{
    public class DefineColleagueDiscountCommand
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public List<ProductViewModel> ProductsItem { get; private set; }

    }
}
