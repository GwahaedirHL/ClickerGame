using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace UI
{
    public class ClickButtonAnimator : MonoBehaviour
    {
        [SerializeField]
        Button clickButton;

        [SerializeField]
        float scaleDownFactor = 0.85f;

        [SerializeField]
        float animationDuration = 0.1f;

        private CancellationTokenSource animationCancellationToken;

        private void Start()
        {
            clickButton.onClick.AddListener(() => RestartAnimation().Forget());
        }

        private async UniTaskVoid RestartAnimation()
        {
            animationCancellationToken?.Cancel();
            animationCancellationToken = new CancellationTokenSource();

            await AnimateButtonClick(animationCancellationToken.Token);
        }

        private async UniTask AnimateButtonClick(CancellationToken cancellationToken)
        {
            await ScaleButton(scaleDownFactor, cancellationToken);
            await ScaleButton(1f, cancellationToken);
        }

        private async UniTask ScaleButton(float targetScale, CancellationToken cancellationToken)
        {
            Vector3 target = Vector3.one * targetScale;
            float time = 0;
            while (time < animationDuration)
            {
                cancellationToken.ThrowIfCancellationRequested();

                time += Time.deltaTime;
                clickButton.transform.localScale = Vector3.Lerp(clickButton.transform.localScale, target, time / animationDuration);
                await UniTask.Yield(cancellationToken);
            }

            clickButton.transform.localScale = target;
        }

        private void OnDestroy()
        {
            animationCancellationToken?.Cancel();
            animationCancellationToken?.Dispose();
        }
    }
}