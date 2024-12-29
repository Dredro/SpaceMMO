using System;
using UnityEngine;

[Serializable]
public abstract class Armor : Item
{
    [SerializeField] public int defenseValue;
    [SerializeField] public float weight;
}