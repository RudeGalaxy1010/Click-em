using Newtonsoft.Json;

namespace Source.Remote.Data {
    public class UserData {
        [JsonProperty("Name")]
        public string Name;
        [JsonProperty("Score")]
        public int Score;
    }
}
