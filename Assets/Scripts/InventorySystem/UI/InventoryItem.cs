using System;
using InventorySystem.Item;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace InventorySystem.UI
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
        public void InitialiseItem(ItemController itemController)
        {
            this.itemController = itemController;
    
            var currentItem = this.itemController.Item;
    
            if (currentItem is ItemDecorator itemDecorator && itemDecorator.wrappedItem != null)
            {
                decoratorIcon.gameObject.SetActive(true);
                icon.sprite = itemDecorator.wrappedItem.Icon;
                decoratorIcon.sprite = itemDecorator.Icon;
                itemName.text = itemDecorator.wrappedItem.ItemName;
                stackable = itemDecorator.wrappedItem.Stackable;
            }
            else
            {
                decoratorIcon.gameObject.SetActive(false);
                icon.sprite = currentItem.Icon;
                itemName.text = currentItem.ItemName;
                stackable = currentItem.Stackable;
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