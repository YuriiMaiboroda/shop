using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(menuName = "Bricks/Health/HealthBrickPercent")]
    public class HealthBrickPercent : HealthBrick
    {
        [SerializeField] [Range(1, 100)] private int value;

        public override bool CanSpend() {
            return GetResultValue() > 0;
        }

        public override bool CanSpend(IEnumerable<ISpendable> neighbours) {
            return HealthManager.Instance.CanSpend(neighbours);
        }

        public override void Spend() {
            HealthManager.Instance.Health -= GetResultValue();
        }

        public override int GetValue() {
            return GetResultValue();
        }

        public override void Reward() {
            HealthManager.Instance.Health += GetResultValue();
        }

        private int GetResultValue() {
            return (int)(HealthManager.Instance.Health * (value / 100.0f));
        }
    }
}