# Getting Started — Azure AI Foundry Agent Console

This guide walks you through setting up and completing the **FoundryAgentConsole** learning project from scratch. It assumes you are new to .NET and Azure AI.

---

## What Is This Project?

This is a **.NET 10 console app** that acts as a chat interface for an AI agent hosted on **Azure AI Foundry**. The agent is built using **Semantic Kernel** — Microsoft's open-source SDK for creating AI-powered applications.

**Key concepts you will learn:**
- How to connect a .NET app to Azure AI Foundry
- How to build an AI agent with Semantic Kernel
- How to give an agent custom tools (called *Plugins*)
- How to have a multi-turn conversation with the agent

---

## Prerequisites

Before you can run the app, you need:

1. **A free Azure account** — sign up at <https://azure.microsoft.com/free>
2. **.NET 10 SDK** — download from <https://dot.net> (this project already uses it)
3. **Visual Studio 2022** or **VS Code** with the C# extension
4. **Azure AI Foundry access** — see the next section

---

## Step 1 — Create an Azure AI Foundry Project

Azure AI Foundry is Microsoft's platform for building AI applications.

1. Go to <https://ai.azure.com> and sign in with your Azure account.
2. Click **+ New project** and give it a name (e.g. `MyAgentProject`).
3. Create a new **Hub** when prompted (this is a container for projects).
4. Wait for the project to be created (about 1–2 minutes).

---

## Step 2 — Deploy a Model

Your agent needs a language model to think with. You will deploy one inside your project.

1. In your Foundry project, click **Model catalog** in the left menu.
2. Search for **gpt-4o** (recommended) or **gpt-35-turbo**.
3. Click the model, then click **Deploy**.
4. Keep the default settings and click **Deploy** again.
5. **Copy the deployment name** (e.g. `gpt-4o`) — you will need it in Step 4.

---

## Step 3 — Find Your Connection String

1. In your Foundry project, click **Settings** (gear icon) in the left menu.
2. Under **Project details**, find and copy the **Connection string**.
   It looks like: `eastus.api.azureml.ms;00000000-xxxx-xxxx-xxxx-000000000000;my-resource-group;my-project`

---

## Step 4 — Configure the App

Open `appsettings.json` in the `FoundryAgentConsole` folder and fill in your values:

```jsonc
{
  "FoundrySettings": {
    "ConnectionString": "eastus.api.azureml.ms;...",  // ← paste from Step 3
    "ModelDeploymentName": "gpt-4o",                  // ← paste from Step 2
    "AgentInstructions": "You are a helpful assistant."
  }
}
```

> **Security tip:** Instead of editing `appsettings.json` directly, create a file called
> `appsettings.Development.json` in the same folder and put your real values there.
> That file is already listed in `.gitignore` so it will never be committed to Git.

---

## Step 5 — Implement Program.cs

Open `Program.cs` and follow the numbered **TODO** comments:

| TODO | What to do |
|------|-----------|
| **Step 1** | Load configuration using `ConfigurationBuilder` and bind it to `FoundrySettings`. |
| **Step 2** | Build a `Kernel` using `Kernel.CreateBuilder()`, add the Azure OpenAI connector, and register `SamplePlugin`. |
| **Step 3** | Instantiate `AgentService`, pass it your settings, and call `InitializeAsync()`. |
| **Step 4** | Write a `while` loop that reads user input, sends it to `ChatAsync()`, and prints the reply. |

Uncomment the blocks marked with `// TODO` and remove the stub `Console.WriteLine` at the bottom.

---

## Step 6 — Implement AgentService.cs

Open `Services/AgentService.cs` and follow the lettered **TODO** comments:

| TODO | What to do |
|------|-----------|
| **Step A** | Build the `Kernel` and add `AddAzureOpenAIChatCompletion(...)`. Fill in your endpoint and API key. |
| **Step B** | Create an `AgentsClient` using your `ConnectionString` and `DefaultAzureCredential`. |
| **Step C** | Call `CreateAgentAsync(...)` to create the agent in Foundry, then wrap it in `AzureAIAgent`. |
| **Step D** | Create a conversation thread with `CreateThreadAsync()`. |

Also implement `ChatAsync` by iterating over `_agent.InvokeAsync(...)`.

> **Tip:** `DefaultAzureCredential` automatically uses your Azure CLI login.
> Run `az login` in your terminal before starting the app.

---

## Step 7 — Customise SamplePlugin.cs (Optional)

Open `Plugins/SamplePlugin.cs` and replace the example functions with actions that are useful to **your** project — for example:

- Look up live weather data from a public API
- Search a list of products in a local JSON file
- Do a unit conversion calculation

Each method needs the `[KernelFunction]` and `[Description]` attributes so Semantic Kernel can expose it to the agent.

---

## Step 8 — Run the App

```bash
cd FoundryAgentConsole
dotnet run
```

You should see:

```
=== Azure AI Foundry Agent Console ===
Agent ready! Type your message (or 'exit' to quit):

You: Hello!
Agent: Hi there! How can I help you today?
```

---

## Useful Resources

| Resource | URL |
|----------|-----|
| Azure AI Foundry docs | <https://learn.microsoft.com/azure/ai-studio> |
| Semantic Kernel docs | <https://learn.microsoft.com/semantic-kernel/overview> |
| Semantic Kernel GitHub | <https://github.com/microsoft/semantic-kernel> |
| Azure AI Projects SDK | <https://learn.microsoft.com/azure/ai-studio/how-to/develop/sdk-overview> |
| .NET 10 what's new | <https://learn.microsoft.com/dotnet/core/whats-new/dotnet-10/overview> |

---

## Project Structure

```
FoundryAgentConsole/
├── Program.cs                  ← Entry point: load config, build agent, chat loop
├── FoundryAgentConsole.csproj  ← Project file with NuGet package references
├── appsettings.json            ← Configuration template (safe to commit)
├── appsettings.Development.json ← Your real secrets (git-ignored, create this yourself)
├── Config/
│   └── FoundrySettings.cs      ← Typed configuration model
├── Services/
│   └── AgentService.cs         ← Creates and manages the Foundry agent
└── Plugins/
    └── SamplePlugin.cs         ← Example Semantic Kernel plugin (custom tools)
```

---

## NuGet Packages Used

| Package | Purpose |
|---------|---------|
| `Microsoft.SemanticKernel` | Core Semantic Kernel SDK |
| `Microsoft.SemanticKernel.Agents.Core` | Agent abstractions |
| `Microsoft.SemanticKernel.Agents.AzureAI` | Azure AI Foundry agent integration |
| `Azure.AI.Projects` | Azure AI Foundry project SDK |
| `Azure.Identity` | Azure authentication (`DefaultAzureCredential`) |
| `Microsoft.Extensions.Configuration.Json` | Load settings from `appsettings.json` |

---

## Troubleshooting

**"Authentication failed"**
→ Run `az login` in your terminal and make sure you have access to the Azure subscription.

**"Model deployment not found"**
→ Double-check the `ModelDeploymentName` in `appsettings.json` matches exactly what you see in the Foundry portal under **Deployments**.

**"Could not find appsettings.json"**
→ Make sure you run `dotnet run` from inside the `FoundryAgentConsole` folder.

**Build errors about nullable types**
→ Make sure all `TODO` properties are assigned a value before calling methods on them.
