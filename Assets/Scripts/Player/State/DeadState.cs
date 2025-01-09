using UnityEngine;

public class DeadState : PlayerState
{
    public override void Rest()
    {
        Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }

    public override void TakeDamage(int value)
    { 
        Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }

    public override void PerformAction()
    {
        Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }
}