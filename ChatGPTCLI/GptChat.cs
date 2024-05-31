using System;
namespace ChatGPTCLI
{
	public class GptChat
	{
		public List<GptMessage> messages;

        public string model;

        public GptChat(string model) : this( new List<GptMessage>(), model)
        {
        }

        public GptChat(List<GptMessage> messages, string model)
        {
            this.messages = messages;
            this.model = model;
        }
	}
}

