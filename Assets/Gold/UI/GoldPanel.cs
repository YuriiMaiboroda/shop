using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gold.UI
{
    public class GoldPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI value;
        [SerializeField] private Button cheatButton;
    
        void Start()
        {
            cheatButton.onClick.AddListener(CheatButtonHandler);
            GoldManager.Instance.OnGoldChanged += UpdateValue;
            UpdateValue();
        }

        private void CheatButtonHandler() {
            GoldManager.Instance.IncreaseGold();
        }

        private void UpdateValue() {
            value.text = GoldManager.Instance.Gold.ToString();
        }
    }
}