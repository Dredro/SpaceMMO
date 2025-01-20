namespace InventorySystem
{
    public class FireStoneDecorator : ItemDecorator
    {
        public FireStoneDecorator(ItemDefinition definition) : base(definition)
        {
        }

        public override void Decorate(IItem item)
        {
            if (item is Armor && this.wrappedItem is not ItemDecorator)
            {
                base.Decorate(item);
            }
            
        }
        
    }
}