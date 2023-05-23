using Newtonsoft.Json;

namespace Assets.CodeBase.DTO.Responses
{
    public class ResponseDTO
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}