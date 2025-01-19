using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Mob
{
    public class AttackStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            float distance = Vector3.Distance(controller.transform.position, controller.Player.transform.position);
            if (distance > controller.AttackRange)
            {
                controller.NavAgent.SetDestination(controller.Player.transform.position);
                controller.Animation.PlayMovement();
            }
            else
            {
                controller.Animation.PlayAttack();
                controller.Player.TakeDamage(controller.Mob.AttackDamage);
            }
            
            if (distance > controller.DetectionRange)
            {
                controller.ChangeState(MobState.Patrol);
                controller.Animation.PlayMovement();
            }
        }
    }
}
