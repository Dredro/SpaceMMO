using System;
using UnityEngine;

namespace GameSystem
{
   public class UIController : MonoBehaviour
   {
      [Header("UI elements")] 
      [SerializeField] private GameObject inventory;

      [SerializeField] private GameObject playerDeck;


      private bool _isActive;

      private void Update()
      {
         if (UnityEngine.Input.GetKeyDown(KeyCode.I)) OnInventoryShow(!_isActive);
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
      }
   }
}