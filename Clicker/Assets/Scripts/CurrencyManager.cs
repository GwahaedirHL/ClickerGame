using UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CurrencyManager : IInitializable
    {
        readonly ClickerObject clicker;
        readonly AutoCollector autoCollector;
        readonly GameSettings gameSettings;
        readonly CurrencyView currencyView;
        int currentBalance;

        public CurrencyManager(ClickerObject clicker, AutoCollector autoCollector, GameSettings gameSettings, CurrencyView currencyView)
        {
            this.clicker = clicker;
            this.autoCollector = autoCollector;
            this.gameSettings = gameSettings;
            this.currencyView = currencyView;
        }

        public void Initialize()
        {
            clicker.Click += () => AddCurrency(gameSettings.CurrencyPerTap);
            autoCollector.AddCurrency += AddCurrency;
            currentBalance = 0;
            currencyView.UpdateCurrencyDisplay(0);
        }

        void AddCurrency(int amount)
        {
            currentBalance += amount;
            currencyView.UpdateCurrencyDisplay(currentBalance);
        }
    }
}