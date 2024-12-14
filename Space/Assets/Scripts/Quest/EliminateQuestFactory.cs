namespace Quest
{
    public class EliminateQuestFactory : IQuestFactory
    {
        public IQuest CreateQuest()
        {
            return new EliminateQuest();
        }
    }
}