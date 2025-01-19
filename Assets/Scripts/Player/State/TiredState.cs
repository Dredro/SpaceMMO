using System.Collections;
using UnityEngine;

public class TiredState : PlayerState
{
    public override void StateEnter()
    {
        // Start the coroutine to manage energy recovery
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

    public override void TakeDamage(int value)
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