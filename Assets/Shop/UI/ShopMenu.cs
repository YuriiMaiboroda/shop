using UnityEngine;
using UnityEngine.UI;

namespace Shop.UI
{
    public class ShopMenu : MonoBehaviour
    {
        public HorizontalLayoutGroup layoutGroup;
        public BundleShopItem bundleShopItemPrefab;

        private void Start() {
            foreach (var bundle in ShopManager.Instance.Bundles.bundles) {
                var bundleShopItem = Instantiate(bundleShopItemPrefab, layoutGroup.transform);
                bundleShopItem.Setup(bundle);
            }
        }
    }
}