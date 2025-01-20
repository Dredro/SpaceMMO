using UnityEngine;

namespace InventorySystem
{
    public class Enhancer : MonoBehaviour
    {
        public InventorySlot itemToEnhanceSlot;
        public InventorySlot decoratorSlot;

        public void OnSubmit()
        {
            Upgrade();
        }
        
        private void Upgrade()
        {
            if (itemToEnhanceSlot == null)
            {
                Debug.LogError("Item to enhance slot is null");
                return;
            }
    
            if (decoratorSlot == null)
            {
                Debug.LogError("Decorator slot is null");
                return;
            }

            var itemToEnhance = itemToEnhanceSlot.GetComponentInChildren<InventoryItem>()?.itemController;
            if (itemToEnhance == null)
            {
                Debug.Log("Item slot empty");
                return;
            }

            var decorator = decoratorSlot.GetComponentInChildren<InventoryItem>()?.itemController;
            if (decorator == null)
            {
                Debug.Log("Decorator slot empty");
                return;
            }

            if (ItemManager.Instance.DecorateItem(itemToEnhance, decorator))
            {
                Destroy(itemToEnhanceSlot.GetComponentInChildren<InventoryItem>().gameObject);
                Destroy(decoratorSlot.GetComponentInChildren<InventoryItem>().gameObject);
                InventoryManager.instance.AddItem(decorator);
            }
          
        }

    }
}