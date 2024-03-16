using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Infrastructure.EFCore.Repository;

public class InventoryRepository : RepositoryBase<long,Inventory>, IInventoryRepository
{
    private readonly InventoryContext _context;

    public InventoryRepository(InventoryContext context) : base(context)
    {
        _context = context;
    }


    public EditInventoryCommand GetDetailsBy(long id)
    {
      return  _context.Inventory.Select(x => new EditInventoryCommand
        {
            Id = x.Id,
            ProductId = x.ProductId,
            UnitPrice = x.UnitPrice,
        }).FirstOrDefault(x => x.Id == id)!;
    }

    public Inventory GetDetailBy(long productId)
    {
      return  _context.Inventory.FirstOrDefault(x => x.ProductId == productId)!;
    }

    public List<InventoryViewModel> Search(InventorySearchModel searchModel)
    {
        var query = _context.Inventory.Select(x => new InventoryViewModel
        {
            Id = x.Id,
            ProductId = x.ProductId,
            InStock = x.InStock,
            CurrentCount = 2,
            Product = "swd",
        });
        if (searchModel.ProductId != null)
        {
            query = query.Where(x => x.ProductId == searchModel.ProductId);
        }

        if (!searchModel.InStock)
        {
            query = query.Where(x => !x.InStock);
        }

        return query.OrderByDescending(x => x.Id).ToList();

    }
}