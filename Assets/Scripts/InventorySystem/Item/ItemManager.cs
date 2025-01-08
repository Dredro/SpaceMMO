using System;
using UnityEngine;

namespace InventorySystem.Item
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public bool DecorateItem(ItemController itemToDecorate, ItemController itemDecorator)
        {
            if(itemToDecorate == itemDecorator) return false;
            if (itemDecorator.Item is ItemDecorator decorator)
            {
                decorator.Decorate(itemToDecorate.Item);
                Destroy(itemToDecorate.gameObject);
                return true;
            }

            return false;
        }
    }
}