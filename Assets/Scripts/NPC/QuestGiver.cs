using Quest;

namespace NPC
{
    public class QuestGiver : NPC
    {
        
        public void AssignQuest()
        {
            var quest = new EliminateQuestFactory();
            quest.CreateQuest();
        }
    }
}