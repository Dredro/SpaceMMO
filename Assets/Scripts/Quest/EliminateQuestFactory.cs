namespace Quest
{
    public class EliminateQuestFactory : IQuestFactory
    {
        public IQuest CreateQuest(string name, string description)
        {
            return new EliminateQuest(name, description);
        }
    }
}