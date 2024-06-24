using System;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreenView : BaseScreenView
{
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _exitButton;

    public Action OnTryAgain;
    public Action OnExitMenu;

    private void Start()
    {
        _tryAgainButton.onClick.AddListener(() => OnTryAgain?.Invoke());
        _exitButton.onClick.AddListener(() => OnExitMenu?.Invoke());
    }

    private void OnDestroy()
    {
        _tryAgainButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }
}
