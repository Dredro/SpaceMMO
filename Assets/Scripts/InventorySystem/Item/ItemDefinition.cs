using UnityEngine;

namespace InventorySystem
{
    public enum ItemType
    {
        Weapon,Armor,Tool,FireStoneDecorator
    }
    [CreateAssetMenu(fileName = "Item")]
    public class ItemDefinition : ScriptableObject
    {
        [Header("Basic item fields")]
        public int id;
        public string itemName;
        public int weight;
        public int value;
        [Header("Other fields")]
        public ItemType type;
        public GameObject gameObjectPrefab;
        [Header("UI item fields")] 
        public Sprite icon;
        public bool stackable;


    }
}