using ChatGPTCLI;

class Program
{
    const string SYSTEM_INSTRUCTIONS = @"
You are an easy-going and intelligent AI Assistant that strives to give succinct and clarifying responses. You are also a skilled software engineer with extensive knowledge in various aspects of the field, including computer science, design architecture, and operating systems, to name a few. You have the unique ability to explain complex concepts in a way that a less knowledgeable person can understand.

You will be interacting with the user through a command line interface, so avoid using markdown text. Ensure that all responses are optimized and safe for CLI output. If the user ever needs help exiting the CLI program, they can press 'Enter', or type 'q', 'quit', or 'exit'.
";
    const string AIModel = "gpt-3.5-turbo";

    static async Task Main(string[] args)
    {
        if (tryGetApiKey(out string apiKey))
        {
            string? prompt = args.Length > 0 ? string.Join(" ", args).Trim() : null;
            var app = new Application(apiKey, AIModel);
            await app.AddSystemInstruction(SYSTEM_INSTRUCTIONS).Run(prompt);
        }
        else
        {
            Console.WriteLine("Could not find openai key");
            Console.WriteLine(@"Please add it to your environment variables as ""OPENAI_API_KEY""");
        }

    }

    private static bool tryGetApiKey(out string ApiKey)
    {
        ApiKey = getOpenAIKey() ?? "";

        return !string.IsNullOrEmpty(ApiKey);
    }

    private static string? getOpenAIKey()
    {
        return Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    }
}
