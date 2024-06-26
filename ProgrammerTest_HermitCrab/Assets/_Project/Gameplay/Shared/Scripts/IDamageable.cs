public interface IDamageable
{
    int MaxHealth { get; }
    int Health { get; }
    bool IsDead { get; }

    void TakeDamage(int damage);
    void Heal(int amount);
    void Destroy();
}
