using System;

namespace InventorySystem
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
                ItemType.Coal => new CoalDecorator(definition),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}