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
    public int actionEnergyCost = 10;
    private float restDelay = 1f;
    public PlayerActionsInput actionsInput;
    private float nextAttackTime = 0f;
    private float attackDelay = 1f;
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
            actionsInput = GetComponent<PlayerActionsInput>();
            InvokeRepeating(nameof(Rest),0f,restDelay);
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
        if (Time.time >= nextAttackTime)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit,
                    2f))
            {
                if (hit.transform.TryGetComponent(out MobController mobController))
                {
                    PerformAction(mobController);
                }
            }
            else
            {
                PerformAction(null);
            }
            nextAttackTime = Time.time + attackDelay;
        }
    }
    public void SetState(PlayerState state)
    {
        _currentState = state;
        _currentState.SetPlayer(this);
        Debug.Log("Current state: "+ _currentState.GetType());
    }

    public void Rest()
    {
        _currentState.Rest();
    }

    public void TakeDamage(int value)
    {
        _currentState.TakeDamage(value);
    }

    public void PerformAction(MobController controller)
    {
        _currentState.PerformAction(controller);
    }
}
