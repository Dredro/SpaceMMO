namespace Quest
{
    public class FetchQuestFactory : IQuestFactory
    {
        public IQuest CreateQuest()
        {
            return new FetchQuest();
        }
    }
}