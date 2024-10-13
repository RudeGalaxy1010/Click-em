using Source.Remote.Data;

namespace Source.Remote {
    public interface IPlayerConnectedHandler {
        public void HandlePlayerConnected(UserData userData);
    }
}
