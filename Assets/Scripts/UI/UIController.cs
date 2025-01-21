using System;
using LocomotionSystem.Input;
using UnityEngine;

namespace GameSystem
{
   public class UIController : MonoBehaviour
   {
      [Header("UI elements")] 
      [SerializeField] private GameObject inventory;

      [SerializeField] private GameObject playerDeck;
      [SerializeField] private PlayerLocomotionInput _playerLocomotionInput;
      [SerializeField] private PlayerActionsInput _actionsInput;
      [SerializeField] private Animator _animator;
      [SerializeField] private GameObject _gameObject;
      private bool _isActive;

      private void Update()
      {
         if (UnityEngine.Input.GetKeyDown(KeyCode.E)) OnInventoryShow(!_isActive);
         if(UnityEngine.Input.GetKeyDown(KeyCode.Delete)) _gameObject.SetActive(!_gameObject.activeSelf);
      }

      private void Awake()
      {
         if (!inventory) Debug.LogError("Inventory is null (UIController)");
         if (!playerDeck) Debug.LogError("PlayerDeck is null (UIController)");

      }

      public void OnInventoryShow(bool active)
      {
         _isActive = active;
         inventory.SetActive(active);
         _playerLocomotionInput.enabled = !active;
         _actionsInput.enabled = !active;
         Invoke(nameof(ActiveAnim),.9f);
      }

      private void ActiveAnim()
      {
         _animator.enabled = !_isActive;
      }
   }
}