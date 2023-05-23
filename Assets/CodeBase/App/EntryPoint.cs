using Assets.CodeBase.App.StateMachine;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App
{
    public class EntryPoint : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        [Inject]
        public void Constructor(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        void Start()
        {
            _gameStateMachine.Enter<LoadDataState>();
        }

    }
}