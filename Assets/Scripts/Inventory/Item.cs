using InventorySystem;

public abstract class Item
{
    public ItemData itemData;
    public abstract void Use();
    public abstract void Drop();
    public abstract void PickUp();
}