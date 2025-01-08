using System;

namespace InventorySystem.Item
{
    public static class ItemFactory
    {
        public static IItem Create(ItemDefinition definition)
        {
            return definition.type switch
            {
                ItemType.Armor => new Armor(definition),
                ItemType.FireStoneDecorator => new FireStoneDecorator(definition),
                ItemType.Weapon => new Weapon(definition),
                ItemType.Tool => new Tool(definition),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}