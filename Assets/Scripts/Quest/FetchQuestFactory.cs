namespace Quest
{
    public class FetchQuestFactory : IQuestFactory
    {
        public IQuest CreateQuest(string name, string description)
        {
            return new FetchQuest(name, description);
        }
    }
}