using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    private void OnEnable()
    {
        DataEvent.DataEvent.Register<OnPlayerHealthChangeEvent>(UpdatePlayerHealth);
    }

    private void OnDisable()
    {
        DataEvent.DataEvent.Unregister<OnPlayerHealthChangeEvent>(UpdatePlayerHealth);
    }

    private void UpdatePlayerHealth(OnPlayerHealthChangeEvent playerHealth)
    {
        _healthSlider.DOValue(playerHealth.health, .15f);
    }
}
