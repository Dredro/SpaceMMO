namespace Quest
{
    public class ExploreQuestFactory : IQuestFactory
    {
        public IQuest CreateQuest()
        {
            return new ExploreQuest();
        }
    }
}