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

        public Armor DecorateArmorWithFireResistance(Armor armor)
        {
            if (armor != null && armor is not FireResistanceDecorator)
            {
                var fireResistantArmor = ScriptableObject.CreateInstance<FireResistanceDecorator>();

                fireResistantArmor.Init(armor);
                fireResistantArmor.ApplyFireResistance();

                Debug.Log($"Added fire resistance to {armor.name}. New item: {fireResistantArmor.name}");
                return fireResistantArmor;
            }

            return null;
        }
    }
}