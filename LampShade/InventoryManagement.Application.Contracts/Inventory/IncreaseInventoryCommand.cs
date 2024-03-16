namespace InventoryManagement.Application.Contracts.Inventory;

public class IncreaseInventoryCommand
{
    public string Description { get; set; }
    public long OperatorId { get; set; }
    public long Count { get; set; }
}
