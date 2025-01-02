using UnityEngine;

namespace Mob
{
    public class SupportingBehaviour : IMobBehaviour
    {
        public int HealAmount { get; set; }
        public Inventory Inventory { get; set; }

        public void ExecuteBehaviour()
        {
            Debug.Log($"SupportingBehaviour: Healing allies by {HealAmount}.");
        }

        public void Tame()
        {
            Debug.Log("SupportingBehaviour: Mob has been tamed.");
        }
    }
}