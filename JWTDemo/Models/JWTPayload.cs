using System;

namespace JWTDemo.Models
{
    public class JWTPayload
    {
        public string name { get; set; }
        public string role { get; set; }
        public DateTime exp { get; set; }
    }
}