using UnityEngine;

namespace InventorySystem
{
    public abstract class ItemDecorator : IItem
    {
        public IItem wrappedItem { get; set; }
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public GameObject GameObjectPrefab { get; set; }
        public Sprite Icon { get; set; }
        public bool Stackable { get; set; }
        public ItemDecorator(ItemDefinition definition)
        {
            Id = definition.id;
            ItemName = definition.itemName;
            Weight = definition.weight;
            Value = definition.value;
            GameObjectPrefab = definition.gameObjectPrefab;
            Icon = definition.icon;
            Stackable = definition.stackable;
        }

        public virtual bool Decorate(IItem item)
        {
            if (ReferenceEquals(this, item))
            {
                Debug.LogWarning("Cannot decorate self");
                return false;
            }
            if (wrappedItem is null)
            {
                wrappedItem = item;
                Value += wrappedItem.Value;
                ItemName += "+" + wrappedItem.ItemName;
                return true;
            }
            else
            {
                Debug.LogWarning("Cannot decorate decorator");
                return false;
            }
        }

        public virtual void Use()
        {
            Debug.Log($"Using {ItemName} decorator, value: {Value}!");
            wrappedItem?.Use();
        }

        
    }
}