using UnityEngine;
using UnityEngine.AI;

namespace MobSystem
{
    public class PatrolStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            if (!controller.NavAgent.hasPath)
            {
                var randomDirection = Random.insideUnitSphere * 20;
                randomDirection += controller.transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, 20, 1))
                {
                    controller.NavAgent.SetDestination(hit.position);
                }
            }

            controller.DetectPlayer();
            controller.Animation.PlayMovement();
        }
    }
}