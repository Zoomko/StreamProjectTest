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
        RegisterDataServices();
        RegisterControllers();
        RegisterClientServices();
        RegisterMainStateMachine();
        RegisterCoroutineService();
        RegisterSceneService();
        RegisterFactoryService();
        RegisterNotificationService();
    }

    private void RegisterNotificationService() 
        => Container.Bind<Notifyer>().FromComponentsInNewPrefabResource(Paths.NotyfierPath).AsSingle();

    private void RegisterMainStateMachine() 
        => Container.Bind<GameStateMachine>().AsSingle();

    private void RegisterCoroutineService() 
        => Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();

    private void RegisterSceneService() 
        => Container.Bind<ISceneService>().To<SceneService>().AsSingle();

    private void RegisterFactoryService() 
        => Container.Bind<GameFactory>().AsSingle();

    private void RegisterClientServices()
    {
        Container.BindInterfacesAndSelfTo<WebSocketClient>().AsSingle();
        Container.Bind<MessageSender>().AsSingle();
        Container.Bind<MessageDispatcher>().AsSingle();
    }

    private void RegisterControllers()
    {
        Container.Bind<OdometerController>().AsSingle();
        Container.Bind<MenuController>().AsSingle();
        Container.BindInterfacesAndSelfTo<HUDController>().AsSingle();
        Container.Bind<AudioController>().FromNewComponentOnNewGameObject().AsSingle();
    }

    private void RegisterDataServices()
    {
        Container.Bind<ILoadSaveDataFormat>().To<JsonLoadSaveDataService>().AsSingle();
        Container.Bind<IResourcesProvider>().To<ResourcesProvider>().AsSingle();
        Container.Bind<IPersistentDataService>().To<PersistentDataService>().AsSingle();
    }
}