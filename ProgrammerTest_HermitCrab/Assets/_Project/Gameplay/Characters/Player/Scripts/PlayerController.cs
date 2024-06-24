using UnityEngine;

public class PlayerController : BaseCharacterController<PlayerMovement, PlayerAnimations, PlayerHealth, PlayerActions>
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerControls _controls;

    protected override void Init()
    {
        base.Init();

        _controls.OnMeleeInputPressed += MeleeAttack;
        _controls.OnShootInputPressed += Shoot;
    }

    private void OnDestroy()
    {
        _controls.OnMeleeInputPressed -= MeleeAttack;
        _controls.OnShootInputPressed -= Shoot;
    }

    public void Spawn(Vector3 position)
    {
        transform.position = position;
        Health.Heal(Health.MaxHealth);
        Animations.Respawn();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!CanAct()) return;

        if (_controls.IsLeftInputPressed)
        {
            MoveLeft();
        }
        else if (_controls.IsRightInputPressed)
        {
            MoveRight();
        }
        else
        {
            Stop();
        }

        if (_controls.IsJumpInputPressed)
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!CanAct()) return;

        Movement.Jump();
    }

    public void Shoot()
    {
        if (!CanAct()) return;

        Actions.Shoot();
    }

    private bool CanAct()
    {
        return !Health.IsDead &&
            !GameManager.Instance.IsPaused &&
            !GameManager.Instance.GameOver;
    }

    public override void OnDie()
    {
        base.OnDie();
        DataEvent.DataEvent.Notify(new OnPlayerDeathEvent());
    }
}
