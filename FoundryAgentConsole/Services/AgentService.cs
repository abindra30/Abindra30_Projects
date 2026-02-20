using Azure.Identity;
using Azure.AI.Projects;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents.AzureAI;
using FoundryAgentConsole.Config;
using FoundryAgentConsole.Plugins;

namespace FoundryAgentConsole.Services;

/// <summary>
/// Manages creating and talking to an Azure AI Foundry agent
/// using Semantic Kernel as the agentic framework.
/// </summary>
public class AgentService
{
    private readonly FoundrySettings _settings;

    // TODO: Declare private fields for the Kernel, AgentsClient, and AzureAIAgent below.
    // private Kernel _kernel = null!;
    // private AgentsClient _agentsClient = null!;
    // private AzureAIAgent _agent = null!;
    // private AgentThread? _thread;

    public AgentService(FoundrySettings settings)
    {
        _settings = settings;
    }

    /// <summary>
    /// Creates the Semantic Kernel, registers plugins, connects to Azure AI Foundry,
    /// and creates an agent ready for conversation.
    /// </summary>
    public async Task InitializeAsync()
    {
        // TODO (Step A): Build the Semantic Kernel and add the AzureAI chat connector.
        //
        // var builder = Kernel.CreateBuilder();
        //
        // builder.AddAzureOpenAIChatCompletion(
        //     deploymentName: _settings.ModelDeploymentName,
        //     endpoint:        "<your-azure-openai-endpoint>",    // from appsettings or Foundry portal
        //     apiKey:          "<your-azure-openai-api-key>");    // from appsettings or Foundry portal
        //
        // builder.Plugins.AddFromType<SamplePlugin>();
        // _kernel = builder.Build();

        // TODO (Step B): Create an AgentsClient pointing at your Azure AI Foundry project.
        //
        // _agentsClient = new AgentsClient(
        //     _settings.ConnectionString,
        //     new DefaultAzureCredential());

        // TODO (Step C): Create (or reuse) the agent definition in your Foundry project.
        //
        // var agentDef = await _agentsClient.CreateAgentAsync(
        //     model:        _settings.ModelDeploymentName,
        //     name:         "MyFoundryAgent",
        //     instructions: _settings.AgentInstructions);
        //
        // _agent = new AzureAIAgent(agentDef, _agentsClient, _kernel);

        // TODO (Step D): Create a new conversation thread.
        //
        // _thread = await _agent.Client.CreateThreadAsync();

        await Task.CompletedTask; // Remove this line once you implement the above.
    }

    /// <summary>
    /// Sends a user message to the agent and returns its reply.
    /// </summary>
    /// <param name="userMessage">The message typed by the user.</param>
    /// <returns>The agent's text response.</returns>
    public async Task<string> ChatAsync(string userMessage)
    {
        // TODO: Send userMessage to the agent and collect its response.
        //
        // Collect all response chunks into a single string:
        // var responseText = new System.Text.StringBuilder();
        // await foreach (var content in _agent.InvokeAsync(_thread!, new ChatMessageContent(AuthorRole.User, userMessage)))
        // {
        //     responseText.Append(content.Content);
        // }
        // return responseText.ToString();

        // Stub: return a placeholder until you implement the above.
        await Task.CompletedTask;
        return $"(Stub) Echo: {userMessage}";
    }
}
