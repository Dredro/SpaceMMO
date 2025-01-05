using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Inventory
{
    public class UIInventorySlot : MonoBehaviour,IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if(transform.childCount != 0) return;
            if (eventData.pointerDrag.TryGetComponent(out UIDragItem uiDragItem))
            {
                uiDragItem.nextParent = transform;
            }
        }
    }
}