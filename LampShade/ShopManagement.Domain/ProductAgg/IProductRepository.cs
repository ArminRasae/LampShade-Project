
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductApp;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepositoryBase<long, Product>
    {
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProductCommand GetDetails(long id);
        List<ProductViewModel> GetProductsItem();   

    }
}
