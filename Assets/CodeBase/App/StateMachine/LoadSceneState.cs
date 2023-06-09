﻿using Assets.CodeBase.Services;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadSceneState : IParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneService _sceneService;

        public LoadSceneState(GameStateMachine gameStateMachine, ISceneService sceneService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneService = sceneService;
        }

        public void Enter<T>(T data)
        {
            var sceneName = data as string;
            _sceneService.Load(sceneName, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _gameStateMachine.Enter<CreateObjectsState>();
        }
    }
}
