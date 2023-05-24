using Assets.CodeBase.App.Client;
using Assets.CodeBase.App.Services;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI.HUD;
using Assets.CodeBase.UI.Menu;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.App.StateMachine
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;
        public GameStateMachine(IResourcesProvider resourcesProvider,
                                ISceneService sceneService,
                                WebSocketClient webSocketClient,
                                GameFactory gameFactory,
                                OdometerController odometerController,
                                AudioController audioController,
                                IPersistentDataService persistentDataService,
                                HUDController hudController,
                                MessageSender messageSender,
                                MenuController menuController)
        {
            _states = new Dictionary<Type, IState>
            {
                { typeof(LoadDataState), new LoadDataState(this,persistentDataService, resourcesProvider) },
                { typeof(LoadSceneState), new LoadSceneState(this, sceneService) },
                { typeof(CreateObjectsState), new CreateObjectsState(
                    this,
                    resourcesProvider,
                    webSocketClient,
                    gameFactory,
                    odometerController,
                    audioController,
                    hudController,
                    menuController,
                    messageSender) },
                { typeof(GameState), new GameState(this, webSocketClient,audioController) },
              
            };
        }

        public void Enter<T>() where T : INoneParameterizedState
        {
            if (!_states.ContainsKey(typeof(T)))
                throw new KeyNotFoundException();

            if (_currentState == null)
            {
                var state = _states[typeof(T)] as INoneParameterizedState;
                _currentState = state;
                state.Enter();
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T)] as INoneParameterizedState;
                _currentState = state;
                state.Enter();
            }
        }

        public void Enter<T1, T2>(T2 data) where T1 : IParameterizedState
        {
            if (!_states.ContainsKey(typeof(T1)))
                throw new KeyNotFoundException();
            if (_currentState == null)
            {
                var state = _states[typeof(T1)] as IParameterizedState;
                _currentState = state;
                state.Enter(data);
            }
            else
            {
                _currentState.Exit();
                var state = _states[typeof(T1)] as IParameterizedState;
                _currentState = state;
                state.Enter(data);
            }
        }
    }
}
