using Mob;

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

    public override void PerformAction(MobController controller)
    {
        if (_player.Stats.Energy < 100)
        {
            _player.SetState(new TiredState());
            return;
        }
        _player.Stats.Energy -= _player.actionEnergyCost;
        controller?.TakeDamage(_player.Stats.Damage);
        _player.actionsInput.CanAttack = true;
    }
}