namespace Assets.CodeBase.App.StateMachine
{
    public class GameState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly WebSocketClient _webSocketClient;
        private readonly AudioController _audioController;

        public GameState(GameStateMachine gameStateMachine, WebSocketClient webSocketClient, AudioController audioController)
        {
            _gameStateMachine = gameStateMachine;
            _webSocketClient = webSocketClient;
            _audioController = audioController;
        }

        public void Enter()
        {
            _webSocketClient.Connect();
            _audioController.PlayMusic();
        }

        public void Exit()
        {
        }
    }
}
