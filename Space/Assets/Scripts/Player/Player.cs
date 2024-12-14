using System;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public string id;
    public Stats stats;
    private PlayerState currentState;
    public Inventory inventory;

    private void Awake()
    {
        id = PlayerDbController.GetInstance().GetPlayer().ToString();
        inventory = InventoryController.GetInstance().GetInventory(id);
        stats = StatsController.GetInstance().GetStats(id);
        SetState(new AliveState());
    }

    public void SetState(PlayerState state)
    {
        currentState = state;
        currentState.SetPlayer(this);
        Debug.Log("Current state: "+ currentState.GetType());
    }

    public void Rest()
    {
        currentState.Rest();
    }

    public void TakeDamage()
    {
        currentState.TakeDamage();
    }

    public void PerformAction()
    {
        currentState.PerformAction();
    }
}
