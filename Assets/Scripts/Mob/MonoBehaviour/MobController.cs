using PlayerSystem;
using UnityEngine;
using UnityEngine.AI;

namespace MobSystem
{
    [RequireComponent(typeof(MobAnimation))]
    public class MobController : MonoBehaviour
    {
        [SerializeField] private MobDefinition definition;
        private IMob _mob;
        public IMob Mob => _mob;
        private NavMeshAgent _agent;
        public NavMeshAgent NavAgent => _agent;

        private Player _player;
        public Player Player => _player;

        public float DetectionRange = 10f;
        public float AttackRange = 2f;
        public float AttackDelay = 0.5f;
        private IBehaviourStrategy _currentStrategy;
        private MobState _currentState;
        public MobAnimation Animation;
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

            _player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();
            ChangeState(MobState.Patrol);
            Animation = GetComponent<MobAnimation>();
        }

        private void Update()
        {
            _currentStrategy?.Execute(this);
        }
        
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
        
        public void DetectPlayer()
        {
            if(!_player) return;
            float distance = Vector3.Distance(transform.position, _player.transform.position);
            if (distance <= DetectionRange)
            {
                if (_mob is AggressiveMob)
                {
                    ChangeState(MobState.Attack);
                }
            }
        }
        
        public void TakeDamage(int value)
        {
            _mob.TakeDamage(value);
            if (_mob is AggressiveMob || _mob is NeutralMob)
            {
                ChangeState(MobState.Attack);
            }
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
