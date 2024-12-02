public class Player
{
    public UUID id;
    public Stats stats;
    public IPlayerState currentState;
    public Inventory inventory;

    public void SetState(IPlayerState state)
    {
        currentState = state;
    }
}
