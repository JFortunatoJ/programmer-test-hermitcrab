using System;
using System.Collections;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TimerUI _view;

    private TimeSpan _time;
    private float _seconds;
    private Coroutine _timerCoroutine;

    public void StartTimer(int seconds, Action onTimeOver)
    {
        _seconds = seconds;
        _timerCoroutine = StartCoroutine(TimerCoroutine(onTimeOver));
    }

    public void StopTimer()
    {
        if (_timerCoroutine == null) return;

        StopCoroutine(_timerCoroutine);
    }

    private IEnumerator TimerCoroutine(Action onTimeOver)
    {
        while (_seconds > 0)
        {
            _seconds -= Time.deltaTime;
            _view.DisplayTime((int)_seconds);
            yield return null;
        }

        onTimeOver?.Invoke();
    }
}
