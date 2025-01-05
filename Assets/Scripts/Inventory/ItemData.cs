using UnityEngine;

namespace InventorySystem
{
    public class ItemData : ScriptableObject
    {
        [SerializeField] public string id;
        [SerializeField] public string name;
        [SerializeField] public Sprite icon;
        [SerializeField] public float weight;
    }
}