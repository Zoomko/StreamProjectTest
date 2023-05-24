﻿using Assets.CodeBase.Odometer;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI.Menu;
using System;

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
        private readonly MenuController _menuController;

        public CreateObjectsState(GameStateMachine gameStateMachine, IResourcesProvider resourcesProvider, WebSocketClient webSocketClient, GameFactory gameFactory, OdometerController odometerController, AudioController audioController, MenuController menuController)
        {
            _gameStateMachine = gameStateMachine;
            _resourcesProvider = resourcesProvider;           
            _webSocketClient = webSocketClient;
            _gameFactory = gameFactory;
            _odometerController = odometerController;
            _audioController = audioController;
            _menuController = menuController;
        }

        public void Enter()
        {
            _webSocketClient.CreateWebSocket();

            var odometerView = _gameFactory.CreateOdometer();
            _odometerController.SetView(odometerView);

            var hud = _gameFactory.CreateHUD();
            hud.Constructor(_webSocketClient, _resourcesProvider);

            hud.MenuButton.onClick.AddListener(_menuController.OpenOrCloseWindow);

            _audioController.InitializeValues();

            _gameStateMachine.Enter<GameState>();
        }

        public void Exit()
        {
        }
    }
}
