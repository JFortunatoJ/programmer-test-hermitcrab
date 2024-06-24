using UnityEngine;

public class PlayerMovement : BaseCharacterMovement<PlayerAnimations>
{
    [SerializeField] private PlayerControls _controls;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallMultiplier;
    [SerializeField] private float _jumpVelocityFalloff;
    [SerializeField] private float _grounderOffset;
    [SerializeField] private float _grounderRadius;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private bool _isGrounded;

    private readonly Collider2D[] _ground = new Collider2D[1];

    public void Jump()
    {
        if (!IsGrounded()) return;

        _moveDirection.y = _jumpForce;
        _rigidbody.velocity = new Vector2(0, _jumpForce);

        _moveDirection.y = 0;
        _animations.Jump();
    }

    private void Update()
    {
        if (IsGrounded())
        {
            _animations.Land();
            return;
        }

        if (_rigidbody.velocity.y < _jumpVelocityFalloff || _rigidbody.velocity.y > 0 && !_controls.IsJumpInputPressed)
        {
            _rigidbody.velocity += _fallMultiplier * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
            _animations.Fall();
        }
    }

    private bool IsGrounded()
    {
        _isGrounded = Physics2D.OverlapCircleNonAlloc(transform.position + new Vector3(0, _grounderOffset), _grounderRadius, _ground, _groundMask) > 0;
        return _isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, _grounderOffset), _grounderRadius);
    }
}
