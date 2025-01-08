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

        private void Awake()
        {
            Deselect();
        }

        public void Select()
        {
            image.color = selectedColor;
        }

        public void Deselect()
        {
            image.color = notSelectedColor;
        }
        public void OnDrop(PointerEventData eventData)
        {
            if(transform.childCount != 0) return;
            var droppedItem = eventData.pointerDrag;
            if (droppedItem.TryGetComponent(out DraggableItem draggableItem))
            {
                draggableItem.parentAfterDrag = transform;
            }
        }
    }
}