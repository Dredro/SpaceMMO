using System;
using InventorySystem;
using UnityEngine;

namespace NPC
{
    public class ShopKeeper : NPC
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

        public void Trade(Item item)
        {
            if (Inventory != null && Inventory.items.Contains(item))
            {
                Debug.Log($"You have purchased: {item.name}.");
                Inventory.items.Remove(item);
            }
            else
            {
                Debug.Log($"Sorry, I don't have {item.name} in stock.");
            }
        }
       
    }
}