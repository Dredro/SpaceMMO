using Enhance;
using UnityEngine;

public class DeadState : PlayerState
{
    public override void StateEnter()
    {
        if(_player.gameObject != null)
            GameManager.GameReset();
        Debug.Log("Player die");
    }

    public override void TakeDamage(float value)
    { 
        Debug.Log("Player die");
    }
    
    public override void StateUpdate()
    {
        Debug.Log("Player die");
    }
}