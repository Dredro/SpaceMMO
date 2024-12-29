using System;
using UnityEngine;

namespace NPC
{
    public class Enhancer : NPC
    {
        public override void Talk()
        {
            Debug.Log($"Welcome!");
        }

        public void DecorateArmorWithFireResistance(Armor armor)
        {
            if (armor != null)
            {
                var fireResistantArmor = ScriptableObject.CreateInstance<FireResistanceDecorator>();

                fireResistantArmor.Init(armor);
                fireResistantArmor.ApplyFireResistance();

                armor = fireResistantArmor;

                Debug.Log($"Added fire resistance to {armor.name}. New item: {fireResistantArmor.name}");
            }
        }
    }
}