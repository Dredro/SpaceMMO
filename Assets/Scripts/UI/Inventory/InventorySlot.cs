using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Components")]
    public Image icon;             // Ikona przedmiotu
    public TextMeshProUGUI itemNameText;      // Tekst wyświetlający nazwę przedmiotu
    public Button useButton;       // Przycisk do użycia przedmiotu (opcjonalnie)

    [SerializeField]
    private int _slotIndex;

    public int SlotIndex => _slotIndex;

    private InventoryUIController _inventoryUI;
    private Item _item;

    /// <summary>
    /// Metoda wywoływana przez InventoryUIController 
    /// w momencie tworzenia slotu.
    /// </summary>
    public void SetupSlot(int slotIndex, InventoryUIController inventoryUI)
    {
        _slotIndex = slotIndex;
        _inventoryUI = inventoryUI;

        // Podpinamy zdarzenie pod przycisk "Use" (jeśli istnieje)
        if (useButton != null)
        {
            useButton.onClick.RemoveAllListeners();
            useButton.onClick.AddListener(OnUseItem);
        }
    }

    /// <summary>
    /// Ustawia (lub czyści) przedmiot w slocie i aktualizuje wyświetlaną nazwę, ikonę itd.
    /// </summary>
    public void SetItem(Item newItem)
    {
        _item = newItem;

        if (_item != null)
        {
            // Slot ma przedmiot -> wypełnij ikonę, nazwę, włącz przycisk Use
            if (itemNameText != null)
                itemNameText.text = _item.name;

            if (icon != null)
            {
                icon.enabled = true;
                icon.sprite = GetItemSprite(_item);
            }

            // Włączamy przycisk
            if (useButton != null)
                useButton.gameObject.SetActive(true);
        }
        else
        {
            // Slot jest pusty -> wyczyść UI i WYŁĄCZ przycisk Use
            if (itemNameText != null)
                itemNameText.text = "";

            if (icon != null)
            {
                icon.enabled = false;
                icon.sprite = null;
            }

            // Wyłączamy przycisk
            if (useButton != null)
                useButton.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Zwraca indeks tego slotu w ekwipunku (ustawiany w SetupSlot).
    /// </summary>
    public int GetSlotIndex()
    {
        return _slotIndex;
    }

    /// <summary>
    /// Obsługa przycisku "Use" (jeśli go używasz w UI).
    /// </summary>
    private void OnUseItem()
    {
        if (_item != null && _inventoryUI != null)
        {
            // Wywołaj metodę UseItem w InventoryUIController,
            // która np. wywołuje item.Use()
            _inventoryUI.UseItem(_slotIndex);
        }
    }

    /// <summary>
    /// Metoda pomocnicza do pobierania sprite'a z przedmiotu (jeśli w Item jest pole "public Sprite icon;").
    /// </summary>
    private Sprite GetItemSprite(Item item)
    {
        // Zakładamy, że w Item albo w jego klasach dziedziczących jest public Sprite icon;
        // return item.icon;

        // Jeżeli go nie ma, a chcesz placeholder, to zwróć placeholder:
        return null;
    }
}
