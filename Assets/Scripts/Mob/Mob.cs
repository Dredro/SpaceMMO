using UnityEngine;

namespace Mob
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private string name;
        [SerializeField] private int health;
        [SerializeField] private IMobBehaviour behaviour;
        public string Name { set => name = value; }
        public int Health {set => health = value; }
        public IMobBehaviour Behaviour
        {
            get => behaviour;
            set => behaviour = value; }

        public void PerformBehaviour()
        {
            Behaviour?.ExecuteBehaviour();
        }

        public void Initialize(string name, int health, IMobBehaviour behaviour)
        {
            Name = name;
            Health = health;
            Behaviour = behaviour;
        }
    }
}