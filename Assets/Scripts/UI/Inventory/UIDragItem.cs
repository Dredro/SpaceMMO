using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(InventorySlot))]
public class UIDragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;

    // Referencje do komponentów InventorySlot i InventoryUIController
    private InventorySlot _inventorySlot;
    private InventoryUIController _inventoryUI;

    // Pozycja startowa i rodzic na potrzeby przywrócenia pozycji w razie nieudanego dropu
    private Vector3 _startPosition;
    private Transform _startParent;

    private void Awake()
    {
        // Pobieramy Canvas z rodzica
        _canvas = GetComponentInParent<Canvas>();
        if (_canvas == null)
        {
            Debug.LogError("Canvas nie został znaleziony w rodzicach.");
            return;
        }

        // Pobieramy lub dodajemy CanvasGroup
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
        {
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Pobieramy RectTransform
        _rectTransform = GetComponent<RectTransform>();
        if (_rectTransform == null)
        {
            Debug.LogError("RectTransform nie został znaleziony na obiekcie.");
            return;
        }

        // Pobieramy InventorySlot
        _inventorySlot = GetComponent<InventorySlot>();
        if (_inventorySlot == null)
        {
            Debug.LogError("InventorySlot jest wymagany na tym obiekcie.");
            return;
        }

        // Pobieramy InventoryUIController z rodzica
        _inventoryUI = _inventorySlot.GetComponentInParent<InventoryUIController>();
        if (_inventoryUI == null)
        {
            Debug.LogError("InventoryUIController nie został znaleziony w rodzicach InventorySlot.");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
     transform.SetParent(_startParent);
    }
}
