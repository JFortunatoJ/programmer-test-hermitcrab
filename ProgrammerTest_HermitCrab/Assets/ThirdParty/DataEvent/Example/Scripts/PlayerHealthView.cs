using UnityEngine;
using UnityEngine.UI;

namespace DataEvent.Example
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;

        private void OnEnable()
        {
            DataEvent.Register<PlayerHealthEvent>(OnPlayerHealthChanged);
        }
        
        private void OnDisable()
        {
            DataEvent.Unregister<PlayerHealthEvent>(OnPlayerHealthChanged);
        }

        private void OnPlayerHealthChanged(PlayerHealthEvent eventData)
        {
            _healthSlider.value = eventData.Health;
        }
    }
}