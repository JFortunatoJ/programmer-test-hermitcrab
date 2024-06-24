using UnityEngine;

namespace DataEvent.Example
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 1;

        private float _currentHealth;

        public float Health
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
                DataEvent.Notify(new PlayerHealthEvent(_currentHealth));
            }
        }

        public void Init()
        {
            Health = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
        }
    }
}