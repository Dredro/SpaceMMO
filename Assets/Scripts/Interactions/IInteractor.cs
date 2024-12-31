namespace Interactions
{
    public interface IInteractor
    {
        public void OnStartInteract(InteractionData data);
        public void OnEndInteract(InteractionData data);
    }
}