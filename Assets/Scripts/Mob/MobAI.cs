using UnityEngine;
using UnityEngine.AI;

namespace Mob
{
    public class MobAI : MonoBehaviour
    {
        [Header("Patrol Settings")]
        public float patrolRadius = 20f;         
        public float waitTime = 2f;              
        [Header("Detection Settings")]
        public float detectionRadius = 10f;       
        public LayerMask playerLayer;           

        private NavMeshAgent agent;
        public float waitTimer = 0f;
        private bool isWaiting = false;
        private bool isFollowingPlayer = false;

        private float attackTimer = 0f;
        private float attackDelay = 2f;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            if (agent == null)
            {
                Debug.LogError("NavMeshAgent component not found on " + gameObject.name);
                return;
            }

            SetRandomDestination();
        }

        void SetRandomDestination()
        {
            Vector3 origin = transform.position;
            bool destinationSet = false;
            int attempts = 0;
            int maxAttempts = 10;

            while (!destinationSet && attempts < maxAttempts)
            {
                Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
                randomDirection += origin;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                    Debug.Log($"Nowy cel patrolowania ustawiony na: {hit.position}");
                    destinationSet = true;
                }
                else
                {
                    Debug.LogWarning($"Nie udało się znaleźć osiągalnego celu patrolowania przy próbie {attempts + 1}.");
                    attempts++;
                }
            }

            if (!destinationSet)
            {
                return;
            }
        }
        public void Attack(int damage)
        {
            if(attackTimer >= attackDelay)
            {   if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 1f))
                {
                    if (hit.transform.TryGetComponent(out Player player))
                    {
                        player.TakeDamage(damage);
                    }
                }

                attackTimer = 0;
            }
            else
            {
                attackTimer += Time.deltaTime;
            }
        }
        public void Patrol()
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
                return;
            }
          
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                if (!isWaiting)
                {
                    isWaiting = true;
                    waitTimer = 0f;
                    Debug.Log("Agent waiting!");
                }
                else
                {
                    waitTimer += Time.deltaTime;
                    if (waitTimer >= waitTime)
                    {
                        isWaiting = false;
                        Debug.Log("Agent set new target!");
                        SetRandomDestination();
                    }
                }
            }
        }


        public void FollowPlayer(Transform player)
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
                if (agent == null)
                {
                    return;
                }
            }

            if (player == null)
            {
                Debug.LogWarning("Player Transform is null in FollowPlayer.");
                return;
            }

            agent.SetDestination(player.position);
            Debug.Log($"Following player: {player.name}");
        }

        public void DetectAndFollowPlayer()
        {
            if (playerLayer == 0)
            {
                Debug.LogError("Player Layer is not set in MobAI.");
                return;
            }

            Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
            if (hits.Length > 0)
            {
                Transform player = hits[0].transform;
                if (player != null)
                {
                    if (!isFollowingPlayer)
                    {
                        isFollowingPlayer = true;
                        Debug.Log("Player detected!");
                    }
                    FollowPlayer(player);
                }
                else
                {
                    Debug.LogWarning("Player Transform is null.");
                }
            }
            else
            {
                if (isFollowingPlayer)
                {
                    Debug.Log("Player escape!");
                    isFollowingPlayer = false;
                    SetRandomDestination();
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, patrolRadius);
        }
    }
}
