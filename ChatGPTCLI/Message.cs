using System.Text.Json.Serialization;

namespace ChatGPTCLI
{
    public class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }


        [JsonPropertyName("content")]
        public string Content { get; set; }

        public Message() { }

        public Message(Role role, string content)
        {
            Role = role.ToString().ToLower();
            Content = content;
        }
    }
}

