using System;
using InventorySystem.Item;
using InventorySystem.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorSlot : MonoBehaviour,IDropHandler
{
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI armorValue;

    private IItem _armor;

    private void Awake()
    {
        switch (_armor)
        {
            case null:
                SetArmorValue(0);
                break;
            case Armor:
                SetArmorValue(_armor.Value);
                break;
            case ItemDecorator itemDecorator:
                SetArmorValue(_armor.Value+itemDecorator.Value);
                break;
        }
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0) return;

        if (eventData.pointerDrag.TryGetComponent(out DraggableItem draggableItem) &&
            eventData.pointerDrag.TryGetComponent(out InventoryItem item))
        {
            var itemInterface = item.itemController.Item;

            if (itemInterface is Armor armor)
            {
                SetArmorValue(armor.Value);
                draggableItem.parentAfterDrag = transform;
                _armor = armor;
            }
            else if (itemInterface is ItemDecorator { wrappedItem: Armor decoratedArmor } decorator)
            {
                SetArmorValue(decoratedArmor.Value + decorator.Value);
                draggableItem.parentAfterDrag = transform;
                _armor = decorator;
            }
        }
    }
    public void SetArmorValue(int value)
    {
        StatsController.Instance.ChangeArmorStat(value);
        armorValue.text = value.ToString();
    }
}
