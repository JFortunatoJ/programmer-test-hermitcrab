using UnityEngine;

public abstract class BaseCharacterActions<TMovement, TAnimations> : MonoBehaviour
    where TMovement : BaseCharacterMovement<TAnimations>
    where TAnimations : BaseCharacterAnimations
{
    protected TMovement _movement;
    protected TAnimations _animations;

    public virtual void Init(TMovement movement, TAnimations animations)
    {
        _movement = movement;
        _animations = animations;
    }

    public abstract void MeleeAttack();
}
