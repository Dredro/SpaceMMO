using UnityEngine;

namespace NPC
{
    public abstract class NPC : MonoBehaviour
    {
        public string Name;

        public virtual void Talk()
        {
            Debug.Log($"I am {Name}. Nice to meet you!");
        }
    }
}