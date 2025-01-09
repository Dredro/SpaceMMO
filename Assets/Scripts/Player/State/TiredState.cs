public class TiredState : PlayerState
{
    public override void Rest()
    {
        if(_player.stats.Energy > 0) _player.SetState(new AliveState());
    }

    public override void TakeDamage(int value)
    {
        _player.stats.Health -= value;
        if(_player.stats.Health <= 0) _player.SetState(new DeadState());
    }

    public override void PerformAction()
    {
    }
}