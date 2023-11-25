
using _0_Framework.Application;


namespace ShopManagement.Application.Contracts.ProductCategoryApp
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategoryCommand command);
        OperationResult Edit(EditProductCategoryCommand command);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel mdoel);
        EditProductCategoryCommand GetDetailsBy(long id);
        List<ProductCategoryViewModel> GetCategoryItem();
        OperationResult IsRemove(long id);
        OperationResult IsRestore(long id);

    }
}
