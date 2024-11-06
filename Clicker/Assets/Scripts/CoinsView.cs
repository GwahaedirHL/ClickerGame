using TMPro;
using UnityEngine;
using Zenject;

namespace UI 
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI valueText;

        public void SetValueText(string value) => valueText.text = $"+ {value}";

        public class Factory : PlaceholderFactory<CoinsView> { }
    }
}