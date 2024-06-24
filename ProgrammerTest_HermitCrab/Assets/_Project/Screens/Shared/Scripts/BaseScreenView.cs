using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class BaseScreenView : MonoBehaviour
{
    protected CanvasGroup _canvasGroup;

    public virtual void Init()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        Show();
    }

    public virtual void Show()
    {
        _canvasGroup.DOFade(1, .25f);
        _canvasGroup.blocksRaycasts = true;
    }

    public virtual void Hide(Action onHide = null)
    {
        _canvasGroup.DOFade(0, .25f).onComplete = () =>
        {
            _canvasGroup.blocksRaycasts = false;
            onHide?.Invoke();
        };
    }
}
