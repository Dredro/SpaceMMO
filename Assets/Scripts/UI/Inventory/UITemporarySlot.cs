using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Inventory
{
    public class UITemporarySlot : MonoBehaviour,IDropHandler
    {
        public UIDragItem itemInSlot;
      
        public void OnDrop(PointerEventData eventData)
        {
            if(transform.childCount != 0) return;
            if (eventData.pointerDrag.TryGetComponent(out UIDragItem uiDragItem))
            {
                uiDragItem.temporaryParent = transform;
                itemInSlot = uiDragItem;
            }
        }

        public void OnHide()
        { 
            if(itemInSlot == null) return;
            itemInSlot.temporaryParent = null; 
            itemInSlot.transform.SetParent(transform.root);
            itemInSlot.Reset();
        }
        
    }
}