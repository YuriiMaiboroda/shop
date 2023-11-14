using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Gold
{
    public class GoldManager : Singleton<GoldManager>
    {
        [SerializeField] private int defaultGold;
        [SerializeField] private int increaseValue;
        
        public event Action OnGoldChanged;

        private int _gold;
        public int Gold {
            get => _gold;
            set {
                _gold = value;
                OnGoldChanged?.Invoke();
            }
        }

        public bool CanSpend(IEnumerable<ISpendable> spendables) {
            int value = 0;
            foreach (var spendable in spendables) {
                var brick = spendable as GoldBrickValue;
                if (brick == null) {
                    continue;
                }
                if (!brick.CanSpend()) {
                    return false;
                }
                value += brick.GetValue();
            }
            return value <= Gold;
        }

        public void IncreaseGold() {
            Gold += increaseValue;
        }

        protected override void Awake() {
            base.Awake();

            Gold = defaultGold;
        }
    }
}