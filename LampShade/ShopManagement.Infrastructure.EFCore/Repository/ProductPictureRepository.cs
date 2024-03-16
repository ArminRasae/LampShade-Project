using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPictureApp;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context) 
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            var query = _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                ProductId = x.ProductId,
                
            }).FirstOrDefault(x => x.Id == id);

            return query!;

        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures
                .Include(x => x.Product)
                .Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Product = x.Product.Name,
                ProductId = x.Product.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
            });
            if (searchModel.ProductId !=  0 )
            
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            
            return query.OrderByDescending(x => x.Id).ToList();
        }

        
    }
}
