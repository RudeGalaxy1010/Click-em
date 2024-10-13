using System;
using Newtonsoft.Json;

namespace Source.Remote.Data {
    [Serializable]
    public class GameOverData {
        [JsonProperty("Score")]
        public int Score;
        [JsonProperty("WinnerName")]
        public string WinnerName;
    }
}
