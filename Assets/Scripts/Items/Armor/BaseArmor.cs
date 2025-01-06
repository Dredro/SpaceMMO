using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Armor")]
public class BaseArmor : Armor
{
    public override void Use()
    {
        Debug.Log($"Using {name} with {defenseValue} defense.");
    }

    public override void Drop()
    {
        Debug.Log($"Dropping {name}.");
    }

    public override void PickUp()
    {
        Debug.Log($"Picking up {name}.");
    }
}