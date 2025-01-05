using System;
using InventorySystem;
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
        try
        {
            inventory = InventoryController.Instance.GetInventory("player:0");
            if (inventory == null)
            {
                throw new Exception("Inventory loading failed!");
            }
            InventoryController.Instance.GetStarterPack(inventory.id);
            stats = StatsController.Instance.GetStats("0");
            if (stats == null)
            {
                throw new Exception("Stats loading failed!");
            }

            var healthUI = FindFirstObjectByType<UIHealth>();
            var energyUI = FindFirstObjectByType<UIEnergy>();
        
            if (healthUI == null || energyUI == null)
            {
                throw new Exception("UI components not found!");
            }

            StatsController.Instance.AttachBasicObservers(stats, healthUI, energyUI);
            SetState(new AliveState());
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred in Start: {ex.Message}");
        }
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
