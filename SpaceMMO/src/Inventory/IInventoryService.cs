public interface IInventoryService
{
    public Inventory GetInventory(UUID id);
    public void UpdateInventory(UUID id);
}