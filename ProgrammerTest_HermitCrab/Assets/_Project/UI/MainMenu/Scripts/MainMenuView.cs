using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
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
