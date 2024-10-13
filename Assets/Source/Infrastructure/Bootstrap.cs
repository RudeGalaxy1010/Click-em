using Source.Config;
using UnityEngine;

namespace Source.Infrastructure {
    public class Bootstrap : MonoBehaviour, ICoroutineRunner {
        [SerializeField] private GameConfig _gameConfig;
        
        private Game _game;

        private void Awake() {
            _game = new Game(this, _gameConfig);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}
