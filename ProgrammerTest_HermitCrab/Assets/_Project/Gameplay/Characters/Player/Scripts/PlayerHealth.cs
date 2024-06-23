using System;
using UnityEngine;

public class PlayerHealth : BaseCharacterHealth
{
    public override int Health
    {
        get => base.Health; protected set
        {
            base.Health = value;
            DataEvent.DataEvent.Notify(new OnPlayerHealthChangeEvent(_maxHealth, _health));
        }
    }

    public override void Init(Action onDie, SpriteRenderer characterRenderer)
    {
        base.Init(onDie, characterRenderer);

        DataEvent.DataEvent.Notify(new OnPlayerHealthChangeEvent(_maxHealth, _health));
    }
}
