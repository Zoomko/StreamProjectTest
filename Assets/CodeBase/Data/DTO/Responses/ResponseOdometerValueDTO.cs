using Newtonsoft.Json;

namespace Assets.CodeBase.Data.DTO.Responses
{
    public class ResponseOdometerValueDTO
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}