using System;
using System.Text.Json.Serialization;


namespace SeleniumTask2.Application.RestApiClient.Common
{
    public record TokenResponse
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}

