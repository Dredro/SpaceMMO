using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class Inventory
{
    public string id;
    public List<Item> items = new List<Item>();
}