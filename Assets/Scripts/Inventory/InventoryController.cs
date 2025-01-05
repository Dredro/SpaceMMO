using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        private static InventoryController _instance;
        public static event Action<string, Item> OnItemAdded;

        public static InventoryController Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError(
                        "InventoryController instance is null. Make sure an InventoryController is in the scene.");
                }

                return _instance;
            }
        }

        [SerializeField] private List<Item> starterPack;
        [SerializeField] private List<Item> items;
        private readonly Dictionary<string, Inventory> _inventories = new Dictionary<string, Inventory>();
        private readonly Dictionary<string, Item> _items = new Dictionary<string, Item>();

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.LogWarning("Multiple InventoryController instances detected. Destroying duplicate.");
                Destroy(gameObject);
                return;
            }

            _instance = this;
            InitializeItemsFromUnityInspector();
            InitializeDefaultInventories();
        }

        public void GetStarterPack(string inventoryId)
        {
            foreach (var item in starterPack)
            {
                AddItem(inventoryId,item.id);
            }
        }
        private void InitializeItemsFromUnityInspector()
        {
            foreach (var item in items)
            {
                _items.Add(item.id,item);
            }

        }
        private void InitializeDefaultInventories()
        {
            // Initialize player inventory
            _inventories["player:0"] = new Inventory { id = "player:0" };


            // Initialize NPC inventory
            _inventories["npc:0"] = new Inventory { id = "npc:0" };

            Debug.Log("Default inventories initialized for player and NPC.");
        }


        public Inventory GetInventory(string id)
        {
            if (_inventories.TryGetValue(id, out var inventory))
            {
                return inventory;
            }
            else
            {
                Debug.LogError($"Inventory with ID {id} not found.");
                return null;
            }
        }

        public void AddItem(string inventoryId, string itemId)
        {
            if (_inventories.TryGetValue(inventoryId, out var inventory))
            {
                if (inventory.items.Count >= inventory.slots)
                {
                    Debug.Log($"Inventory is full.");
                    return;
                }

                if (_items.TryGetValue(itemId, out var item))
                {
                    inventory.items.Add(item);
                    Debug.Log($"Added {item.name} to inventory {inventoryId}.");

                    OnItemAdded?.Invoke(inventoryId, item);
                }
                else
                {
                    Debug.Log("Item not found in database");
                }
            }
            else
            {
                Debug.LogError($"Inventory with ID {inventoryId} not found. Cannot add item.");
            }
        }

        public void RemoveItem(string inventoryId, string itemId)
        {
            if (_inventories.ContainsKey(inventoryId))
            {
                if (_inventories.ContainsKey(itemId))
                {
                    if (_inventories[inventoryId].items.Contains(_items[itemId]))
                    {
                        _inventories[inventoryId].items.Remove(_items[itemId]);
                        Debug.Log($"Removed {_items[itemId].name} from inventory {inventoryId}.");
                    }
                    else
                    {
                        Debug.Log($"Item {_items[itemId].name} not found in inventory {inventoryId}.");
                    }
                }
                else
                {
                    Debug.Log("Item not found in database!");
                }
            }
            else
            {
                Debug.LogError($"Inventory with ID {inventoryId} not found. Cannot remove item.");
            }
        }


        public void PrintInventory(string inventoryId)
        {
            if (_inventories.ContainsKey(inventoryId))
            {
                Debug.Log($"Inventory {inventoryId}:");
                foreach (var item in _inventories[inventoryId].items)
                {
                    Debug.Log($"- {item.name}");
                }
            }
            else
            {
                Debug.LogError($"Inventory with ID {inventoryId} not found. Cannot print inventory.");
            }
        }
    }
}