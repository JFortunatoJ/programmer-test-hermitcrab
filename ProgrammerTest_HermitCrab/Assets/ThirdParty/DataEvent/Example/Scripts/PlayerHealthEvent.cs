namespace DataEvent.Example
{
    public struct PlayerHealthEvent
    {
        public float Health;

        public PlayerHealthEvent(float health)
        {
            Health = health;
        }
    }
}