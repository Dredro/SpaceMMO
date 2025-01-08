using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
   [Header("UI elements")] 
   [SerializeField] private GameObject inventory;
   [SerializeField] private GameObject playerDeck;
   [SerializeField] private GameObject armor;
   [SerializeField] private GameObject enhancer;

   private bool isActive;
   private void Awake()
   {
      if(!inventory) Debug.LogError("Inventory is null (UIController)");
      if(!playerDeck) Debug.LogError("PlayerDeck is null (UIController)");
      if(!armor) Debug.LogError("Armor is null (UIController)");
      if(!enhancer) Debug.LogError("Enhancer is null (UIController)");
   }

   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.E)) OnInventoryShow(!isActive);
   }

   public void OnInventoryShow(bool active)
   {
      isActive = active;
      inventory.SetActive(active);
      armor.SetActive(active);
      enhancer.SetActive(active);
   }
  
}
