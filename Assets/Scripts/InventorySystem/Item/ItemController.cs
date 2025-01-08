using System;
using InventorySystem.Item;
using UnityEngine;

namespace InventorySystem
{
    public class ItemController : MonoBehaviour
    {
        public IItem Item { get; set; }
        [SerializeField] private ItemDefinition definition;
        private void Awake() => Item = ItemFactory.Create(definition);
        
    }
}