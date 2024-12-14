using UnityEngine;

namespace Mob
{
    public class MobBuilder
    {
        private Mob _mob;
        public Mob Build()
        {
            return _mob;
        }

        public void SetName(string Name)
        {
            _mob.Name = Name;
        }

        public void SetHealth(int health)
        {
            _mob.Health = health;
        }

        public void SetBehaviour(MobBehaviour behaviour)
        {
            _mob.Behaviour = behaviour;
        }
    }
}