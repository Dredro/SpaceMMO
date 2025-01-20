using UnityEngine;

namespace InventorySystem
{
    public class Armor : IItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public GameObject GameObjectPrefab { get; set; }
        public Sprite Icon { get; set; }
        public bool Stackable { get; set; }
        public Armor(ItemDefinition definition)
        {
            Id = definition.id;
            ItemName = definition.itemName;
            Weight = definition.weight;
            Value = definition.value;
            GameObjectPrefab = definition.gameObjectPrefab;
            Icon = definition.icon;
            Stackable = definition.stackable;
        }
        public void Use()
        {
            Debug.Log($"Using armor value: {Value}");
        }
    }
}