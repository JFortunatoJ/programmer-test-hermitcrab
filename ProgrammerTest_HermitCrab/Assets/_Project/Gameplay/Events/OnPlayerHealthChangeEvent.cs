public struct OnPlayerHealthChangeEvent
{
    public int maxHealth;
    public int health;

    public OnPlayerHealthChangeEvent(int maxHealth, int health)
    {
        this.maxHealth = maxHealth;
        this.health = health;
    }
}
