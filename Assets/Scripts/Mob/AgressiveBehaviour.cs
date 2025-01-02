using UnityEngine;

namespace Mob
{
    public class AggressiveBehaviour : IMobBehaviour
    {
        public int Damage { get; set; }

        public void ExecuteBehaviour()
        {
            Debug.Log($"AggressiveBehaviour: Attacking with damage {Damage}.");
        }
    }
}