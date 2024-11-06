using UI;
using Zenject;

namespace Game
{
    public class EnergyController : IInitializable
    {
        readonly EnergyBarView barView;
        readonly GameSettings gameSettings;
        float energyLeft;

        public bool HasEnergy => energyLeft > 0f;

        public EnergyController(EnergyBarView barView, GameSettings gameSettings)
        {
            this.barView = barView;
            this.gameSettings = gameSettings;
        }

        public void Initialize()
        {
            energyLeft = 1f;
            barView.UpdateEnergy(energyLeft);
        }

        public void SpendEnergy()
        {
            energyLeft -= gameSettings.ClickEnergyCost;
            barView.UpdateEnergy(energyLeft);
        }
    }
}