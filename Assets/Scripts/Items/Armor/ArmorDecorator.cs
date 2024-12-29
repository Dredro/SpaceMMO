using UnityEngine;

[CreateAssetMenu(fileName = "New ArmorDecorator", menuName = "Inventory/Armor/Decorator")]
public abstract class ArmorDecorator : Armor
{
    [SerializeField] protected Armor baseArmor;

    public void Init(Armor baseArmor)
    {
        this.baseArmor = baseArmor;

        if (baseArmor != null)
        {
            id = baseArmor.id;
            name = baseArmor.name;
            value = baseArmor.value;
            defenseValue = baseArmor.defenseValue;
            weight = baseArmor.weight;
        }
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