using Newtonsoft.Json;

namespace Assets.CodeBase.Data.DTO.Responses
{
    public class ResponseCurrentOdometerValueDTO
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("odometer")]
        public string Value { get; set; }
    }
}
