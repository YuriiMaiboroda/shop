using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(menuName = "Bricks/Locations/LocationBrick")]
    public class LocationBrick : ScriptableObject, IReward
    {
        [SerializeField] private string location;
        
        public void Reward() {
            LocationManager.Instance.Location = location;
        }
    }
}