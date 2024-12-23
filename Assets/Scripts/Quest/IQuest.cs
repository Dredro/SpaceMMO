namespace Quest
{
    public interface IQuest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Finish();
        public void Cancel();

    }
}