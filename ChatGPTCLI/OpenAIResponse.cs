using System.Text.Json.Serialization;

namespace ChatGPTCLI
{
    public class OpenAIResponse
    {
        [JsonPropertyName("choices")]
        public List<Choice> Choices { get; set; } = new List<Choice>();

        public OpenAIResponse()
        {

        }
    }
}

