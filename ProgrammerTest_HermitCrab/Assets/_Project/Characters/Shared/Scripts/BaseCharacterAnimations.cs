using UnityEngine;

public abstract class BaseCharacterAnimations : MonoBehaviour
{
    protected Animator _animator;

    protected static readonly int _isMovingKey = Animator.StringToHash("IsMoving");
    protected static readonly int _meleeKey = Animator.StringToHash("Melee");

    public bool IsMoving { set => _animator.SetBool(_isMovingKey, value); }

    public virtual void Init()
    {
        _animator = GetComponent<Animator>();
    }

    public void Melee()
    {
        _animator.SetTrigger(_meleeKey);
    }
}
