using System;
using UnityEngine;

public class PlayerHealth : BaseCharacterHealth
{
    [SerializeField] private int _maxHealth = 100;

    private int _health;
    public int Health
    {
        get => _health;
        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            if (_health == 0)
            {
                Die();
            }
        }
    }

    public int MaxHealth => _maxHealth;

    public Action OnDie;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
