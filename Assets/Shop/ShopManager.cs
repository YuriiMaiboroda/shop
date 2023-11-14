using Core;
using UnityEngine;

namespace Shop
{
    public class ShopManager : Singleton<ShopManager>
    {
        [SerializeField] private Bundles bundles;
        public Bundles Bundles {
            get => bundles;
        }
    }
}