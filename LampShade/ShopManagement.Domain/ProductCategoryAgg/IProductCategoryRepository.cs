
using ShopManagement.Application.Contracts.ProductCategoryApp;
using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepositoryBase<long, ProductCategory>
    {
        List<ProductCategoryViewModel> GetCategoryItems();
        EditProductCategoryCommand GetDetailsBy(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

    }
}
