namespace NPC
{
    public abstract class NPC
    {
        public string Name { get; set; }
        public virtual void Talk(){}
    }
}