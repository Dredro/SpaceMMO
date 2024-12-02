using System.Data;

public interface IGameRepository
{
    public DbContext dataStorage{ get; set; }

    public Inventory GetInventory(UUID id);
    public void UpdateInventory(UUID id);
}