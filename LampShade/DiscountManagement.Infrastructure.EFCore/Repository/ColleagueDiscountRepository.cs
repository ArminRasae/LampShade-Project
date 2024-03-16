using _0_Framework.Domain;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System.Linq.Expressions;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscountApp;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscountCommand GetDetailsBy(long id)
        {
            var query = _context.ColleagueDiscounts
                .Select(x => new EditColleagueDiscountCommand
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                })
                .FirstOrDefault(x => x.Id == id);

            return query;
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList();

            var query = _context.ColleagueDiscounts
                .Select(x => new ColleagueDiscountViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                    CreationDate = x.CreationDate.ToFarsi(),
                    IsRemoved = x.IsRemoved,

                });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(x =>
                x.Product = products
                    .FirstOrDefault(p =>
                        p.Id == x.ProductId)!.Name);

            return discounts;
        }
    }
}
