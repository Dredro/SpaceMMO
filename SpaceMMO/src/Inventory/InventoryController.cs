public class InventoryController : IInventoryService
{
    private static InventoryController? _instance;

    public static InventoryController GetInstance()
    {
        _instance ??= new InventoryController();
        return _instance;
    }
    public Inventory GetInventory(UUID id)
    {
        throw new NotImplementedException();
    }

    public void UpdateInventory(UUID id)
    {
        throw new NotImplementedException();
    }
}