using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class UIInventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private GameObject uiItemPrefab;
        [SerializeField] private GameObject content;
        [SerializeField] private List<UIInventorySlot> slots = new List<UIInventorySlot>();

        public string inventoryId = "player:0";
        private global::Inventory _inventory;

        private void Start()
        {
            _inventory = InventoryController.Instance.GetInventory(inventoryId);
            if (_inventory == null)
            {
                Debug.LogError($"Inventory with ID {inventoryId} not found!");
                return;
            }

            if (_inventory.items == null)
            {
                Debug.LogError("Inventory items are null!");
                return;
            }

            InitializeSlots();
            InitializeItems();
        }

        private void InitializeSlots()
        {
            int slotCount = _inventory.slots;
            for (int i = 0; i < slotCount; i++)
            {
                var slotInstance = Instantiate(slotPrefab, content.transform);
                if (slotInstance.TryGetComponent(out UIInventorySlot uiSlot))
                {
                    slots.Add(uiSlot);
                }
                else
                {
                    Debug.LogError($"Slot prefab is missing UISlot component in {gameObject.name}!");
                }
            }
        }

        private void InitializeItems()
        {
            var items = _inventory.items;
            for (int i = 0; i < items.Count; i++)
            {
                var uiSlot = slots[i];
                var uiItem = Instantiate(uiItemPrefab, uiSlot.transform);
                var image = uiItem.GetComponent<Image>();
                if (image != null)
                {
                    image.sprite = items[i].icon;
                }
                else
                {
                    Debug.LogError("UIItem prefab is missing an Image component!");
                }
                uiItem.name = items[i].name;
            }
        }

        private void OnEnable()
        {
           InventoryController.OnItemAdded += UpdateInventoryUI;
        }
        

        private void OnDisable()
        { 
            InventoryController.OnItemAdded -= UpdateInventoryUI;
        }

        private void UpdateInventoryUI(string id, Item updatedItem)
        {
            if(inventoryId != id) return;
            foreach (var slot in slots)
            {
                foreach (Transform child in slot.transform)
                {
                    Destroy(child.gameObject);
                }
            }

            InitializeItems();
        }
    }
}
