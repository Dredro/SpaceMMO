using System;
using LocomotionSystem.Input;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public string id;
    public Stats stats;
    private PlayerState currentState;
    private PlayerActionsInput _playerActionsInput;

    private void Start()
    {
        try
        {
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
            _playerActionsInput = GetComponent<PlayerActionsInput>();
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred in Start: {ex.Message}");
        }
    }

    private void Update()
    {
        if(_playerActionsInput.AttackPressed) Attack();
    }

    private void Attack()
    {
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 1f))
        {
            if (hit.transform.TryGetComponent(out Mob.Mob mob))
            {
                mob.TakeDamage(stats.Damage);
            }
        }*/
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

    public void TakeDamage(int value)
    {
        currentState.TakeDamage(value);
    }

    public void PerformAction()
    {
        currentState.PerformAction();
    }
}
