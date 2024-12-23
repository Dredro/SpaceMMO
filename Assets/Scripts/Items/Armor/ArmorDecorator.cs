public abstract class ArmorDecorator : Armor
{
    protected Armor baseArmor;

    public ArmorDecorator(Armor baseArmor)
    {
        this.baseArmor = baseArmor;
    }

    public override void Use()
    {
        baseArmor?.Use(); 
    }

    public override void Drop()
    {
        baseArmor?.Drop();
    }

    public override void PickUp()
    {
        baseArmor?.PickUp();
    }
}