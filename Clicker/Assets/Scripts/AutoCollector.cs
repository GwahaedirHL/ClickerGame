using Cysharp.Threading.Tasks;
using UI;
using UnityEngine.Events;
using Zenject;

namespace Game
{
    public class AutoCollector : IInitializable
    {
        GameSettings gameSettings;
        CurrencyView currencyView;
        bool isTimerRunning;

        [Inject]
        public void Construct(GameSettings gameSettings, CurrencyView currencyView)
        {
            this.gameSettings = gameSettings;
            this.currencyView = currencyView;
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
                await UniTask.Delay(gameSettings.AutoCollectInterval);
                CurrentBalance.Value += gameSettings.AutoCollectCurrency;
                currencyView.UpdateCurrencyDisplay();
            }
        }
    }
}