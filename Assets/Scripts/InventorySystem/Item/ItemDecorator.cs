using UnityEngine;

namespace InventorySystem.Item
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

        public virtual void Decorate(IItem item)
        {
            if (ReferenceEquals(this, item))
            {
                Debug.LogWarning("Cannot decorate self");
                return;
            }
            if (wrappedItem is ItemDecorator decorator)
            {
                decorator.Decorate(item);
            }
            else
            {
                wrappedItem = item;
            }
        }
        public virtual void Use()
        {
            Debug.Log($"Using {ItemName} decorator, value: {Value}!");
            wrappedItem?.Use();
        }
    }
}