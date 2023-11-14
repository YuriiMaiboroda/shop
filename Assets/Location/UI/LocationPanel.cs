using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Location.UI
{
    public class LocationPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI value;
        [SerializeField] private Button cheatButton;
    
        void Start()
        {
            cheatButton.onClick.AddListener(CheatButtonHandler);
            LocationManager.Instance.OnLocationChanged += UpdateValue;
            UpdateValue();
        }

        private void CheatButtonHandler() {
            LocationManager.Instance.ResetLocation();
        }

        private void UpdateValue() {
            value.text = LocationManager.Instance.Location;
        }
    }
}