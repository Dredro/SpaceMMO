using System.Collections;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Mob
{
    public class AttackStrategy : IBehaviourStrategy
    {
        private bool isAttacking = false;
        
        public void Execute(MobController controller)
        {
            float distance = Vector3.Distance(controller.transform.position, controller.Player.transform.position);
            
            if (distance > controller.AttackRange)
            {
                controller.NavAgent.SetDestination(controller.Player.transform.position);
                controller.Animation.PlayMovement();
            }
            else if (!isAttacking) 
            {
                controller.StartCoroutine(AttackWithDelay(controller));
            }

            if (distance > controller.DetectionRange)
            {
                controller.ChangeState(MobState.Patrol);
                controller.Animation.PlayMovement();
            }
        }
        
        private IEnumerator AttackWithDelay(MobController controller)
        {
            isAttacking = true;
            controller.Animation.PlayAttack(); 
            
            yield return new WaitForSeconds(controller.AttackDelay);

            controller.Player.TakeDamage(controller.Mob.AttackDamage);

            isAttacking = false; 
        }
    }
}