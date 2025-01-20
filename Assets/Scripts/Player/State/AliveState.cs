namespace PlayerSystem
{
    public class AliveState : PlayerState
    {
        public override void StateEnter()
        {

        }

        public override void TakeDamage(float value)
        {
            _player.Stats.Health -= value;
            if (_player.Stats.Health <= 0) _player.SetState(new DeadState());
        }

        public override void StateUpdate()
        {
            if (_player.Stats.Energy < 80) _player.SetState(new TiredState());
        }
    }
}