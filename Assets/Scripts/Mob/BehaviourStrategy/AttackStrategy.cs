using UnityEngine;

namespace Mob
{
    public class AttackStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            float distance = Vector3.Distance(controller.transform.position, controller.Player.position);
            if (distance > controller.AttackRange)
            {
                controller.NavAgent.SetDestination(controller.Player.position);
            }
            else
            {
               // PlayerHealth playerHealth = controller.Player.GetComponent<PlayerHealth>();
                /*if (playerHealth != null)
                {
                    playerHealth.TakeDamage(controller.AttackDamage);
                    Debug.Log($"{controller.Mob.MobName} atakuje gracza!");
                }*/
            }
            
            if (distance > controller.DetectionRange)
            {
                controller.ChangeState(MobState.Patrol);
            }
        }
    }
}
