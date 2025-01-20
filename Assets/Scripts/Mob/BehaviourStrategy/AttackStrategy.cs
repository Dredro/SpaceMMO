using System.Collections;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace MobSystem
{
    public class AttackStrategy : IBehaviourStrategy
    {
        private bool _isAttacking = false;

        public void Execute(MobController controller)
        {
            var distance = Vector3.Distance(controller.transform.position, controller.Player.transform.position);

            if (distance > controller.AttackRange)
            {
                controller.NavAgent.SetDestination(controller.Player.transform.position);
                controller.Animation.PlayMovement();
            }
            else if (!_isAttacking)
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
            _isAttacking = true;
            controller.Animation.PlayAttack();
            Debug.WriteLine("Attack initiated. Waiting for delay.");

            yield return new WaitForSeconds(controller.AttackDelay);

            float playerArmor = controller.Player.Stats.Armor;
            float finalDmg = Mathf.Max(1f, (100f / (100f + playerArmor)) * controller.Mob.AttackDamage);


            controller.Player.TakeDamage(finalDmg);
            Debug.WriteLine($"Damage dealt: {finalDmg} (Player Armor: {playerArmor}).");

            _isAttacking = false;
            Debug.WriteLine("Attack completed.");
        }
    }
}