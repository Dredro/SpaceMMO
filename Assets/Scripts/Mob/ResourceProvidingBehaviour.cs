using UnityEngine;

namespace Mob
{
    public class ResourceProvidingBehaviour : IMobBehaviour
    {
        public Inventory Inventory;

        
        public void ExecuteBehaviour(MobAI agent)
        {
            Inventory ??= InventoryController.Instance.GetInventory("mob:0");
            agent.Patrol();
        }

        public void Tame()
        {
            Debug.Log("ResourceProvidingBehaviour: Mob has been tamed.");
        }
    }
}