using UnityEngine;

public class PlayerController : BaseCharacterController<PlayerMovement, PlayerAnimations, PlayerHealth, PlayerActions>
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
#if UNITY_EDITOR
        HandleKeyboardInput();
#endif
    }

    private void HandleKeyboardInput()
    {
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

    public void Jump()
    {
        Movement.Jump();
    }

    public void Shoot()
    {
        Actions.Shoot();
    }

    public void MeleeAttack()
    {
        Actions.MeleeAttack();
    }
}
