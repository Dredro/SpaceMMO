using UnityEngine;

public class DeadState : PlayerState
{
    public override void StateEnter()
    {
        if(_player.gameObject != null)
            Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }

    public override void TakeDamage(int value)
    { 
        if(_player.gameObject != null)
            Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }

    public override void StateUpdate()
    {
        if(_player.gameObject != null)
            Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }
}