using ChatGPTCLI;

class Program
{
    const string SYSTEM_INSTRUCTIONS = "Your a handy AI CLI. Your answers are succint and clarifing";
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
