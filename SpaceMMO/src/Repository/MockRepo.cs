public class MockRepo : IGameRepository
{
    public DbContext dataStorage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Inventory GetInventory(UUID id)
    {
        throw new NotImplementedException();
    }

    public void UpdateInventory(UUID id)
    {
        throw new NotImplementedException();
    }
}