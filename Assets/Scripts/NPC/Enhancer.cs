using System;
using System.Collections.Generic;
using Interactions;
using InventorySystem;
using UnityEngine;

namespace NPC
{
    public class Enhancer : NPC, IInteractor
    {
        public string BodyText = "Do you wanna enhance something?";
        private IDialog _dialog;

        private void Start()
        {
            _dialog = GetComponentInChildren<IDialog>();
            if(_dialog == null) Debug.LogError("Dialog not found");
        }

        public override void Talk()
        {
            Debug.Log(BodyText);
        }
    
        public bool DecorateArmorWithFireResistance(Inventory inventory,Armor armor)
        {
            if (armor != null && armor is not FireResistanceDecorator)
            {
                armor = new FireResistanceDecorator(armor); // TO CHANGE
                
                return true;
            }

            return false;
        }

        public void OnStartInteract(InteractionData data)
        {
            _dialog.Show(data);
        }

        public void OnEndInteract(InteractionData data)
        {
           _dialog.Hide();
        }
    }
}