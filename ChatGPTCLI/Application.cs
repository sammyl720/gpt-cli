using System;
namespace ChatGPTCLI
{
	public class Application
	{
		private List<Message> messages = new List<Message>();
		private OpenAIClient client;
		private string Model { get; init; }
        readonly string[] exitCommands = new string[] { "exit", "q", "quit", "leave" };


        public Application(string apiKey, string model)
		{
			client = new OpenAIClient(apiKey);
			Model = model;
		}

		private bool tryGetUserPrompt(out string prompt, bool promptUser = false)
		{

			if (promptUser)
			{

				Message gptMessage = new Message(Role.Assistant, "How can I assist you today?");
				printAIMessage(gptMessage.Content);
				messages.Add(gptMessage);
			}

			Console.Write("User: ");
            prompt = Console.ReadLine() ?? "";
			return isPromptMessage(prompt);
        }

		public Application AddSystemInstruction(string instruction)
		{
			this.messages.Add(new Message(Role.System, instruction));
			return this;
		}

		public async Task Run(string? prompt = null)
		{
			try
			{

				if (!isPromptMessage(prompt) && !tryGetUserPrompt(out prompt, true))
				{
					Console.WriteLine("Bye bye!");
					return;
				}

				while(true)
				{

                    addUserPrompt(prompt!);
                    var request = getRequest();
                    var response = await client.GetChatCompletionAsync(request);

                    if (response is null)
                    {
                        throw new Exception("Got not API response");
                    }

                    this.messages.Add(response);
					printAIMessage(response.Content);

					if (!tryGetUserPrompt(out prompt))
					{
						Console.WriteLine("Bye! bye");
						break;
					}
                }
            }
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR: {ex}");
				endProgram(1);
			}
		}

        private void printAIMessage(string content)
        {
			Console.WriteLine("");
			Console.WriteLine($"ChatGPT: {content}");
			Console.WriteLine("");
        }

        public void addUserPrompt(string prompt)
		{
			messages.Add(new Message(Role.User, prompt));
		}

		private bool isPromptMessage(string? prompt)
		{
			return !string.IsNullOrEmpty(prompt) && !isExitCommand(prompt);
        }

		private void endProgram(int status = 0)
		{
            Console.WriteLine("Bye bye!");
            Environment.Exit(status);
        }

		private OpenAIRequest getRequest()
		{
			return new OpenAIRequest(Model, messages);
		}

		private bool isExitCommand(string command)
		{
			return exitCommands.Any(c => c == command.ToLower().Trim());
		}
	}
}

