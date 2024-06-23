using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _mainMenuButton;

    public Action OnContinueClick;
    public Action OnMainMenuClick;

    private void Start()
    {
        _continueButton.onClick.AddListener(() => OnContinueClick?.Invoke());
        _mainMenuButton.onClick.AddListener(() => OnMainMenuClick?.Invoke());
    }

    private void OnDestroy()
    {
        _continueButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }
}
