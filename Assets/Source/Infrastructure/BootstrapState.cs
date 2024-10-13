using Cysharp.Threading.Tasks;
using Source.Init;
using Telegram;
using UnityEngine;

namespace Source.Infrastructure {
    public class BootstrapState : IState {
        private readonly GameStateMachine _gameStateMachine;
        private InitSceneEmitter _emitter;

        public BootstrapState(GameStateMachine gameStateMachine) {
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter() {
            RegisterServices();
            
            await LoadServerDataAsync();

            _emitter = Object.FindObjectOfType<InitSceneEmitter>();
            _gameStateMachine.Enter<LoadMenuState, LoadingBar>(_emitter.LoadingBar);
        }

        public void Exit() { }

        private void RegisterServices() {
            IAssetsProvider assetsProvider = new LocalAssetsProvider();
            Services.Container.RegisterSingle<IGameFactory>(new GameFactory(assetsProvider));
        }

        private async UniTask LoadServerDataAsync() {
            string userId = TelegramBridge.Instance.GetUserId();
        
            // AuthResponse authData = await Server.RequestAuth(new AuthRequest {
            //     GameId = Constants.GameId,
            //     UserId = userId,
            // });

            // if (string.IsNullOrEmpty(authData.SessionId) || authData.ItemsData == null) {
            //     return;
            // }
        
            // AuthLocalData.AuthData = new AuthData {
            //     sessionId = authData.SessionId,
            //     CountableItems = authData.ItemsData.CountableItems,
            //     UniqueItems = authData.ItemsData.UniqueItems,
            // };
        }
    }
}
