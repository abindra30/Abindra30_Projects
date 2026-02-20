// ============================================================
// FoundryAgentConsole - Learning Project
// Azure AI Foundry + Semantic Kernel Agentic App (.NET 10)
// ============================================================
//
// TODO (Step 1): Load your configuration from appsettings.json
//   - Use Microsoft.Extensions.Configuration to read appsettings.json
//   - Bind the values to a FoundrySettings object
//   - Hint: See Config/FoundrySettings.cs
//
// TODO (Step 2): Build the Semantic Kernel
//   - Create a Kernel using Kernel.CreateBuilder()
//   - Add Azure OpenAI chat completion (your Foundry-deployed model)
//   - Register your plugins (see Plugins/SamplePlugin.cs)
//
// TODO (Step 3): Create and configure an AzureAI Agent
//   - Use AgentService to create your agent
//   - Give it a name, instructions, and attach your plugins
//   - Hint: See Services/AgentService.cs
//
// TODO (Step 4): Run a conversation loop
//   - Prompt the user for input
//   - Pass input to the agent and display its response
//   - Keep looping until the user types "exit"

using Microsoft.Extensions.Configuration;
using FoundryAgentConsole.Config;
using FoundryAgentConsole.Services;

// TODO: Replace the lines below with real implementation following the steps above.

Console.WriteLine("=== Azure AI Foundry Agent Console ===");
Console.WriteLine("(Stub - complete the TODOs in Program.cs to bring this to life)\n");

// TODO (Step 1): Uncomment and complete the configuration loading below
// var config = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json", optional: false)
//     .AddJsonFile("appsettings.Development.json", optional: true)
//     .Build();
// var settings = config.GetSection("FoundrySettings").Get<FoundrySettings>()
//     ?? throw new InvalidOperationException("FoundrySettings section missing from appsettings.json");

// TODO (Step 2 & 3): Uncomment and complete the agent setup below
// var agentService = new AgentService(settings);
// await agentService.InitializeAsync();

// TODO (Step 4): Uncomment and complete the conversation loop below
// Console.WriteLine("Agent ready! Type your message (or 'exit' to quit):");
// while (true)
// {
//     Console.Write("\nYou: ");
//     var input = Console.ReadLine();
//     if (string.IsNullOrWhiteSpace(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//         break;
//
//     var response = await agentService.ChatAsync(input);
//     Console.WriteLine($"\nAgent: {response}");
// }

Console.WriteLine("Done. Go implement the TODOs above!");

