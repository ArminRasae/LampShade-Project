using TaskManagement.Application.Contracts;
using TaskManagement.Domain.ProductAgg;

namespace TaskManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public double AveragePrice()
        {
            return _productRepository.AveragePrice();
        }

        public List<ProductViewModel> Category1Products()
        {
            return _productRepository.Category1Products();
        }

        public IEnumerable<IGrouping<string, ProductViewModel>> GroupedProducts()
        {
            return _productRepository.GroupedProducts();
        }

        public ProductViewModel HighestPriceProduct()
        {
            return _productRepository.HighestPriceProduct();
        }

        public double TotalPrice()
        {
           return _productRepository.TotalPrice();
        }
    }
}
