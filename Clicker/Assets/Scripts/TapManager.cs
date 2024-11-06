using UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class TapManager : IInitializable
    {
        readonly ClickerObject clicker;
        readonly GameSettings gameSettings;
        readonly CountdownTimer countdownTimer;
        readonly CurrencyView currencyView;
        readonly CoinSpawner coinSpawner;
        readonly EnergyController energyController;
        int collectedForPeriod;

        public TapManager(ClickerObject clicker,
                          GameSettings gameSettings,
                          CountdownTimer countdownTimer,
                          CurrencyView currencyView,
                          CoinSpawner coinSpawner,
                          EnergyController energyController)
        {
            this.clicker = clicker;
            this.gameSettings = gameSettings;
            this.countdownTimer = countdownTimer;
            this.currencyView = currencyView;
            this.coinSpawner = coinSpawner;
            this.energyController = energyController;
        }

        public void Initialize()
        {
            CurrentBalance.Value = 0;
            collectedForPeriod = 0;

            countdownTimer.StartTimer(gameSettings.CountdownInterval);

            clicker.Click += HandleClick;
            countdownTimer.OnTimerCompleted += ResetSum;
        }

        void HandleClick()
        {
            if (!energyController.HasEnergy) 
                return;

            energyController.SpendEnergy();
            collectedForPeriod += gameSettings.EarnPerTap(collectedForPeriod);
            CurrentBalance.Value += gameSettings.EarnPerTap(collectedForPeriod);

            currencyView.UpdateCurrencyDisplay();
            coinSpawner.SpawnCoin(gameSettings.EarnPerTap(collectedForPeriod)).Forget();
        }
        
        void ResetSum()
        {
            collectedForPeriod = 0;
        }
    }
}