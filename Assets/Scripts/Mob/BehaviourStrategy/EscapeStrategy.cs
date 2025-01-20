using UnityEngine;
using UnityEngine.AI;

namespace MobSystem{
    public class EscapeStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            var directionAway = controller.transform.position - controller.Player.transform.position;
            var escapePosition = controller.transform.position + directionAway.normalized * 20;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(escapePosition, out hit, 20, 1))
            {
                controller.NavAgent.SetDestination(hit.position);
            }
            
            var distance = Vector3.Distance(controller.transform.position, controller.Player.transform.position);
            if (distance > controller.DetectionRange + 10f)
            {
                controller.ChangeState(MobState.Patrol);
            }
            controller.Animation.PlayMovement();
        }
    }
}