using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace FoundryAgentConsole.Plugins;

/// <summary>
/// A Semantic Kernel Plugin (skill) that the agent can call as a tool.
///
/// Plugins let the agent take real-world actions (e.g., look something up,
/// run a calculation, call an external API) beyond just generating text.
///
/// Each public method decorated with [KernelFunction] becomes a callable tool.
/// </summary>
public class SamplePlugin
{
    // TODO: Replace this example function with something useful to YOUR project.
    //       Ideas: call a REST API, query a database, do a math calculation, etc.

    /// <summary>
    /// Returns a friendly greeting. The agent can call this tool when asked to greet someone.
    /// </summary>
    /// <param name="name">The name of the person to greet.</param>
    /// <returns>A greeting string.</returns>
    [KernelFunction("greet")]
    [Description("Returns a friendly greeting for the given name.")]
    public string Greet(
        [Description("The name of the person to greet.")] string name)
    {
        // TODO: Replace with your own logic.
        return $"Hello, {name}! Welcome to Azure AI Foundry.";
    }

    /// <summary>
    /// Returns the current UTC date and time as a string.
    /// Useful so the agent always knows what time it is.
    /// </summary>
    [KernelFunction("get_current_time")]
    [Description("Returns the current UTC date and time.")]
    public string GetCurrentTime()
    {
        // TODO: You could localise this, or pull from an external time service.
        return DateTime.UtcNow.ToString("f");
    }
}
