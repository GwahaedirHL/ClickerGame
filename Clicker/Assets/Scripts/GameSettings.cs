using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {

        [SerializeField, Header("Базовое значение валюты за тап")]
        int baseCurrencyPerTap = 10;        

        [SerializeField, Header("Модификатор тапа")]
        int modifier = 1;

        [SerializeField, Header("Период времени в секундах")]
        int countdownInterval = 5;

        [SerializeField, Header("Делитель времени")]
        int divisor = 1;

        [SerializeField, Header("Стоимость клика в процентах энергии"), Range(0f, 1f)]
        float clickEnergyCost = 0.1f;

        [Space, Header("Автосбор")]
        [SerializeField, Header("Интервал автосбора (в миллисекундах)")]
        int autoCollectInterval = 5000;

        [SerializeField, Header("Сумма автосбора за интервал")]
        int autoCollectCurrency = 100;

        [SerializeField, Header("Процент бонуса от автосбора")]
        public float autoCollectBonusPercent = 0.1f;

        [SerializeField, Header("Использовать бонус от автосбора")]
        public bool useBonus = true;

        /// <summary>
        /// Значение валюты с добавочным бонусом от автосбора
        /// </summary>
        int CurrencyWithBonus => Mathf.RoundToInt(autoCollectCurrency * autoCollectBonusPercent) + baseCurrencyPerTap;
        int CurrencyPerTap => useBonus ? CurrencyWithBonus : baseCurrencyPerTap;

        public int AutoCollectInterval => autoCollectInterval;
        public int AutoCollectCurrency => autoCollectCurrency;
        public int CountdownInterval => countdownInterval;
        public float ClickEnergyCost => clickEnergyCost;

        public int EarnPerTap(int collectedForPeriod)
        {
            if (collectedForPeriod == 0)
                return CurrencyPerTap;

            else
                return CurrencyPerTap * modifier + collectedForPeriod / divisor;
        }
    }
}