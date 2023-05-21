using Newtonsoft.Json;

public class RequestDTO
{
    [JsonProperty("operation")]
    public string Operation { get; set; }
}
