using Assets.CodeBase.App.Client;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI.HUD;
using Assets.CodeBase.UI.Menu;

namespace Assets.CodeBase.App.StateMachine
{
    internal class CreateObjectsState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IResourcesProvider _resourcesProvider;
        private readonly WebSocketClient _webSocketClient;
        private readonly GameFactory _gameFactory;
        private readonly OdometerController _odometerController;
        private readonly AudioController _audioController;
        private readonly HUDController _hudController;
        private readonly MenuController _menuController;
        private readonly MessageSender _messageSender;

        public CreateObjectsState(GameStateMachine gameStateMachine,
                                  IResourcesProvider resourcesProvider,
                                  WebSocketClient webSocketClient,
                                  GameFactory gameFactory,
                                  OdometerController odometerController,
                                  AudioController audioController,
                                  HUDController hudController,
                                  MenuController menuController,
                                  MessageSender messageSender)
        {
            _gameStateMachine = gameStateMachine;
            _resourcesProvider = resourcesProvider;
            _webSocketClient = webSocketClient;
            _gameFactory = gameFactory;
            _odometerController = odometerController;
            _audioController = audioController;
            _hudController = hudController;
            _menuController = menuController;
            _messageSender = messageSender;
        }

        public void Enter()
        {
            CreateWebSocket();
            CreateOdometer();
            CreateHUD();
            InitialzeAudio();
            _gameStateMachine.Enter<GameState>();
        }

        public void Exit()
        {
        }

        private void InitialzeAudio()
        {
            _audioController.InitializeValues();
        }

        private void CreateHUD()
        {
            var hudView = _gameFactory.CreateHUD();
            hudView.StatusLamp.Constructor(_resourcesProvider, _webSocketClient);
            hudView.MenuButton.onClick.AddListener(_menuController.OpenOrCloseWindow);
            hudView.GetCurrentOdometerValueButton.onClick.AddListener(_messageSender.SendCurrentValueMessage);
            hudView.GetRandomOdometerValueButton.onClick.AddListener(_messageSender.SendRandomStatusValueMessage);
            hudView.StartBroadcastButton.onClick.AddListener(_hudController.StartBroadcast);
            _hudController.SetView(hudView);
        }

        private void CreateOdometer()
        {
            var odometerView = _gameFactory.CreateOdometer();
            _odometerController.SetView(odometerView);
        }

        private void CreateWebSocket()
        {
            _webSocketClient.CreateWebSocket();
        }
    }
}
