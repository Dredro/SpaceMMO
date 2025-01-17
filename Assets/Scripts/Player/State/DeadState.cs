using Mob;
using UnityEngine;

public class DeadState : PlayerState
{
    public override void Rest()
    {
        Debug.Log("Player die");
    }

    public override void TakeDamage(int value)
    { 
        Object.Destroy(_player.gameObject);
        Debug.Log("Player die");
    }

    public override void PerformAction(MobController controller)
    {
        Debug.Log("Player die");
    }
}