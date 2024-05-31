using System;
using System.Text.Json.Serialization;

namespace ChatGPTCLI
{
    public class OpenAIRequest
	{
		[JsonPropertyName("model")]
		public string Model { get; init; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; init; }

        public OpenAIRequest(string model, List<Message> messages)
        {
            Model = model;
            Messages = messages;
        }
    }

}

