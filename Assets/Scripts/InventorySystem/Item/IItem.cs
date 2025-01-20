using UnityEngine;

namespace InventorySystem
{
   public interface IItem 
   {
      public int Id { get; set; }
      public string ItemName { get; set; }
      public int Weight { get; set; }
      public int Value { get; set; }
      public GameObject GameObjectPrefab { get; set; }

      public Sprite Icon { get; set; }
      public bool Stackable { get; set; }

      public void Use();
   }
}
