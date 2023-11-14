using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Bundles/Bundle")]
    public class Bundle : ScriptableObject
    {
        [SerializeField] private string bundleName;
        [SerializeField] private List<SpendableInterfaceReference> spendables = new();
        [SerializeField] private List<RewardInterfaceReference> rewards = new();

        private List<ISpendable> _spendables = new();

        public bool CanBePurchased() {
            foreach (var spendable in _spendables) {
                if (!spendable.CanSpend(_spendables)) {
                    return false;
                }
            }
            return true;
        }

        public void Purchase() {
            foreach (var element in spendables) {
                element.Interface.Spend();
            }
            foreach (var element in rewards) {
                element.Interface.Reward();
            }
        }

        private void OnEnable() {
            if (_spendables.Count > 0) {
                return;
            }
            foreach (var element in spendables) {
                _spendables.Add(element.Interface);
            }
        }

        public string BundleName {
            get => bundleName;
        }
        public List<SpendableInterfaceReference> Spendables {
            get => spendables;
        }
    }
}