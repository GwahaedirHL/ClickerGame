using Cysharp.Threading.Tasks;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField]
        Transform root;

        [SerializeField]
        float coinMoveDistance = 100f;

        [SerializeField]
        float coinMoveDuration = 0.5f;

        CoinsView.Factory coinFactory;

        [Inject]
        public void Constructor(CoinsView.Factory coinFactory)
        {
            this.coinFactory = coinFactory;
        }

        public async UniTaskVoid SpawnCoin(int coinAmount)
        {
            CoinsView coinPopup = coinFactory.Create();
            coinPopup.transform.SetParent(root);
            coinPopup.transform.position = root.position;
            coinPopup.transform.localRotation = Quaternion.identity;

            coinPopup.SetValueText(coinAmount.ToString());
            await MoveCoinUpward(coinPopup.GetComponent<RectTransform>());
            Destroy(coinPopup.gameObject);
        }

        async UniTask MoveCoinUpward(RectTransform coinTransform)
        {
            Vector3 startPosition = coinTransform.position;
            Vector3 targetPosition = startPosition + Vector3.up * coinMoveDistance;
            float time = 0;

            while (time < coinMoveDuration)
            {
                time += Time.deltaTime;
                coinTransform.position = Vector3.Lerp(startPosition, targetPosition, time / coinMoveDuration);
                await UniTask.Yield();
            }
            coinTransform.position = targetPosition;
        }
    }
}