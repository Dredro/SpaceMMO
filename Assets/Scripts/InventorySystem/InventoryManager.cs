using Input;
using InventorySystem.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager instance;
        
        public ItemController[] startItems;
        
        public int maxStackedItem = 255;
        [SerializeField] private GameObject inventoryItemPrefab;
        public InventorySlot[] inventorySlots;

        private int selectedSlot = -1;

        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ChangeSelectedSlot(0);
            foreach (var startItem in startItems)
            {
                var item = Instantiate(startItem, Vector3.negativeInfinity, Quaternion.identity);
                AddItem(item);
            }
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                var itemController = GetSelectedItem(false);
                if (itemController != null)
                {
                  itemController.Item.Use();
                }
            }
            if (UnityEngine.Input.inputString != null)
            {
                var isNumber = int.TryParse(UnityEngine.Input.inputString, out int number);
                if (isNumber && number >= 0 && number < 5)
                {
                    ChangeSelectedSlot(number-1);
                }
            }
        }

        public ItemController GetSelectedItem(bool use)
        {
            var slot = inventorySlots[selectedSlot];
            var itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                var item = itemInSlot.itemController;
                if (use)
                {
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCount();
                    }
                }
                return item;
            }
            return null;
        }
        void ChangeSelectedSlot(int value)
        {
            if(selectedSlot >= 0)
                inventorySlots[selectedSlot].Deselect();
            inventorySlots[value].Select();
            selectedSlot = value;
        }
        public bool AddItem(ItemController itemController)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                var slot = inventorySlots[i];
                var itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.itemController == itemController && itemInSlot.count < maxStackedItem && itemInSlot.stackable)
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true;
                }
            }
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                var slot = inventorySlots[i];
                var itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null)
                {
                    SpawnNewItem(itemController,slot);
                    return true;
                }
            }
            return false;
        }

        private void SpawnNewItem(ItemController itemController, InventorySlot slot)
        {
            var newItemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
            var inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(itemController);
        }
        

    }
}