public interface IDamageable
{
    int MaxHealth { get; }
    int Health { get; }

    void TakeDamage(int damage);
    void Destroy();
}
