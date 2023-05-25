using Newtonsoft.Json;

namespace Assets.CodeBase.Data.DTO.Responses
{
    public class ResponseOperationDTO
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }
    }
}
