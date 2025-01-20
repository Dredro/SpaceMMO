using PlayerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class ArmorSlot : MonoBehaviour, IDropHandler
    {
        [Header("UI elements")] [SerializeField]
        private TextMeshProUGUI armorValue;

        private IItem _armor;

        private void Awake()
        {
            if (_armor == null)
            {
                SetArmorValue(0);
            }
            else
            {
                SetArmorValue(_armor.Value);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount != 0) return;

            if (eventData.pointerDrag.TryGetComponent(out DraggableItem draggableItem) &&
                eventData.pointerDrag.TryGetComponent(out InventoryItem item))
            {
                _armor = item.itemController.Item;
                SetArmorValue(_armor.Value);
                draggableItem.parentAfterDrag = transform;
            }
        }

        public void SetArmorValue(int value)
        {
            armorValue.text = value.ToString();
            StatsController.Instance.SetArmor(value);
        }
    }
}