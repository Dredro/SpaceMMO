using System;
using UnityEngine;

[Serializable]
public class BaseArmor : Armor
{
    public override void Use()
    {
        Debug.Log($"Using {name}");
    }

    public override void Drop()
    {
        Debug.Log($"Dropping {name}");
    }

    public override void PickUp()
    {
        Debug.Log($"Picking up {name}");
    }
}