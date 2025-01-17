using Mob;
using UnityEngine;

public class TiredState : PlayerState
{
    public override void Rest()
    {
        if(_player.Stats.Energy <=100)
            _player.Stats.Energy++;
        else
            _player.SetState(new AliveState());
    }

    public override void TakeDamage(int value)
    {
        _player.Stats.Health -= value;
        if(_player.Stats.Health <= 0) _player.SetState(new DeadState());
    }

    public override void PerformAction(MobController controller)
    {
        if (_player.Stats.Energy <= 20)
        {
            Debug.Log("Low energy!");
            _player.actionsInput.CanAttack = false;
        }
        else
        {
            _player.Stats.Energy -= _player.actionEnergyCost;
            controller?.TakeDamage(_player.Stats.Damage);
            _player.actionsInput.CanAttack = true;
        }
      
    }
}