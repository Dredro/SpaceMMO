using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController _instance;

    public static InventoryController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("InventoryController instance is null. Make sure an InventoryController is in the scene.");
            }
            return _instance;
        }
    }

    private readonly Dictionary<string, Inventory> _inventories = new Dictionary<string, Inventory>();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Multiple InventoryController instances detected. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        _instance = this;

        InitializeDefaultInventories();
    }

    private void InitializeDefaultInventories()
    {
        // Initialize player inventory
        _inventories["player:0"] = new Inventory { id = "player:0" };
        

        // Initialize NPC inventory
        _inventories["npc:0"] = new Inventory { id = "npc:0" };

        Debug.Log("Default inventories initialized for player and NPC.");
    }

    public void AddBasicArmorMock(string inventoryId)
    {
        var item = ScriptableObject.CreateInstance<BaseArmor>();

        item.defenseValue = 100;
        item.id = GUID.Generate().ToString();
        item.name = "Base Armor";
        item.value = 10;
        item.weight = 1000;

        AddItem(inventoryId, item);
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

    public void AddItem(string inventoryId, Item item)
    {
        if (_inventories.TryGetValue(inventoryId, out var inventory))
        {
            inventory.items.Add(item);
            Debug.Log($"Added {item.name} to inventory {inventoryId}.");
        }
        else
        {
            Debug.LogError($"Inventory with ID {inventoryId} not found. Cannot add item.");
        }
    }

    public void RemoveItem(string inventoryId, Item item)
    {
        if (_inventories.ContainsKey(inventoryId))
        {
            if (_inventories[inventoryId].items.Contains(item))
            {
                _inventories[inventoryId].items.Remove(item);
                Debug.Log($"Removed {item.name} from inventory {inventoryId}.");
            }
            else
            {
                Debug.Log($"Item {item.name} not found in inventory {inventoryId}.");
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