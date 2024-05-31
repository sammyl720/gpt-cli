using System.Text.Json.Serialization;

namespace ChatGPTCLI
{
    public class Choice
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; }

        public Choice() { }

        public Choice(Message messages)
        {
            Message = messages;
        }
    }
}

