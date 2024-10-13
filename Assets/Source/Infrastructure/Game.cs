using Source.Config;

namespace Source.Infrastructure {
    public class Game {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, GameConfig gameConfig) {
            StateMachine = new GameStateMachine(new SceneLoader(), coroutineRunner, gameConfig);
        }
    }
}
