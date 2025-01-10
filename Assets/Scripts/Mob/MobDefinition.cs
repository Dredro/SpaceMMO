using UnityEngine;
using UnityEngine.Serialization;

namespace Mob
{
    public enum MobType
    {
        Friendly,Neutral,Aggressive
    }
    
    [CreateAssetMenu(fileName = "Mob Definition")]
    public class MobDefinition : ScriptableObject
    {
        [Header("Basic mob fields")] 
        public string mobName;
        public int health;
        public float speed;
        public int attackDamage;
        [Header("Other")] 
        public MobType type;
    }
}