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

        Animations.Init();
        Movement.Init(Animations, transform.eulerAngles.y == 0 ? 1 : -1);
        Actions.Init(Movement, Animations);
        Health.Init();
    }
}
