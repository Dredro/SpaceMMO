using Interactions;

public interface IDialog : IInteractor
{
    public string Title { get; set; }
    public string Body { get; set; }

    public void Show();
    public void Hide();
}
