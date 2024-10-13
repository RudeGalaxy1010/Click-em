using Cysharp.Threading.Tasks;
using Source.Config;
using Source.Init;
using UnityEngine;

namespace Source.Infrastructure {
    public class LoadGameState : IPayloadedState<LoadingBar> {
        private const float SceneLoadingMaxValue = 0.9f;
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        
        private LoadingBar _loadingBar;

        public LoadGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter(LoadingBar payload) {
            _loadingBar = payload;

            await LoadGameAsync();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit() { }
        
        private async UniTask LoadGameAsync() {
            AsyncOperation loadingOperation = _sceneLoader.LoadGameSceneAsync();
            
            while (!loadingOperation.isDone) {
                float sceneProgress = Mathf.Clamp01(loadingOperation.progress / SceneLoadingMaxValue);
                _loadingBar.SetProgress(sceneProgress);
                await UniTask.Yield();
            }
        }
    }
}
