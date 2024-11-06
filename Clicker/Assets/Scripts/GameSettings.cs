using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {

        [SerializeField, Header("Базовое значение валюты за тап")]
        int baseCurrencyPerTap = 10;

        [SerializeField, Header("Интервал автосбора (в миллисекундах)")]
        int autoCollectInterval = 5000;

        [SerializeField, Header("Сумма автосбора за интервал")]
        int autoCollectCurrency = 100;

        [SerializeField, Header("Процент бонуса от автосбора")]
        public float autoCollectBonusPercent = 0.1f;

        [SerializeField, Header("Использовать бонус")]
        public bool useBonus = true;

        /// <summary>
        /// Значение валюты с добавочным бонусом от автосбора
        /// </summary>
        int currencyWithBonus => (int)Mathf.Round(autoCollectCurrency * autoCollectBonusPercent) + baseCurrencyPerTap;

        public int AutoCollectInterval => autoCollectInterval;

        public int AutoCollectCurrency => autoCollectCurrency;

        public int CurrencyPerTap => useBonus ? currencyWithBonus : baseCurrencyPerTap;
    }
}