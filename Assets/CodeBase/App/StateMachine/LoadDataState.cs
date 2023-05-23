using Assets.CodeBase.Services;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadDataState: INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine; 
        private readonly IResourcesProvider _resourcesProvider;
        private readonly string _nextScene = "Game";

        public LoadDataState(GameStateMachine gameStateMachine, IResourcesProvider resourcesProvider)
        {
            _gameStateMachine = gameStateMachine;         
            _resourcesProvider = resourcesProvider;
        }

        public void Enter()
        {            
            _resourcesProvider.Load();
            _gameStateMachine.Enter<LoadSceneState, string>(_nextScene);
        }

        public void Exit()
        {
            
        }
    }
}
