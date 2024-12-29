using System;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public string id;
    public Stats stats;
    public Inventory inventory;
    private PlayerState currentState;
   

    private void Start()
    {  
        inventory = InventoryController.Instance.GetInventory();
        stats = StatsController.Instance.GetStats("0");
        StatsController.Instance.AttachBasicObservers(stats,FindFirstObjectByType<UIHealth>(),FindFirstObjectByType<UIEnergy>());
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
