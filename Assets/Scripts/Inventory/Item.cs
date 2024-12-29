using System;
using UnityEngine;

[Serializable]
public abstract class Item
{
    [SerializeField] public string id;
    [SerializeField] public string name;
    [SerializeField] public int value;

    public abstract void Use();
    public abstract void Drop();
    public abstract void PickUp();
}