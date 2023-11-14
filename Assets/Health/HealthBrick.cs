using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Health
{
    public abstract class HealthBrick : ScriptableObject, IReward, ISpendable
    {
        public abstract void Reward();
        public abstract bool CanSpend();
        public abstract bool CanSpend(IEnumerable<ISpendable> neighbours);
        public abstract void Spend();
        public abstract int GetValue();

        public event Action CurrencyAmountChanged {
            add => HealthManager.Instance.OnHealthChanged += value;
            remove => HealthManager.Instance.OnHealthChanged -= value;
        }
    }
}