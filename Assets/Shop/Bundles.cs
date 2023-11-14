using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Bundles/Bundles")]
    public class Bundles : ScriptableObject
    {
        public List<Bundle> bundles = new();
    }
}