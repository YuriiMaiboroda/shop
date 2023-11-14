using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(menuName = "Bricks/Gold/GoldBrickValue")]
    public class GoldBrickValue : ScriptableObject, IReward, ISpendable
    {
        [SerializeField] private int value;

        public bool CanSpend() {
            return GoldManager.Instance.Gold >= value;
        }

        public bool CanSpend(IEnumerable<ISpendable> neighbours) {
            return GoldManager.Instance.CanSpend(neighbours);
        }

        public void Spend() {
            GoldManager.Instance.Gold -= value;
        }

        public event Action CurrencyAmountChanged {
            add => GoldManager.Instance.OnGoldChanged += value;
            remove => GoldManager.Instance.OnGoldChanged -= value;
        }

        public void Reward() {
            GoldManager.Instance.Gold += value;
        }

        public int GetValue() {
            return value;
        }
    }
}