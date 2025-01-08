using UnityEngine;

namespace NPC
{
    public class ShopKeeper : NPC
    {
      
        public override void Talk()
        {
            Debug.Log($"Welcome to my shop! Take a look at my wares.");
        }
        
       
    }
}