using UnityEngine;

namespace Mob
{
    public class MobBuilder
    {
        private Mob _mob;

        public MobBuilder(Mob mob)
        {
            _mob = mob;
        }

        public MobBuilder SetName(string name)
        {
            _mob.Name = name;
            return this;
        }

        public MobBuilder SetHealth(int health)
        {
            _mob.Health = health;
            return this;
        }

        public MobBuilder SetBehaviour(IMobBehaviour behaviour)
        {
            _mob.Behaviour = behaviour;
            return this;
        }

        public Mob Build()
        {
            return _mob;
        }
    }
}