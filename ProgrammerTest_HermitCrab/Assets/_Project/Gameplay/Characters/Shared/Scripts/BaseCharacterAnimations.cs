using System;
using UnityEngine;

public abstract class BaseCharacterAnimations : MonoBehaviour
{
    protected Animator _animator;
    protected Action _onHitPoint;

    protected static readonly int _isMovingKey = Animator.StringToHash("IsMoving");
    protected static readonly int _meleeKey = Animator.StringToHash("Melee");
    protected static readonly int _dieKey = Animator.StringToHash("Die");
    protected static readonly int _respawnKey = Animator.StringToHash("Respawn");

    public bool IsMoving { set => _animator.SetBool(_isMovingKey, value); }

    public virtual void Init()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void Respawn()
    {
        _animator.SetTrigger(_respawnKey);
        IsMoving = false;
    }

    public void MeleeAttack(Action onHitPoint)
    {
        _onHitPoint = onHitPoint;
        _animator.SetTrigger(_meleeKey);
    }

    public void Die()
    {
        _animator.SetTrigger(_dieKey);
    }

    private void EnableHitPoint()
    {
        _onHitPoint?.Invoke();
    }
}
