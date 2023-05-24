using Newtonsoft.Json;

namespace Assets.CodeBase.Data.DTO.Responses
{
    public class ResponseRandomValueDTO
    {
        [JsonProperty("odometer")]
        public float Value { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
