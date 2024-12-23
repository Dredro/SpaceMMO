using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Inventory
{
    [SerializeField] public string id;
    [SerializeField] public List<Item> items;
}