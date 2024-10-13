using Source.Config;
using Source.Game;
using UnityEngine;

namespace Source.Infrastructure {
    public class GameLoopState : IState {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly GameConfig _gameConfig;

        private IGameFactory _gameFactory;
        private GameSceneEmitter _emitter;

        public GameLoopState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, 
            GameConfig gameConfig) {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
            _gameConfig = gameConfig;
        }

        public void Enter() {
            _emitter = Object.FindObjectOfType<GameSceneEmitter>();
            // _gameFactory = Services.Container.Single<IGameFactory>();
            // Timer timer = new Timer(_coroutineRunner);
            // timer.Start(_gameConfig.LevelTime, _gameFactory.GameCanvas.UpdateTimerDisplay, OnTimerEnd);
        }

        public void Exit() { }

        private void OnTimerEnd() {
            Debug.Log("Level failed");
        }
    }
}
