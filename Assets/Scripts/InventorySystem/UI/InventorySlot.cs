using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        public Image image;
        public Color selectedColor, notSelectedColor;
        private Color headColor;
        private Vector3 originalPosition;
        public Image headImage;
        public RectTransform head;
        public bool isPlayerDeck;
        private void Awake()
        {
            if (head != null)
            {
                isPlayerDeck = true;
                originalPosition = head.localPosition;
                headImage = transform.parent.GetComponent<Image>();
                headColor = headImage.color;
            }
            Deselect();
        }

        public void Select()
        {
            if(!isPlayerDeck) return;
            image.color = selectedColor;
            if (head != null)
            {
                headImage.color = selectedColor;
                head.localPosition += new Vector3(0, 5, 0);
            }
        }

        public void Deselect()
        {
            if(!isPlayerDeck) return;
            image.color = notSelectedColor;
            if (head != null)
            {
                headImage.color = headColor;
                head.localPosition = originalPosition;
            }
        }
        public void OnDrop(PointerEventData eventData)
        {
            if(transform.childCount != 0) return;
            var droppedItem = eventData.pointerDrag;
            if (droppedItem.TryGetComponent(out DraggableItem draggableItem))
            {
                draggableItem.parentAfterDrag = transform;
                draggableItem.GetComponent<InventoryItem>().namePanel.SetActive(!isPlayerDeck);
            }
        }
    }
}