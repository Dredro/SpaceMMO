using System;
using System.Collections;
using LocomotionSystem.Input;
using MobSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        public string id;
        public Stats Stats;
        private PlayerState _currentState;
        private PlayerActionsInput _playerActionsInput;
        private bool _canRun = true;
        private bool _isAttacking = false;

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
            if (_playerActionsInput.AttackPressed) Attack();
            StateUpdate();
        }


        private void Attack()
        {
            if (!_isAttacking)
            {
                StartCoroutine(AttackWithDelay());
            }
        }

        private IEnumerator AttackWithDelay()
        {
            _isAttacking = true;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit,
                    2f))
            {
                if (hit.transform.TryGetComponent(out MobController mobController))
                {
                    mobController.TakeDamage(Stats.Damage);
                }
            }

            yield return new WaitForSeconds(1f);
            _isAttacking = false;
        }

        public void SetState(PlayerState state)
        {
            _currentState = state;
            _currentState.SetPlayer(this);
            StateEnter();
            Debug.Log("Current state: " + _currentState.GetType());
        }

        private void StateEnter()
        {
            _currentState.StateEnter();
        }

        public void TakeDamage(float value)
        {
            _currentState.TakeDamage(value);
        }

        private void StateUpdate()
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
}