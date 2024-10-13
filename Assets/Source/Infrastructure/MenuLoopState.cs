using Source.Init;
using Source.Menu;
using UnityEngine;

namespace Source.Infrastructure {
    public class MenuLoopState : IState {
        private readonly GameStateMachine _gameStateMachine;
        private MenuSceneEmitter _emitter;

        public MenuLoopState(GameStateMachine gameStateMachine) {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() {
            _emitter = Object.FindObjectOfType<MenuSceneEmitter>();
            _emitter.ConnectButton.onClick.AddListener(OnConnectButtonClick);
            _emitter.HostButton.onClick.AddListener(OnHostButtonClick);
        }

        public void Exit() {
            _emitter.ConnectButton.onClick.RemoveListener(OnConnectButtonClick);
            _emitter.HostButton.onClick.RemoveListener(OnHostButtonClick);
        }

        private void OnConnectButtonClick() {
            _gameStateMachine.Enter<LoadGameState, LoadingBar>(_emitter.LoadingBar);
        }

        private void OnHostButtonClick() {
            _gameStateMachine.Enter<LoadGameState, LoadingBar>(_emitter.LoadingBar);
        }
    }
}
