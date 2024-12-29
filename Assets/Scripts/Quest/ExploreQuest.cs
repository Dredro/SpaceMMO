using UnityEngine;

namespace Quest
{
    public class ExploreQuest : IQuest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ExploreQuest(string name, string description)
        {
            Name = name;
            Description = description;
            IsCompleted = false;
        }

        public void Complete()
        {
            IsCompleted = true;
            Debug.Log($"{Name} completed successfully.");
        }

        public void Cancel()
        {
            IsCompleted = false;
            Debug.Log($"{Name} has been canceled.");
        }
    }

}