namespace PlayerSystem
{
    public abstract class PlayerState
    {
        protected Player _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public abstract void StateEnter();
        public abstract void TakeDamage(float value);
        public abstract void StateUpdate();

    }
}