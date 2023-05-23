using Newtonsoft.Json;

namespace Assets.CodeBase.App
{
    public class Config
    {
        [JsonProperty("Server address")]
        public string ServerAddress { get; set; }

        [JsonProperty("Server port")]
        public string ServerPort { get; set; }
        public override string ToString()
        {
            return ServerAddress + ":" + ServerPort;
        }
    }
}
