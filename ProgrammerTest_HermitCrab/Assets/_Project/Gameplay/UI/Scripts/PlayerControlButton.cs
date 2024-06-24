using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControlButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> OnPressed { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressed?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPressed?.Invoke(false);
    }
}
