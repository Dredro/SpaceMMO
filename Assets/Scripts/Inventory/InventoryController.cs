using System.Collections.Generic;
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

    private Inventory _inventory = new Inventory();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Multiple InventoryController instances detected. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public Inventory GetInventory(string id)
    {
        return _inventory;
    }

    public void AddItem(Inventory inventory,Item item)
    {
        inventory.items.Add(item);
        Debug.Log($"Added {item.name} to inventory.");
    }

    public void RemoveItem(Inventory inventory,Item item)
    {
        if (_inventory.items.Contains(item))
        {
            _inventory.items.Remove(item);
            Debug.Log($"Removed {item.name} from inventory.");
        }
        else
        {
            Debug.Log($"Item {item.name} not found in inventory.");
        }
    }

    public void DecorateArmorWithFireResistance(string armorId)
    {
        var armor = _inventory.items.Find(item => item is Armor && item.id == armorId) as Armor;
        if (armor != null)
        {
            var fireResistantArmor = new FireResistanceDecorator(armor);
            _inventory.items.Remove(armor);
            _inventory.items.Add(fireResistantArmor);
            Debug.Log($"Added fire resistance to {armor.name}. New item: {fireResistantArmor.name}");
        }
        else
        {
            Debug.Log($"Armor with ID {armorId} not found.");
        }
    }

    public void PrintInventory(Inventory inventory)
    {
        Debug.Log("Inventory:");
        foreach (var item in inventory.items)
        {
            Debug.Log($"- {item.name}");
        }
    }
}
