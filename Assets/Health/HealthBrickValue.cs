using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(menuName = "Bricks/Health/HealthBrickValue")]
    public class HealthBrickValue : HealthBrick
    {
        [SerializeField] private int value;

        public override bool CanSpend() {
            return HealthManager.Instance.Health >= value;
        }

        public override bool CanSpend(IEnumerable<ISpendable> neighbours) {
            return HealthManager.Instance.CanSpend(neighbours);
        }

        public override void Spend() {
            HealthManager.Instance.Health -= value;
        }

        public override int GetValue() {
            return value;
        }

        public override void Reward() {
            HealthManager.Instance.Health += value;
        }
    }
}