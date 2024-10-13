using System;
using Newtonsoft.Json;

namespace Source.Remote.Data {
    [Serializable]
    public class GameOverData {
        [JsonProperty("WinnerName")]
        public string WinnerName;
    }
}
