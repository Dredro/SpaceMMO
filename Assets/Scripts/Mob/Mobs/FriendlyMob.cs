using System;

namespace Mob
{
    public class FriendlyMob : IMob
    {
        public string MobName { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }
        public int AttackDamage { get; set; }
        public IBehaviourStrategy BehaviourStrategy { get; set; } = new EscapeStrategy();

        public event Action OnDie;

        public FriendlyMob(MobDefinition definition)
        {
            MobName = definition.mobName;
            Health = definition.health;
            Speed = definition.speed;
            AttackDamage = definition.attackDamage;
        }
        public void TakeDamage(int value)
        {
            Health -= value;
            if(Health <= 0) OnDie?.Invoke();
        }
        
    }
}