using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductPictureApp;


namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepositoryBase<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);

    }
}
