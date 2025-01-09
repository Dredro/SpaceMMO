using UnityEngine;

namespace Mob
{
    public class NeutralBehaviour : IMobBehaviour
    {
        public bool playerAttackMe;
        public void ExecuteBehaviour(MobAI agent)
        {
            agent.Patrol();
            if(playerAttackMe)
                agent.DetectAndFollowPlayer();
        }
        
        public void Tame()
        {
            if (playerAttackMe) return;
        }
    }
}