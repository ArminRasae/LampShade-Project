using _0_Framework.Application;

namespace InventoryManagement.Application.Contracts.Inventory;

public interface IInventoryApplication
{
    OperationResult Create(CreateInventoryCommand command);
    OperationResult Edit(EditInventoryCommand command);
    EditInventoryCommand GetDetailsBy(long id);
    InventoryViewModel Search(InventorySearchModel searchModel);
    OperationResult IncreaseInventory(List<DecreaseInventoryCommand> command);
    OperationResult IncreaseInventory(DecreaseInventoryCommand command);
    OperationResult DecreaseInventory(DecreaseInventoryCommand command);

}