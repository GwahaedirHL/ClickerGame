using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnergyBarView : MonoBehaviour
    {
        [SerializeField]
        Image energyBar;

        public void UpdateEnergy(float energy)
        {
            energyBar.fillAmount = energy;
            energyBar.color = Color.Lerp(Color.red, Color.green, energy);
        }
    }
}