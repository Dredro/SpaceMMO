using UnityEngine;

namespace Interactions
{
    public struct InteractionData
    {
        public object Source;
        public string Message;

        public InteractionData(object source, string message)
        {
            Source = source;
            Message = message;
        }
    }
}