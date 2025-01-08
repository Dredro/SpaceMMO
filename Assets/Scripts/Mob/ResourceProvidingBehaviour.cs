using UnityEngine;

namespace Mob
{
    public class ResourceProvidingBehaviour : IMobBehaviour
    {
        public void ExecuteBehaviour(MobAI agent)
        {
            agent.Patrol();
        }

        public void Tame()
        {
            Debug.Log("ResourceProvidingBehaviour: Mob has been tamed.");
        }
    }
}