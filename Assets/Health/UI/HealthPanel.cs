using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Health.UI
{
    public class HealthPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI value;
        [SerializeField] private Button cheatButton;
    
        void Start()
        {
            cheatButton.onClick.AddListener(CheatButtonHandler);
            HealthManager.Instance.OnHealthChanged += UpdateValue;
            UpdateValue();
        }

        private void CheatButtonHandler() {
            HealthManager.Instance.IncreaseHealth();
        }

        private void UpdateValue() {
            value.text = HealthManager.Instance.Health.ToString();
        }
    }
}
