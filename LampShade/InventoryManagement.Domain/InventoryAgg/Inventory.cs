using _0_Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        private long CalculateInventoryStock()
        {
            var sum = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return sum - minus;
        }

        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateInventoryStock() + count;
            var inventoryOperation = new InventoryOperation(true,count,operatorId,currentCount,description,0,Id);
            Operations.Add(inventoryOperation);
            InStock = currentCount > 0;
        }

        public void Reduce(long count, long operatorId, string description,long orderId)
        {
            var currentCount = CalculateInventoryStock() - count;
            var inventoryOperation = new InventoryOperation(true, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(inventoryOperation);
            InStock = currentCount > 0; 
        }
    }
}

