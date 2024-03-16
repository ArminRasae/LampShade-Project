using TaskManagement.Application.Contracts;
using TaskManagement.Domain.ProductAgg;

namespace TaskManagement.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products = new List<Product>
        {
            new Product{ Id=1,Name = "Product A",Category ="Category 1",Price= 100},

            new Product{ Id=2,Name = "Product B",Category = "Category 2",Price =150},

            new Product{ Id=3,Name= "Product C",Category = "Category 1",Price = 120},

            new Product{ Id=4,Name = "Product D",Category= "Category 3",Price = 200 },

            new Product{ Id=5,Name = "Product E",Category = "Category 2",Price = 80},
            
        };

        public double AveragePrice()
        {
            return products.Average(x => x.Price);
        }

        public List<ProductViewModel> Category1Products()
        {
            var query = products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    Price = x.Price,
                }).Where(x => x.Category.Contains("Category 1"));
            return query.ToList();
        }

        public IEnumerable<IGrouping<string, ProductViewModel>> GroupedProducts()
        {
            return products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category,
                Price = x.Price,
            }).GroupBy(x => x.Category);
        }

        public ProductViewModel HighestPriceProduct()
        {
            return products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category,
                Price = x.Price,
            }).OrderByDescending(x => x.Price)
                .First();
        }

        public double TotalPrice()
        {
            return products.Sum(x => x.Price);
        }
     
    }
}
