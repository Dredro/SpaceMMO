using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class DraggableItem : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private Image image;
        [HideInInspector] public Transform parentAfterDrag;
        
        private void Start()
        {
            image = GetComponent<Image>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = UnityEngine.Input.mousePosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (parentAfterDrag&&parentAfterDrag.TryGetComponent(out ArmorSlot armorSlot))
            {
                armorSlot.SetArmorValue(0);
            }
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }   

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }
    }
}