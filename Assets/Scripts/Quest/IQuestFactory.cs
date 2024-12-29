namespace Quest
{
    public interface IQuestFactory
    {
        IQuest CreateQuest(string name, string description);
    }

}