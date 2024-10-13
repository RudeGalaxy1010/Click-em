using Source.Remote.Data;

namespace Source.Remote {
    public interface IGameOverHandler {
        public void HandleGameOver(GameOverData gameOverData);
    }
}
