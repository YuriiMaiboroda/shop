using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.UI
{
    public class BundleShopItem : MonoBehaviour
    {
        public TextMeshProUGUI bundleName;
        public Button purchaseButton;
        
        private Bundle _bundle;

        public void Setup(Bundle bundle) {
            _bundle = bundle;
            bundleName.text = bundle.BundleName;

            purchaseButton.onClick.AddListener(HandleClick);
            
            foreach (var spendable in _bundle.Spendables) {
                spendable.Interface.CurrencyAmountChanged += UpdateButton;
            }
            UpdateButton();
        }

        private void HandleClick() {
            if (_bundle.CanBePurchased()) {
                _bundle.Purchase();
            }
        }

        private void UpdateButton() {
            purchaseButton.interactable = _bundle.CanBePurchased();
        }
    }
}