using UnityEngine;

public class EnemyHealth : BaseCharacterHealth
{
    [SerializeField] private EnemyHealthUI _enemyHealthUI;

    public override int Health
    {
        get => base.Health; protected set
        {
            base.Health = value;
            _enemyHealthUI.SetHealth(_health);
        }
    }

    public override void Destroy()
    {
        base.Destroy();
        _enemyHealthUI.gameObject.SetActive(false);
        DataEvent.DataEvent.Notify(new OnEnemyDefeatEvent(1));
    }
}
