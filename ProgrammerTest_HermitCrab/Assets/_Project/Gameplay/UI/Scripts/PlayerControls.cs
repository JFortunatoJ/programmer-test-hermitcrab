using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PlayerControlButton _jumpButton;
    [SerializeField] private PlayerControlButton _meleeButton;
    [SerializeField] private PlayerControlButton _shootButton;
    [SerializeField] private PlayerControlButton _moveLeftButton;
    [SerializeField] private PlayerControlButton _moveRightButton;

    private bool _leftInput;
    private bool _rightInput;
    private bool _jumpInput;

    public bool IsLeftInputPressed => _leftInput || Input.GetKey(KeyCode.A);
    public bool IsRightInputPressed => _rightInput || Input.GetKey(KeyCode.D);
    public bool IsJumpInputPressed => _jumpInput || Input.GetKey(KeyCode.Space);

    public Action OnMeleeInputPressed;
    public Action OnShootInputPressed;

    private void Start()
    {
        _jumpButton.OnPressed += OnJumpInputChanged;
        _moveLeftButton.OnPressed += OnLeftInputChanged;
        _moveRightButton.OnPressed += OnRightInputChanged;
        _meleeButton.OnPressed += OnMeleeInputChanged;
        _shootButton.OnPressed += OnShootInputChanged;
    }

    private void OnDestroy()
    {
        _jumpButton.OnPressed -= OnJumpInputChanged;
        _moveLeftButton.OnPressed -= OnLeftInputChanged;
        _moveRightButton.OnPressed -= OnRightInputChanged;
        _meleeButton.OnPressed -= OnMeleeInputChanged;
        _shootButton.OnPressed -= OnShootInputChanged;
    }

    private void OnJumpInputChanged(bool pressDown)
    {
        _jumpInput = pressDown;
    }

    private void OnLeftInputChanged(bool pressDown)
    {
        _leftInput = pressDown;
    }

    private void OnRightInputChanged(bool pressDown)
    {
        _rightInput = pressDown;
    }

    private void OnMeleeInputChanged(bool pressDown)
    {
        if (pressDown)
        {
            OnMeleeInputPressed?.Invoke();
        }
    }

    public void OnShootInputChanged(bool pressDown)
    {
        if (pressDown)
        {
            OnShootInputPressed?.Invoke();
        }
    }
}
