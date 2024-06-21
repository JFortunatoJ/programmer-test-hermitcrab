using UnityEngine;

public abstract class BaseCharacterMovement<TAnimations> : MonoBehaviour where TAnimations : BaseCharacterAnimations
{
    [SerializeField] protected float _movementSpeed;

    protected Rigidbody2D _rigidbody;
    protected Vector2 _moveDirection;

    protected TAnimations _animations;

    public int HorizontalDirection { get; protected set; }

    public virtual void Init(TAnimations animations, int initialDirection)
    {
        _animations = animations;
        HorizontalDirection = initialDirection;

        _rigidbody = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.zero;
    }

    public void MoveHorizontally(int directionX)
    {
        HorizontalDirection = directionX;
        transform.rotation = directionX > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        _moveDirection.x = directionX * _movementSpeed * Time.deltaTime;
        _rigidbody.position += _moveDirection;

        _animations.IsMoving = true;
    }

    public void Stop()
    {
        _animations.IsMoving = false;
    }
}
