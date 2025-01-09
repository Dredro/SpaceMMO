using UnityEngine;

namespace Mob
{
    public class NeutralBehaviour : IMobBehaviour
    {
        public int Damage { get; set; }
        public bool playerAttackMe;
        public void ExecuteBehaviour(MobAI agent)
        {
            agent.Patrol();
            if (playerAttackMe)
            {
                agent.DetectAndFollowPlayer();
                agent.Attack(Damage);
                
            }
        }
        
        public void Tame()
        {
            if (playerAttackMe) return;
        }
    }
}