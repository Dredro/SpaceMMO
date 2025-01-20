using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        public ItemController itemController;
        public bool stackable;
        public int count = 1;

        [Header("UI elements")] 
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Image icon;
        [SerializeField] private Image decoratorIcon;
        public GameObject namePanel;
        public void InitialiseItem(ItemController itemController)
        {
            this.itemController = itemController;
    
            var currentItem = this.itemController.Item;
            itemName.text = currentItem.ItemName;
            if (currentItem is ItemDecorator itemDecorator && itemDecorator.wrappedItem != null)
            {
                decoratorIcon.gameObject.SetActive(true);
                icon.sprite = itemDecorator.wrappedItem.Icon;
                decoratorIcon.sprite = itemDecorator.Icon;
                stackable = itemDecorator.wrappedItem.Stackable;
            }
            else
            {
                decoratorIcon.gameObject.SetActive(false);
                icon.sprite = currentItem.Icon;
                stackable = currentItem.Stackable;
            }

            if (transform.parent.TryGetComponent(out InventorySlot slot))
            {
                namePanel.SetActive(!slot.isPlayerDeck);
            }
            RefreshCount();
        }


        public void RefreshCount()
        {
            countText.text = count.ToString();
            var textActive = count > 1;
            countText.gameObject.SetActive(textActive);
        }
    }
}