using System;
using LocomotionSystem.Input;
using Mob;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public string Id;
    public Stats Stats;
    private PlayerState _currentState;
    private PlayerActionsInput _playerActionsInput;
    private bool _canRun = true;
    private void Start()
    {
        try
        {
            Stats = StatsController.Instance.GetStats("0");
            if (Stats == null)
            {
                throw new Exception("Stats loading failed!");
            }

            var healthUI = FindFirstObjectByType<UIHealth>();
            var energyUI = FindFirstObjectByType<UIEnergy>();
            if (healthUI == null || energyUI == null)
            {
                throw new Exception("UI components not found!");
            }

            StatsController.Instance.AttachBasicObservers(Stats, healthUI, energyUI);
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
        StateUpdate();
    }

    private void Attack()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 2f))
        {
            if (hit.transform.TryGetComponent(out MobController mobController))
            {
                mobController.TakeDamage(Stats.Damage);
            }
        }
    }
    public void SetState(PlayerState state)
    {
        _currentState = state;
        _currentState.SetPlayer(this);
        StateEnter();
        Debug.Log("Current state: "+ _currentState.GetType());
    }

    public void StateEnter()
    {
        _currentState.StateEnter();
    }

    public void TakeDamage(int value)
    {
        _currentState.TakeDamage(value);
    }

    public void StateUpdate()
    {
        _currentState.StateUpdate();
    }

    public bool CanRun()
    {
        return _canRun;
    }

    public void SetCanRun(bool canRun)
    {
        _canRun = canRun;
    }
}
