using Mob.Mobs;
using UnityEngine;
using UnityEngine.AI;

namespace Mob
{
    [RequireComponent(typeof(MobAnimation))]
    public class MobController : MonoBehaviour
    {
        [SerializeField] private MobDefinition definition;
        private IMob _mob;
        private NavMeshAgent _agent;
        public NavMeshAgent NavAgent => _agent;

        private Transform _player;
        public Transform Player => _player;

        public float DetectionRange = 10f;
        public float AttackRange = 2f;

        private IBehaviourStrategy _currentStrategy;
        private MobState _currentState;
        public MobAnimation animation;
        private void Awake()
        {
            _mob = MobFactory.Create(definition);
            _mob.OnDie += HandleDeath;
        }

        private void Start()
        {
            if (TryGetComponent(out NavMeshAgent agent))
            {
                _agent = agent;
                _agent.speed = _mob.Speed;
            }
            else
            {
                Debug.LogError($"NavMeshAgent component not found in GameObject {name}");
            }

            _player = GameObject.FindGameObjectWithTag("Player").transform;
            ChangeState(MobState.Patrol);
            animation = GetComponent<MobAnimation>();
        }

        private void Update()
        {
            _currentStrategy?.Execute(this);
        }

        /// <summary>
        /// Zmiana stanu moba i przypisanie nowej strategii.
        /// </summary>
        public void ChangeState(MobState newState)
        {
            _currentState = newState;
            switch (_currentState)
            {
                case MobState.Patrol:
                    _currentStrategy = new PatrolStrategy();
                    break;

                case MobState.Attack:
                    // Agresywne i NEUTRALNE moby atakują, gdy są w stanie Attack
                    if (_mob is AggressiveMob || _mob is NeutralMob)
                    {
                        _currentStrategy = new AttackStrategy();
                    }
                    // Przyjazne moby w stanie Attack de facto nie atakują,
                    // ale jeśli z jakichś przyczyn tu trafią, ustawimy im strategię „ucieczki”
                    else if (_mob is FriendlyMob)
                    {
                        _currentStrategy = new EscapeStrategy();
                    }
                    break;

                case MobState.Escape:
                    // Dotyczy friendly mobów (lub każdej innej sytuacji, gdzie trzeba uciekać)
                    _currentStrategy = new EscapeStrategy();
                    break;
            }
        }

        /// <summary>
        /// Wykrywanie gracza: tylko agresywne moby rozpoczynają atak od razu
        /// (neutralne i friendly pozostają w patrolu, dopóki nie zostaną zaatakowane).
        /// </summary>
        public void DetectPlayer()
        {
            float distance = Vector3.Distance(transform.position, _player.position);
            if (distance <= DetectionRange)
            {
                // Tylko agresywny mob atakuje po wykryciu
                if (_mob is AggressiveMob)
                {
                    ChangeState(MobState.Attack);
                }
                // Neutralny i przyjazny mob NIC nie robią (pozostają w patrolu),
                // dopóki nie zostaną zaatakowane.
            }
        }
        
        public void TakeDamage(int value)
        {
            _mob.TakeDamage(value);
            // Agresywny lub neutralny mob – przechodzi do ataku w odpowiedzi na obrażenia
            if (_mob is AggressiveMob || _mob is NeutralMob)
            {
                ChangeState(MobState.Attack);
            }
            // Przyjazny mob – ucieka w odpowiedzi na atak
            else if (_mob is FriendlyMob)
            {
                ChangeState(MobState.Escape);
            }
        }

        private void HandleDeath()
        {
            Destroy(gameObject);
        }
    }

    public enum MobState
    {
        Patrol,
        Attack,
        Escape
    }
}
