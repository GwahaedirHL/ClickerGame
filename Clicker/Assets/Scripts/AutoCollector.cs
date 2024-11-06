using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using Zenject;

namespace Game
{
    public class AutoCollector : IInitializable
    {
        GameSettings currencySettings;
        bool isTimerRunning;

        public event UnityAction<int> AddCurrency;

        [Inject]
        public void Construct(GameSettings currencySettings)
        {
            this.currencySettings = currencySettings;
        }

        public void Initialize()
        {
            isTimerRunning = true;
            StartTimer().Forget();
        }

        async UniTaskVoid StartTimer()
        {
            while (isTimerRunning)
            {
                await UniTask.Delay(currencySettings.AutoCollectInterval);
                AddCurrency?.Invoke(currencySettings.AutoCollectCurrency);
            }
        }
    }
}