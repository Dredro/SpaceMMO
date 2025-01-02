using UnityEngine;
using UnityEngine.AI;

namespace Mob
{
    public class MobAI : MonoBehaviour
    {
        [Header("Patrol Settings")]
        public float patrolRadius = 20f;          // Promień, w którym będą generowane cele patrolowe
        public float waitTime = 2f;               // Czas oczekiwania na każdym celu

        [Header("Detection Settings")]
        public float detectionRadius = 10f;       // Promień wykrywania gracza
        public LayerMask playerLayer;             // Warstwa gracza

        private NavMeshAgent agent;
        public float waitTimer = 0f;
        private bool isWaiting = false;
        private bool isFollowingPlayer = false;

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

       

        // Ustawia losowy cel na NavMesh w obrębie patrolRadius
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
                    Debug.Log("Agent oczekuje na miejscu.");
                }
                else
                {
                    waitTimer += Time.deltaTime;
                    if (waitTimer >= waitTime)
                    {
                        isWaiting = false;
                        Debug.Log("Czas oczekiwania zakończony. Ustawianie nowego celu.");
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
                Debug.LogWarning("Player Transform is null w FollowPlayer.");
                return;
            }

            agent.SetDestination(player.position);
            Debug.Log($"Śledzenie gracza: {player.name}");
        }

        public void DetectAndFollowPlayer()
        {
            if (playerLayer == 0)
            {
                Debug.LogError("Player Layer nie jest ustawiona w skrypcie MobAI.");
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
                        Debug.Log("Gracz wykryty. Rozpoczynanie śledzenia.");
                    }
                    FollowPlayer(player);
                }
                else
                {
                    Debug.LogWarning("Player Transform jest null.");
                }
            }
            else
            {
                if (isFollowingPlayer)
                {
                    Debug.Log("Gracz nie jest już wykrywany. Powrót do patrolowania.");
                    isFollowingPlayer = false;
                    SetRandomDestination();
                }
            }
        }

        // Opcjonalnie: Wizualizacja promienia wykrywania i patrolu w Edytorze
        void OnDrawGizmosSelected()
        {
            // Rysuj promień wykrywania
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            // Rysuj promień patrolu
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, patrolRadius);
        }
    }
}
