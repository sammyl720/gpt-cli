using System;
using System.Text.Json.Serialization;

namespace ChatGPTCLI
{
	public class GptMessage
	{
		public string role { get; init; } = "system";

		public string content { get; init; } = string.Empty;
	}

}

