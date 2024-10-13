using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Source.Remote.Data {
    [Serializable]
    public class AvailableRoomsData {
        [JsonProperty("Rooms")]
        public List<RoomData> Rooms;
    }
}
