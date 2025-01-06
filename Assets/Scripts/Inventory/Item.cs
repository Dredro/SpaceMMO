using System;
using UnityEngine;

[Serializable]
public abstract class Item : ScriptableObject
{
    [SerializeField] public string id;
    [SerializeField] public string name;
    [SerializeField] public int value;
    [SerializeField] public Sprite icon;
    public abstract void Use();
    public abstract void Drop();
    public abstract void PickUp();
}