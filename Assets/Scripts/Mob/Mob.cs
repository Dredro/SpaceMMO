using System;
using UnityEngine;

namespace Mob
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private string name;
        [SerializeField] private int health;
        [SerializeField] private IMobBehaviour behaviour;
        private MobAI _mobAI;
        public string Name { set => name = value; }
        public int Health {set => health = value; }

        private void Awake()
        {
            _mobAI = GetComponent<MobAI>();
        }

        private void Update()
        {
            PerformBehaviour();
        }

        public IMobBehaviour Behaviour
        {
            get => behaviour;
            set => behaviour = value; }

        public void PerformBehaviour()
        {
            Behaviour?.ExecuteBehaviour(_mobAI);
        }

        public void Initialize(string name, int health, IMobBehaviour behaviour)
        {
            Name = name;
            Health = health;
            Behaviour = behaviour;
        }
    }
}