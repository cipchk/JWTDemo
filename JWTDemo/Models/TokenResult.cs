using Newtonsoft.Json;
using System;

namespace JWTDemo.Models
{
    public class TokenResult
    {
        public string token { get; set; }

        [JsonConverter(typeof(UtcDateTimeConverter))]
        public DateTime expires { get; set; }
    }
}