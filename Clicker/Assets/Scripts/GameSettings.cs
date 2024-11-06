using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {

        [SerializeField, Header("������� �������� ������ �� ���")]
        int baseCurrencyPerTap = 10;

        [SerializeField, Header("�������� ��������� (� �������������)")]
        int autoCollectInterval = 5000;

        [SerializeField, Header("����� ��������� �� ��������")]
        int autoCollectCurrency = 100;

        [SerializeField, Header("������� ������ �� ���������")]
        public float autoCollectBonusPercent = 0.1f;

        [SerializeField, Header("������������ �����")]
        public bool useBonus = true;

        /// <summary>
        /// �������� ������ � ���������� ������� �� ���������
        /// </summary>
        int currencyWithBonus => (int)Mathf.Round(autoCollectCurrency * autoCollectBonusPercent) + baseCurrencyPerTap;

        public int AutoCollectInterval => autoCollectInterval;

        public int AutoCollectCurrency => autoCollectCurrency;

        public int CurrencyPerTap => useBonus ? currencyWithBonus : baseCurrencyPerTap;
    }
}