using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseScreenView
{
    [SerializeField] private Button _playButton;

    public Action OnPlayButtonClick;

    private void Start()
    {
        _playButton.onClick.AddListener(() => OnPlayButtonClick?.Invoke());
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveAllListeners();
    }
}
