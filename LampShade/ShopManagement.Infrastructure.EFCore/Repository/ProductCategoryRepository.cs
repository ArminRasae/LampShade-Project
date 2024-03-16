using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategoryApp;
using ShopManagement.Domain.ProductCategoryAgg;
using _0_Framework.Infrastructure;


namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context) : base(context) 
        {
            _context = context;
        }


        public EditProductCategoryCommand GetDetailsBy(long id)
        {
            var query = _context.ProductCategories.Select(x => new EditProductCategoryCommand
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureTitle = x.PictureTitle,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,

            })
                .FirstOrDefault(x => x.Id == id);
            return query!;

        }



        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemove = x.IsRemoved,
                //ProductsCount
            });
            //Filtering
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x=> x.Name).ToList();
        }
        public List<ProductCategoryViewModel> GetCategoryItems()
        {
            var query = _context.ProductCategories
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                });
            return query.ToList();

        }
    }
}
