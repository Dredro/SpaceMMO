using UnityEngine;

namespace Mob
{
    public class ResourceProvidingBehaviour : IMobBehaviour
    {
        public Inventory Inventory;

        public void ExecuteBehaviour()
        {
            Inventory = InventoryController.Instance.GetInventory("mob:0");
            Debug.Log("ResourceProvidingBehaviour: Providing resources from inventory.");
        }

        public void Tame()
        {
            Debug.Log("ResourceProvidingBehaviour: Mob has been tamed.");
        }
    }
}