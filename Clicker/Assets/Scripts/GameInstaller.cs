using Game;
using UI;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameSettings gameSettings;
    public ClickerObject clickerPrefab;
    public CurrencyView currencyView;
    public GameObject coinPopupPrefab;

    public override void InstallBindings()
    {        
        Container.BindInstance(gameSettings).AsSingle();
        Container.Bind<CurrencyView>().FromInstance(currencyView).AsSingle();
        Container.BindInterfacesAndSelfTo<ClickerObject>().FromInstance(clickerPrefab).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<AutoCollector>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CurrencyManager>().AsSingle();
        Container.BindFactory<CoinsView, CoinsView.Factory>().FromComponentInNewPrefab(coinPopupPrefab);
    }
}