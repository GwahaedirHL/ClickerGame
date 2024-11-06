using Game;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI currencyText;

        public void UpdateCurrencyDisplay()
        {
            currencyText.text = CurrentBalance.Value.ToString();
        }
    }
}