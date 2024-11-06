using TMPro;
using UnityEngine;

namespace UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI currencyText;

        public void UpdateCurrencyDisplay(int amount)
        {
            currencyText.text = amount.ToString();
        }
    }
}