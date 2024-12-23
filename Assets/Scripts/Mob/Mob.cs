namespace Mob
{
    public abstract class Mob
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public MobBehaviour Behaviour { get; set; }
        
    }
}