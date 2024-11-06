using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ClickerObject : MonoBehaviour, IInitializable
    {
        [SerializeField]
        Button button;

        public event UnityAction Click;

        public void Initialize()
        {
            button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            Click?.Invoke();
        }
    }
}