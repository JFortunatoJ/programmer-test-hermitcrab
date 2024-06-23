using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public void Init(int maxHealth, int health)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = health;
    }

    public void SetHealth(int health)
    {
        _healthBar.DOValue(health, .15f);
    }
}
