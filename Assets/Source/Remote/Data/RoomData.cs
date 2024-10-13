using System;
using Newtonsoft.Json;

namespace Source.Remote.Data {
    [Serializable]
    public class RoomData {
        [JsonProperty("Id")]
        public string Id;
        [JsonProperty("Name")]
        public string Name;
        [JsonProperty("UserName")]
        public string UserName;
    }
}
