using UnityEngine;

public class PlayerAnimations : BaseCharacterAnimations
{
    private static readonly int _jumpKey = Animator.StringToHash("IsJumping");
    private static readonly int _shootTrigger = Animator.StringToHash("Shoot");
    private static readonly int _fallKey = Animator.StringToHash("IsFalling");

    public void Shoot()
    {
        _animator.SetTrigger(_shootTrigger);
    }

    public void Jump()
    {
        _animator.SetBool(_jumpKey, true);
    }

    public void Fall()
    {
        _animator.SetBool(_jumpKey, false);
        _animator.SetBool(_fallKey, true);
    }

    public void Land()
    {
        _animator.SetBool(_fallKey, false);
    }
}
