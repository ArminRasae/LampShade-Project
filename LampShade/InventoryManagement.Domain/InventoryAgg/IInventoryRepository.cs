using _0_Framework.Domain;
using InventoryManagement.Application.Contracts.Inventory;

namespace InventoryManagement.Domain.InventoryAgg;

public interface IInventoryRepository :IRepositoryBase<long,Inventory>
{

    EditInventoryCommand GetDetailsBy(long id);
    Inventory GetDetailBy(long productId);
    List<InventoryViewModel> Search(InventorySearchModel searchModel);

}