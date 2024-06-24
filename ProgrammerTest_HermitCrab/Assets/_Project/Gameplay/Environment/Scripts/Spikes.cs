public class Spikes : BaseObstacle
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!collision.rigidbody.TryGetComponent(out IDamageable damageable)) return;

        ApplyDamage(damageable);
    }
}
