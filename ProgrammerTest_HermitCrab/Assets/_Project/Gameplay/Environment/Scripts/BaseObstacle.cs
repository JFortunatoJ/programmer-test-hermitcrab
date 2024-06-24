using UnityEngine;

public class BaseObstacle : MonoBehaviour, IWeapon
{
    [SerializeField, Range(1, 100)] protected int _damage;

    public int Damage => _damage;

    protected virtual void ApplyDamage(IDamageable damageable)
    {
        damageable.TakeDamage(Damage);
    }
}
