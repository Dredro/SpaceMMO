using System;
using UnityEngine;

namespace NPC
{
    public class Enhancer : NPC
    {
        public Inventory Inventory;

        public override void Talk()
        {
            Debug.Log($"Welcome to my shop! Take a look at my wares.");
        }

        private void Start()
        {
            Inventory = InventoryController.Instance.GetInventory("npc:0");
        }
        
        public void DecorateArmorWithFireResistance(Armor armor)
        {
            if (armor != null)
            {
                var fireResistantArmor = ScriptableObject.CreateInstance<FireResistanceDecorator>();

                fireResistantArmor.Init(armor);
                fireResistantArmor.ApplyFireResistance();

                armor = fireResistantArmor;

                Debug.Log($"Added fire resistance to {armor.name}. New item: {fireResistantArmor.name}");
            }
        }
    }
}