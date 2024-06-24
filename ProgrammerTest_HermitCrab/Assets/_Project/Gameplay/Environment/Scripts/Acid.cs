using UnityEngine;

public class Acid : MonoBehaviour, IWeapon
{
    [SerializeField, Range(1, 100)] protected int _damage;

    public int Damage => _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.attachedRigidbody.TryGetComponent(out IDamageable damageable)) return;

        ApplyDamage(damageable);
    }

    protected void ApplyDamage(IDamageable damageable)
    {
        damageable.TakeDamage(Damage);
    }
}
