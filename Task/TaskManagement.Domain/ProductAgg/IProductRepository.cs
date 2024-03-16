using TaskManagement.Application.Contracts;

namespace TaskManagement.Domain.ProductAgg
{
    public interface IProductRepository
    {
        List<ProductViewModel> Category1Products();
        ProductViewModel HighestPriceProduct();
        double TotalPrice();
        IEnumerable<IGrouping<string, ProductViewModel>> GroupedProducts();
        double AveragePrice();

    }
}