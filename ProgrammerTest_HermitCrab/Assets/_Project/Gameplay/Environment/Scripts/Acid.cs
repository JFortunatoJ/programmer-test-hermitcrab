using UnityEngine;

public class Acid : BaseObstacle
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.attachedRigidbody.TryGetComponent(out IDamageable damageable)) return;

        ApplyDamage(damageable);
    }
}
