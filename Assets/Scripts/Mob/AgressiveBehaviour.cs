using UnityEngine;

namespace Mob
{
    public class AggressiveBehaviour : IMobBehaviour
    {
        public int Damage { get; set; }

        public void ExecuteBehaviour(MobAI agent)
        {
            agent.Patrol();
            agent.DetectAndFollowPlayer();
        }
    }
}