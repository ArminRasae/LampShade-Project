using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Domain.ProductAgg;


namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public EditProductCommand GetDetails(long id)
        {
            var product = _context.Products.Select(x => new EditProductCommand
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                Slug = x.Slug,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CategoryId = x.CategoryId

            }).FirstOrDefault(x => x.Id == id);

            return product;

        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    UnitPrice = x.UnitPrice,
                    Picture = x.Picture,
                    CategoryName = x.Category.Name,
                    CategoryId = x.CategoryId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    IsInStock = x.IsInStock,
                });

            //if (!string.IsNullOrWhiteSpace(searchModel.Name) && !string.IsNullOrWhiteSpace(searchModel.Code) && searchModel.CategoryId != 0)
            //{
            //    query = query
            //        .Where(x => x.Name.Contains(searchModel.Name))
            //        .Where(x => x.CategoryId == searchModel.CategoryId)
            //        .Where(x => x.Code.Contains(searchModel.Code));
            //}


            return SearchBehavior(searchModel, query);

        }

        private static List<ProductViewModel> SearchBehavior(ProductSearchModel searchModel, IQueryable<ProductViewModel> query)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                query = query.Where(x => x.Code.Contains(searchModel.Code));
            }

            if (searchModel.CategoryId != null)
            {
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);
            }

            return query.OrderByDescending(e => e.Id).ToList();
        }

        public List<ProductViewModel> GetProductsItem()
        {
            var query = _context.Products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
            return query;
        }
    }
}
