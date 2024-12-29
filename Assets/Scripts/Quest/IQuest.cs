namespace Quest
{
    public interface IQuest
    {
        string Name { get; set; }
        string Description { get; set; }
        bool IsCompleted { get; set; }

        void Complete();
        void Cancel();
    }
}