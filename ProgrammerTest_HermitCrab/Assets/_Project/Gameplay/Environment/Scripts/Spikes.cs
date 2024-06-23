using UnityEngine;

public class Spikes : MonoBehaviour, IWeapon
{
    [SerializeField, Range(1, 100)] protected int _damage;

    public int Damage => _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.rigidbody.TryGetComponent(out IDamageable damageable)) return;

        damageable.TakeDamage(Damage);
    }
}
