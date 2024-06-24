using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : BaseScreenView
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    public Action OnContinueClick;
    public Action OnExitClick;

    private void Start()
    {
        _continueButton.onClick.AddListener(() => OnContinueClick?.Invoke());
        _exitButton.onClick.AddListener(() => OnExitClick?.Invoke());
    }

    private void OnDestroy()
    {
        _continueButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }
}
