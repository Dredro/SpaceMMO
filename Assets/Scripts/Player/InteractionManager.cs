using System;
using NPC;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPC.NPC npc))
        {
            npc.Talk();
            if (npc is Enhancer enhancer)
            {
                if (player.inventory.items[0] is Armor armor)
                {
                   var fireResistance = enhancer.DecorateArmorWithFireResistance(armor);
                   if (fireResistance != null)
                   {
                       player.inventory.items.Remove(armor);
                       player.inventory.items.Add(fireResistance); // TO FIX
                   }
                      
                }
                   
            }
        }
    }
}
