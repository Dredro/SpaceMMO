using Items.Armor;


public abstract class ArmorDecorator : Armor
{
    protected Armor wrappedArmor;

    public ArmorDecorator(Armor wrappedArmor)
    {
        this.wrappedArmor = wrappedArmor;
        armorData = wrappedArmor.armorData;
        itemData = wrappedArmor.itemData;
    }

    public override void Use()
    {
        wrappedArmor.Use();
    }

    public override void Drop()
    {
        wrappedArmor.Drop();
    }

    public override void PickUp()
    {
        wrappedArmor.PickUp();
    }
}