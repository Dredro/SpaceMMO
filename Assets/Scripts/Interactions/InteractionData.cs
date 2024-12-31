using UnityEngine;

namespace Interactions
{
    public struct InteractionData
    {
        public GameObject Source;
        public string Message;

        public InteractionData(GameObject source, string message)
        {
            Source = source;
            Message = message;
        }
    }
}