using System.Collections;
using UnityEngine;

namespace PlayerSystem
{
    public class TiredState : PlayerState
    {
        public override void StateEnter()
        {
            _player.StartCoroutine(Rest());
        }

        private IEnumerator Rest()
        {
            while (_player.Stats.Energy < 100)
            {
                _player.Stats.Energy++;
                yield return new WaitForSeconds(3f);
            }
        }

        public override void TakeDamage(float value)
        {
            _player.Stats.Health -= value;
            if (_player.Stats.Health <= 0)
            {
                _player.SetState(new DeadState());
            }
        }

        public override void StateUpdate()
        {
            if (_player.Stats.Energy >= 100)
            {
                _player.SetState(new AliveState());
            }

            _player.SetCanRun(_player.Stats.Energy > 0);
        }
    }
}