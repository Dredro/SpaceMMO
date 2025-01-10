using UnityEngine;
using UnityEngine.AI;

namespace Mob
{
    public class PatrolStrategy : IBehaviourStrategy
    {
        public void Execute(MobController controller)
        {
            if (!controller.NavAgent.hasPath)
            {
                Vector3 randomDirection = Random.insideUnitSphere * 20;
                randomDirection += controller.transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, 20, 1))
                {
                    controller.NavAgent.SetDestination(hit.position);
                }
            }

            controller.DetectPlayer();
        }
    }
}