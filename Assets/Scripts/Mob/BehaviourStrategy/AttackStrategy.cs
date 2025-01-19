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
                Debug.WriteLine("Player out of detection range. Switching to patrol.");
                controller.ChangeState(MobState.Patrol);
                controller.Animation.PlayMovement();
            }
        }

        private IEnumerator AttackWithDelay(MobController controller)
        {
            isAttacking = true;
            controller.Animation.PlayAttack();
            Debug.WriteLine("Attack initiated. Waiting for delay.");

            yield return new WaitForSeconds(controller.AttackDelay);

            float playerArmor = controller.Player.Stats.Armor;
            float finalDmg = Mathf.Max(1f, (100f / (100f + playerArmor)) * controller.Mob.AttackDamage);


            controller.Player.TakeDamage(finalDmg);
            Debug.WriteLine($"Damage dealt: {finalDmg} (Player Armor: {playerArmor}).");

            isAttacking = false;
            Debug.WriteLine("Attack completed.");
        }
    }
}