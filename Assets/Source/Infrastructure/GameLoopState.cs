using Source.Config;
using Source.Data;
using Source.Game;
using Source.Init;
using UnityEngine;

namespace Source.Infrastructure {
    public class GameLoopState : IState {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly GameConfig _gameConfig;

        private IGameFactory _gameFactory;
        private GameSceneEmitter _emitter;
        private RoundData _roundData;
        private IGameFactory _factory;

        public GameLoopState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, 
            GameConfig gameConfig) {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
            _gameConfig = gameConfig;
        }

        public void Enter() {
            _roundData = new RoundData();
            _factory = Services.Container.Single<IGameFactory>();
            _emitter = Object.FindObjectOfType<GameSceneEmitter>();
            _emitter.ClickArea.onClick.AddListener(OnClickAreaClick);
            _emitter.GameOverPanel.BackButton.onClick.AddListener(() => 
                _gameStateMachine.Enter<LoadMenuState, LoadingBar>(_emitter.LoadingBar));
            _emitter.TimerDisplay.Set(_gameConfig.LevelTime);
            _emitter.ScoreDisplay.SetScore(0, 0);
            Timer timer = new Timer(_coroutineRunner);
            
            timer.Start(_gameConfig.LevelTime, onChange: _emitter.TimerDisplay.Set, onEnd: OnTimerEnd);
        }

        private void OnClickAreaClick() {
            _roundData.Score += _gameConfig.ScorePerClick;
            _emitter.ScoreDisplay.SetScore(_roundData.Score, 0);
            _factory.CreateFloatingScore(
                _gameConfig.ScorePerClick, 
                _emitter.FloatingScoreSpawnPoint,
                _gameConfig.FloatingScoreOffsets);
        }

        public void Exit() { }

        private void OnTimerEnd() {
            _emitter.GameOverPanel.Open("test");
        }
    }
}
