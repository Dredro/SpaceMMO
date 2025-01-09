using Mob.Animation;
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

        // Timery i zasięgi ataku
        private float attackTimer = 2f;
        private float attackDelay = 2f;
        public float stopDistance = 1f;

        public AnimationController animationController;

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
                Debug.LogWarning("Nie znaleziono żadnego punktu do patrolowania.");
            }
        }

        /// <summary>
        /// Poprawiona metoda Attack z użyciem OverlapSphere.
        /// Sprawdza, czy w promieniu stopDistance od przeciwnika jest gracz.
        /// </summary>
        public void Attack(int damage)
        {
            // Sprawdzamy, czy możemy zaatakować (timer >= attackDelay)
            if (attackTimer >= attackDelay)
            {
                // Szukamy wszystkich obiektów w promieniu stopDistance
                Collider[] hits = Physics.OverlapSphere(transform.position, stopDistance);

                // Jeśli trafimy w gracza – zadajemy obrażenia i resetujemy timer
                foreach (var h in hits)
                {
                    if (h.TryGetComponent(out Player player))
                    {
                        animationController.PlayAttackAnimation();
                        player.TakeDamage(damage);

                        // Zerujemy timer tylko gdy faktycznie trafimy gracza
                        attackTimer = 0f;
                        return;
                    }
                }
            }
            else
            {
                // Odliczamy czas
                attackTimer += Time.deltaTime;
            }
        }

        /// <summary>
        /// Patrolowanie – AI wybiera losowy punkt i idzie do niego,
        /// czekając przez chwilę po dotarciu.
        /// </summary>
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

        /// <summary>
        /// AI podąża za graczem, jeśli jest w zasięgu.
        /// Zatrzymuje się, gdy jest zbyt blisko.
        /// </summary>
        public void FollowPlayer(Transform player)
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
                if (agent == null)
                {
                    Debug.LogWarning("NavMeshAgent component not found on this GameObject.");
                    return;
                }
            }

            if (player == null)
            {
                Debug.LogWarning("Player Transform is null in FollowPlayer.");
                return;
            }

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            
            if (distanceToPlayer <= stopDistance)
            {
                agent.isStopped = true;
                Debug.Log("Zbyt blisko gracza, zatrzymuję się.");
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(player.position);
                Debug.Log($"Podążam za graczem: {player.name}");
            }
        }

        /// <summary>
        /// Wykrywanie gracza w promieniu detectionRadius
        /// i ewentualne przejście do trybu śledzenia.
        /// </summary>
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
            // Niebieskie kółko pokazuje zasięg wykrywania gracza
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            // Zielone kółko pokazuje zasięg patrolu
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, patrolRadius);

            // Czerwone kółko pokazuje zasięg ataku (stopDistance)
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, stopDistance);
        }
    }
}
