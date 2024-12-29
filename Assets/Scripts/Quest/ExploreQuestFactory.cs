namespace Quest
{
    public class ExploreQuestFactory : IQuestFactory
    {
        public IQuest CreateQuest(string name, string description)
        {
            return new ExploreQuest(name, description);
        }
    }

}