using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Health
{
    public class HealthManager : Singleton<HealthManager>
    {
        [SerializeField] private int defaultHealth;
        [SerializeField] private int increaseValue;
        
        public event Action OnHealthChanged;

        private int _health;
        public int Health {
            get => _health;
            set {
                _health = value;
                OnHealthChanged?.Invoke();
            }
        }

        public bool CanSpend(IEnumerable<ISpendable> spendables) {
            int value = 0;
            foreach (var spendable in spendables) {
                var healthBrick = spendable as HealthBrick;
                if (healthBrick == null) {
                    continue;
                }
                if (!healthBrick.CanSpend()) {
                    return false;
                }
                value += healthBrick.GetValue();
            }
            return value <= Health;
        }

        public void IncreaseHealth() {
            Health += increaseValue;
        }

        protected override void Awake() {
            base.Awake();

            Health = defaultHealth;
        }
    }
}