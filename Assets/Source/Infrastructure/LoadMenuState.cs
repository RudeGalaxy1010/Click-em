using Cysharp.Threading.Tasks;
using Source.Init;
using UnityEngine;

namespace Source.Infrastructure {
    public class LoadMenuState : IPayloadedState<LoadingBar> {
        private const float SceneLoadingMaxValue = 0.9f;

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        
        private LoadingBar _loadingBar;

        public LoadMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter(LoadingBar payload) {
            _loadingBar = payload;
            
            await LoadMenuAsync();
            
            _gameStateMachine.Enter<MenuLoopState>();
        }

        public void Exit() { }

        private async UniTask LoadMenuAsync() {
            AsyncOperation loadingOperation = _sceneLoader.LoadMenuSceneAsync();
            loadingOperation.allowSceneActivation = false;

            while (loadingOperation.progress < SceneLoadingMaxValue) {
                float sceneProgress = Mathf.Clamp01(loadingOperation.progress / SceneLoadingMaxValue);
                _loadingBar.SetProgress(sceneProgress);
                await UniTask.Yield();
            }

            loadingOperation.allowSceneActivation = true;
        }
    }
}
