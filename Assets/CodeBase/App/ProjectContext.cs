using Assets.CodeBase.App;
using Assets.CodeBase.App.Client;
using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI.HUD;
using Assets.CodeBase.UI.Menu;
using Zenject;

public class ProjectContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<ILoadSaveDataFormat>().To<JsonLoadSaveDataService>().AsSingle();
        Container.Bind<ISceneService>().To<SceneService>().AsSingle();   
        Container.BindInterfacesAndSelfTo<WebSocketClient>().AsSingle();
        Container.Bind<OdometerController>().AsSingle();
        Container.Bind<IResourcesProvider>().To<ResourcesProvider>().AsSingle();
        Container.Bind<GameFactory>().AsSingle();
        Container.Bind<AudioController>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<IPersistentDataService>().To<PersistentDataService>().AsSingle();
        Container.Bind<MenuController>().AsSingle();
        Container.Bind<MessageSender>().AsSingle();
        Container.Bind<MessageDispatcher>().AsSingle();
        Container.Bind<HUDController>().AsSingle();
        Container.Bind<Notifyer>().FromComponentsInNewPrefabResource(Paths.NotyfierPath).AsSingle();
    }
}