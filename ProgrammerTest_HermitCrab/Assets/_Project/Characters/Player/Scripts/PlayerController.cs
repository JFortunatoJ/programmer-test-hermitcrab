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
        HandleShootInput();
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

    private void HandleShootInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Actions.Shoot();
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
}
