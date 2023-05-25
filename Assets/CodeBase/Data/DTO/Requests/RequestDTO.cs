using Newtonsoft.Json;

namespace Assets.CodeBase.Data.DTO.Requests
{
    public class RequestDTO
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }
    }
}