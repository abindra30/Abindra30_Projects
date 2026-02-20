namespace FoundryAgentConsole.Config;

/// <summary>
/// Holds the Azure AI Foundry connection settings read from appsettings.json.
/// </summary>
public class FoundrySettings
{
    // TODO: Add any extra properties you want to configure (e.g. MaxTokens, Temperature).

    /// <summary>
    /// The Azure AI Foundry project connection string.
    /// Format: "endpoint;subscriptionId;resourceGroup;projectName"
    /// Found in your Foundry project under Settings > Project details.
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// The name of the model deployment in your Azure AI Foundry project.
    /// Example: "gpt-4o" or "gpt-35-turbo".
    /// </summary>
    public string ModelDeploymentName { get; set; } = string.Empty;

    /// <summary>
    /// A short description of what the agent should do.
    /// This becomes the agent's system prompt / instructions.
    /// </summary>
    public string AgentInstructions { get; set; } = "You are a helpful assistant.";
}
