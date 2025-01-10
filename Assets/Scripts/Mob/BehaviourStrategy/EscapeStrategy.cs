using UnityEngine;
using UnityEngine.AI;

namespace Mob
{
    public class EscapeStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            Vector3 directionAway = controller.transform.position - controller.Player.position;
            Vector3 escapePosition = controller.transform.position + directionAway.normalized * 20;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(escapePosition, out hit, 20, 1))
            {
                controller.NavAgent.SetDestination(hit.position);
            }
            
            float distance = Vector3.Distance(controller.transform.position, controller.Player.position);
            if (distance > controller.DetectionRange + 10f)
            {
                controller.ChangeState(MobState.Patrol);
            }
        }
    }
}