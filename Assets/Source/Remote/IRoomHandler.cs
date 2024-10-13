using Source.Remote.Data;

namespace Source.Remote {
    public interface IRoomHandler {
        public void UpdateAvailableRooms(AvailableRoomsData availableRoomsData);
    }
}
