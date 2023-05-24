using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Data.DTO.Responses
{
    public class ResponseOperationDTO
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }
    }
}
