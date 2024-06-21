using UnityEngine;

public abstract class BaseCharacterActions<TMovement, TAnimations> : MonoBehaviour, IWeapon
    where TMovement : BaseCharacterMovement<TAnimations>
    where TAnimations : BaseCharacterAnimations
{
    [SerializeField] protected int _meleeDamage;

    [SerializeField] protected Transform _hitPoint;
    [SerializeField] protected float _hitPointRadius = .5f;
    [SerializeField] protected LayerMask _targetsMask;

    protected TMovement _movement;
    protected TAnimations _animations;

    public int Damage => _meleeDamage;

    public virtual void Init(TMovement movement, TAnimations animations)
    {
        _movement = movement;
        _animations = animations;
    }

    public virtual void MeleeAttack()
    {
        _animations.MeleeAttack(TryHit);
    }

    protected virtual void TryHit()
    {
        Collider2D[] hitTargets = new Collider2D[2];
        int targetsAmount = Physics2D.OverlapCircleNonAlloc(_hitPoint.position, _hitPointRadius, hitTargets, _targetsMask);
        if (targetsAmount == 0) return;

        for (int i = 0; i < targetsAmount; i++)
        {
            if (!hitTargets[i].attachedRigidbody.TryGetComponent(out IDamageable damageable)) continue;

            damageable.TakeDamage(Damage);
        }
    }
}
