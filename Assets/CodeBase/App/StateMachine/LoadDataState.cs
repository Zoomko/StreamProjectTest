using Assets.CodeBase.Services;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadDataState: INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentDataService _persistentDataService;
        private readonly IResourcesProvider _resourcesProvider;
        private readonly string _nextScene = "Game";

        public LoadDataState(GameStateMachine gameStateMachine, IPersistentDataService persistentDataService, IResourcesProvider resourcesProvider)
        {
            _gameStateMachine = gameStateMachine;
            _persistentDataService = persistentDataService;
            _resourcesProvider = resourcesProvider;
        }

        public void Enter()
        {            
            _resourcesProvider.Load();
            _persistentDataService.Load();
            _gameStateMachine.Enter<LoadSceneState, string>(_nextScene);
        }

        public void Exit()
        {
            
        }
    }
}
