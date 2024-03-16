namespace TaskManagement.Application.Contracts
{
    public interface IProductApplication
    {
        List<ProductViewModel> Category1Products();
        ProductViewModel HighestPriceProduct();
        double TotalPrice();
        IEnumerable<IGrouping<string, ProductViewModel>> GroupedProducts();
        double AveragePrice();
    }
}
