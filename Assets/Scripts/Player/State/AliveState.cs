public class AliveState : PlayerState
{
    public override void Rest()
    {
        
    }   
    
    public override void TakeDamage()
    {
        if(_player.stats.Health <= 0) _player.SetState(new DeadState());
    }

    public override void PerformAction()
    {
        if(_player.stats.Energy <= 0) _player.SetState(new TiredState());
    }
}