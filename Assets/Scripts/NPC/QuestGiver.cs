using Quest;
using UnityEngine;

namespace NPC
{
    public class QuestGiver : NPC
    {
        public IQuestFactory QuestFactory;
        private IQuest currentQuest;

        public override void Talk()
        {
            if (currentQuest != null)
            {
                Debug.Log($"Hello! I have a quest for you: {currentQuest.Name} - {currentQuest.Description}");
            }
            else
            {
                Debug.Log($"Hello! I don't have any quests for you at the moment.");
            }
        }

        public void AssignNewQuest(string questName, string questDescription)
        {
            if (QuestFactory != null)
            {
                currentQuest = QuestFactory.CreateQuest(questName, questDescription);
                Debug.Log($"Assigned a new quest: {currentQuest.Name}");
            }
            else
            {
                Debug.Log("Quest factory not assigned!");
            }
        }

        public void CompleteQuest()
        {
            if (currentQuest != null)
            {
                currentQuest.Complete();
                currentQuest = null;
            }
            else
            {
                Debug.Log("No active quest to complete.");
            }
        }
    }

}