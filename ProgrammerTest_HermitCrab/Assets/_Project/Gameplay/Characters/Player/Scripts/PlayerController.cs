using UnityEngine;

public class PlayerController : BaseCharacterController<PlayerMovement, PlayerAnimations, PlayerHealth, PlayerActions>
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Spawn(Vector3 position)
    {
        transform.position = position;
        Health.Heal(Health.MaxHealth);
        Animations.Respawn();
    }

    private void Update()
    {
#if UNITY_EDITOR
        HandleKeyboardInput();
#endif
    }

    private void HandleKeyboardInput()
    {
        if (Health.IsDead ||
            GameManager.Instance.IsPaused ||
            GameManager.Instance.GameOver) return;

        HandleMovementInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else
        {
            Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void HandleAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            MeleeAttack();
        }
    }

    public void Jump()
    {
        Movement.Jump();
    }

    public void Shoot()
    {
        Actions.Shoot();
    }

    public override void OnDie()
    {
        base.OnDie();
        DataEvent.DataEvent.Notify(new OnPlayerDeathEvent());
    }
}
