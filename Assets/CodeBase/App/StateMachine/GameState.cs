using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.App.StateMachine
{
    public class GameState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly WebSocketClient _webSocketClient;

        public GameState(GameStateMachine gameStateMachine, WebSocketClient webSocketClient)
        {
            _gameStateMachine = gameStateMachine;
            _webSocketClient = webSocketClient;
        }

        public void Enter()
        {
            _webSocketClient.Connect();            
        }

        public void Exit()
        {
        }
    }
}
