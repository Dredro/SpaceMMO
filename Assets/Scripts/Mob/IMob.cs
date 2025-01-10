using System;

namespace Mob
{
    public interface IMob
    {
        public string MobName { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }
        public int AttackDamage { get; set; }
        public IBehaviourStrategy BehaviourStrategy { get; set; }
        public event Action OnDie;

        public void TakeDamage(int value);
    }
}