using System;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void DisplayTime(int seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        _timerText.text = $"{time.Minutes}:{time.Seconds:00}";
    }
}
