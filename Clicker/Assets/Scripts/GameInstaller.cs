using Game;
using UI;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameSettings gameSettings;
    public ClickerObject clickerPrefab;
    public CoinSpawner coinSpawner;
    public CurrencyView currencyView;
    public GameObject coinPopupPrefab;
    public EnergyBarView energyBarView;

    public override void InstallBindings()
    {        
        Container.BindInstance(gameSettings).AsSingle();
        Container.BindInterfacesAndSelfTo<TapManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<CountdownTimer>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<AutoCollector>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EnergyController>().AsSingle().NonLazy();
        
        Container.Bind<CurrencyView>().FromInstance(currencyView).AsSingle();
        Container.BindInterfacesAndSelfTo<ClickerObject>().FromInstance(clickerPrefab).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EnergyBarView>().FromInstance(energyBarView).AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<CoinSpawner>().FromInstance(coinSpawner).AsSingle();
        Container.BindFactory<CoinsView, CoinsView.Factory>().FromComponentInNewPrefab(coinPopupPrefab);
    }
}