using Assets.CodeBase.App;
using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.Services;
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
    }
}