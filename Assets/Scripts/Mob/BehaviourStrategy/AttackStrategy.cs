using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Mob
{
    public class AttackStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            float distance = Vector3.Distance(controller.transform.position, controller.Player.position);

            // Jeśli gracz jest w zasięgu ataku
            if (distance <= controller.AttackRange && Time.time >= controller.NextAttackTime)
            {
                PerformAttack(controller);
            }
            else if (distance > controller.AttackRange)
            {
                controller.NavAgent.SetDestination(controller.Player.position);
                controller.Animation.PlayMovement();
            }

            // Jeśli gracz opuścił zasięg wykrywania
            if (distance > controller.DetectionRange)
            {
                controller.ChangeState(MobState.Patrol);
                controller.Animation.PlayMovement();
            }
        }

        private void PerformAttack(MobController controller)
        {
            // Animacja ataku
            controller.Animation.PlayAttack();

            // Zadaj obrażenia graczowi
            var player = controller.Player.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(controller.Mob.AttackDamage);
            }

            // Ustaw czas na kolejny możliwy atak
            controller.NextAttackTime = Time.time + controller.AttackCooldown;
        }
    }
}
