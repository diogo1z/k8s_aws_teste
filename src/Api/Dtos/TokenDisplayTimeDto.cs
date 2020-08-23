using System;
using Newtonsoft.Json;

namespace Api.Dtos
{
    public class TokenDisplayTimeDto
    {
        [JsonProperty("displayTime")]
        public string DisplayTime { get; set; }

        public TokenDisplayTimeDto(int minutes)
        {
            DisplayTime = new TimeSpan(0, minutes, 0).ToString();
        }
    }
}