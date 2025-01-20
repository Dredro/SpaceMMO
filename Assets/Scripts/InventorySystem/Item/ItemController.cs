using UnityEngine;

namespace InventorySystem
{
    public class ItemController : MonoBehaviour
    {
        public IItem Item { get; set; }
        [SerializeField] private ItemDefinition definition;
        private void Awake() => Item = ItemFactory.Create(definition);
        
    }
}