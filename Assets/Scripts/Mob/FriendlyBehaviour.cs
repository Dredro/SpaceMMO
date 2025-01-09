using UnityEngine;

namespace Mob
{
    public class FriendlyBehaviour : IMobBehaviour
    {
        public void ExecuteBehaviour(MobAI agent)
        {
            agent.Patrol();
        }

        public void Tame()
        {
            Debug.Log("Mob has been tamed.");
        }
    }
}