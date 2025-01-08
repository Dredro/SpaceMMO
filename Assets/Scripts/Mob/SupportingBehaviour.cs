using UnityEngine;

namespace Mob
{
    public class SupportingBehaviour : IMobBehaviour
    {
        public int HealAmount { get; set; }

        public void ExecuteBehaviour(MobAI agent)
        {
            agent.Patrol();
        }

        public void Tame()
        {
            Debug.Log("SupportingBehaviour: Mob has been tamed.");
        }
    }
}