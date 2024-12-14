using UnityEngine;

public class FireResistanceDecorator : ArmorDecorator
{
    public FireResistanceDecorator(Armor baseArmor) : base(baseArmor)
    {
        name = "Fire Resistant " + baseArmor?.name;
    }

    public override void Use()
    {
        Debug.Log("Adding fire resistance.");
        base.Use();
    }

    public override void Drop()
    {
        Debug.Log("Dropping fire-resistant armor.");
        base.Drop();
    }

    public override void PickUp()
    {
        Debug.Log("Picking up fire-resistant armor.");
        base.PickUp();
    }
}