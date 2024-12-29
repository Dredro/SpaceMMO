using UnityEngine;

[CreateAssetMenu(fileName = "New FireResistanceDecorator", menuName = "Inventory/Armor/Fire Resistance")]
public class FireResistanceDecorator : ArmorDecorator
{
    [SerializeField] private int fireResistanceBonus = 10;

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

    public void ApplyFireResistance()
    {
        if (baseArmor != null)
        {
            name = "Fire Resistant " + baseArmor.name;
            defenseValue = baseArmor.defenseValue + fireResistanceBonus;
        }
    }
}