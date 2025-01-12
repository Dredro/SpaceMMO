public class TiredState : PlayerState
{
    public override void Rest()
    {
        if(_player.Stats.Energy > 0) _player.SetState(new AliveState());
    }

    public override void TakeDamage(int value)
    {
        _player.Stats.Health -= value;
        if(_player.Stats.Health <= 0) _player.SetState(new DeadState());
    }

    public override void PerformAction()
    {
    }
}