using UnityEngine;

namespace InventorySystem.Item
{
    public class Weapon : IItem
    {   
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public GameObject GameObjectPrefab { get; set; }
        public Sprite Icon { get; set; }
        public bool Stackable { get; set; }
        public Weapon(ItemDefinition definition)
        {
            Id = definition.id;
            ItemName = definition.itemName;
            Weight = definition.weight;
            Value = definition.value;
            GameObjectPrefab = definition.gameObjectPrefab;
            Icon = definition.icon;
            Stackable = definition.stackable;
        }

        public ItemDefinition Definition { get; set; }
        public void Use()
        {
            
        }
    }
}