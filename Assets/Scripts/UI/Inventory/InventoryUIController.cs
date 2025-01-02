using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [Header("UI References")]
    public Transform slotContainer;
    public GameObject slotPrefab;
    public string inventoryId = "player:0";
    public int slotCount = 8;

    private Inventory _inventory;
    private List<InventorySlot> _slots = new List<InventorySlot>();

    private void OnEnable()
    {
        // Zasubskrybuj event z InventoryController
        InventoryController.OnItemAdded += HandleItemAdded;
    }

    private void OnDisable()
    {
        // Odsubskrybuj, żeby nie mieć wycieków i podwójnych wywołań
        InventoryController.OnItemAdded -= HandleItemAdded;
    }

    private void Start()
    {
        _inventory = InventoryController.Instance.GetInventory(inventoryId);
        slotCount = _inventory.slots;
        if (_inventory == null)
        {
            Debug.LogError($"[InventoryUIController] Nie odnaleziono ekwipunku o ID: {inventoryId}");
            return;
        }

        CreateSlots();
        RefreshUI();
    }

    private void CreateSlots()
    {
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }
        _slots.Clear();

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotContainer);
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();
            if (slot != null)
            {
                slot.SetupSlot(i, this);
                _slots.Add(slot);
            }
            else
            {
                Debug.LogError("[InventoryUIController] Prefab slotu nie posiada komponentu InventorySlot.");
            }
        }
    }

    public void RefreshUI()
    {
        if (_inventory == null) return;

        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < _inventory.items.Count)
            {
                _slots[i].SetItem(_inventory.items[i]);
            }
            else
            {
                _slots[i].SetItem(null);
            }
        }
    }

    public void OnItemDropped(int fromSlotIndex, int toSlotIndex)
    {
        if (_inventory == null) return;
        if (fromSlotIndex < 0 || fromSlotIndex >= _inventory.items.Count) return;
        if (toSlotIndex < 0 || toSlotIndex >= _slots.Count) return;

        Item draggedItem = _inventory.items[fromSlotIndex];
        if (toSlotIndex < _inventory.items.Count)
        {
            Item targetItem = _inventory.items[toSlotIndex];
            _inventory.items[toSlotIndex] = draggedItem;
            _inventory.items[fromSlotIndex] = targetItem;
        }
        else
        {
            _inventory.items.RemoveAt(fromSlotIndex);
            _inventory.items.Add(draggedItem);
        }

        RefreshUI();
    }

    public void UseItem(int slotIndex)
    {
        if (_inventory == null) return;
        if (slotIndex < 0 || slotIndex >= _inventory.items.Count) return;

        Item item = _inventory.items[slotIndex];
        if (item != null)
        {
            item.Use();
            Debug.Log($"[InventoryUIController] Użyto przedmiotu: {item.name}");
        }
    }

    /// <summary>
    /// Handler wywoływany, gdy InventoryController doda przedmiot do któregoś ekwipunku.
    /// </summary>
    private void HandleItemAdded(string invId, Item newItem)
    {
        // Jeśli dodano przedmiot do ekwipunku, który obecnie wyświetlamy – odśwież UI.
        if (invId == inventoryId)
        {
            RefreshUI();
            Debug.Log($"[InventoryUIController] Otrzymano event OnItemAdded dla ekwipunku {invId}. Odświeżam UI.");
        }
    }
}
