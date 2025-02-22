public abstract class PlayerState
{
    protected Player _player;
    public void SetPlayer(Player player)
    {
        _player = player;
    }
    
    public abstract void Rest();
    public abstract void TakeDamage();
    public abstract void PerformAction();
    
}