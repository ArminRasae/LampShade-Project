
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductApp
{
    public interface IProductApplication
    {
         List<ProductViewModel> Search(ProductSearchModel searchModel);
         OperationResult Create(CreateProductCommand command);
         OperationResult Edit(EditProductCommand command);
         EditProductCommand GetDetailsBy(long id);
         OperationResult IsStock(long id);
         OperationResult NotInStock(long id);
         List<ProductViewModel> GetProductsItem();
         

         





    }
}
