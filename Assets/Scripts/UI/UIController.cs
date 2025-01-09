using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
   [Header("UI elements")] 
   [SerializeField] private GameObject inventory;
   [SerializeField] private GameObject playerDeck;


   private bool isActive;

   private void Update()
   {
      if(UnityEngine.Input.GetKeyDown(KeyCode.I)) OnInventoryShow(!isActive);
   }

   private void Awake()
   {
      if(!inventory) Debug.LogError("Inventory is null (UIController)");
      if(!playerDeck) Debug.LogError("PlayerDeck is null (UIController)");
    
   }
   
   public void OnInventoryShow(bool active)
   {
      isActive = active;
      inventory.SetActive(active);
   }
   
   
}
