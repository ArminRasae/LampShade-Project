namespace InventoryManagement.Application.Contracts.Inventory;

public class DecreaseInventoryCommand
{
    public string Description { get; set; }
    public long InventoryId { get; set; }
    public long Count { get; set; }
    public long OrderId { get; set; }

}