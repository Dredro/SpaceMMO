using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Armor")]
public class BaseArmor : Armor
{
    public override void Use()
    {
        Debug.Log($"Using {itemData.name} with {armorData.defenseValue} defense.");
    }

    public override void Drop()
    {
        Debug.Log($"Dropping {itemData.name}.");
    }

    public override void PickUp()
    {
        Debug.Log($"Picking up {itemData.name}.");
    }
}