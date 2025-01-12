public class AliveState : PlayerState
{
    public override void Rest()
    {
        
    }   
    
    public override void TakeDamage(int value)
    {
        _player.Stats.Health -= value;
        if(_player.Stats.Health <= 0) _player.SetState(new DeadState());
    }

    public override void PerformAction()
    {
        if(_player.Stats.Energy <= 0) _player.SetState(new TiredState());
    }
}