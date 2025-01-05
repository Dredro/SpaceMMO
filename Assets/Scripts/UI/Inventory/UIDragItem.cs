using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemId;
    private Image _image;
    [HideInInspector] public Transform nextParent;
    [HideInInspector] public Transform temporaryParent;

    private GameObject tempEmptyItem; 
    private void Start()
    {
        _image = GetComponent<Image>();
        
        tempEmptyItem = new GameObject("Empty");
        tempEmptyItem.transform.SetParent(transform);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       if(temporaryParent == null)
        nextParent = transform.parent;
       transform.SetParent(transform.root);
       transform.SetAsLastSibling();
       _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      Reset();
    }

    public void Reset()
    {
        if (temporaryParent != null)
        {
            tempEmptyItem.transform.SetParent(nextParent);
            transform.SetParent(temporaryParent);
        }
        else
        {
            tempEmptyItem.transform.SetParent(transform);
            transform.SetParent(nextParent);
        }
        _image.raycastTarget = true;
    }
}
