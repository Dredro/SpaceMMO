using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using Object = UnityEngine.Object;


namespace InventorySystem
{
    [Serializable]
    public class Inventory
    {
        public string id;
        internal List<Item> items = new List<Item>();
        public int slots = 10;
    }
}