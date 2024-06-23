using UnityEngine;

public abstract class BaseCharacterController<TMovement, TAnimations, THealth, TActions> : MonoBehaviour
    where TMovement : BaseCharacterMovement<TAnimations>
    where TAnimations : BaseCharacterAnimations
    where THealth : BaseCharacterHealth
    where TActions : BaseCharacterActions<TMovement, TAnimations>
{
    public TMovement Movement { get; protected set; }
    public TAnimations Animations { get; protected set; }
    public THealth Health { get; protected set; }
    public TActions Actions { get; protected set; }

    protected Collider2D _collider;
    protected SpriteRenderer _characterRenderer;

    protected void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        Movement = GetComponent<TMovement>();
        Health = GetComponent<THealth>();
        Actions = GetComponent<TActions>();
        Animations = transform.GetChild(0).GetComponent<TAnimations>();

        _characterRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _collider = _characterRenderer.GetComponent<Collider2D>();

        Animations.Init();
        Movement.Init(Animations, transform.eulerAngles.y == 0 ? 1 : -1);
        Actions.Init(Movement, Animations);
        Health.Init(OnDie, _characterRenderer);
    }

    public void MoveLeft()
    {
        Movement.MoveHorizontally(-1);
    }

    public void MoveRight()
    {
        Movement.MoveHorizontally(1);
    }

    public void Stop()
    {
        Movement.Stop();
    }

    public void MeleeAttack()
    {
        Actions.MeleeAttack();
    }

    public virtual void OnDie()
    {
        Animations.Die();
    }
}
