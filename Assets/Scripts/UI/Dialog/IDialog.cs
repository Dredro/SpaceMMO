using Interactions;

public interface IDialog
{
    public string Title { get; set; }
    public string Body { get; set; }

    public void Confirm();
    public void Cancel();
    public void Show(InteractionData data);
    public void Hide();
}
