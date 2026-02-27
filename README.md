# Azure Architect Assistant

A CLI chatbot powered by **Azure OpenAI Service** that acts as an Azure
Architect, providing technical guidance on:

- Azure infrastructure (compute, networking, storage, hybrid)
- Azure AI and Cognitive Services applications
- Azure application development (App Service, AKS, Functions, API Management)
- Azure data services (Synapse Analytics, Azure SQL, Cosmos DB, Data Factory)
- Azure security (Microsoft Defender for Cloud, Microsoft Entra ID, Key Vault, RBAC)

All answers are grounded strictly in **official Microsoft documentation**
([Microsoft Learn](https://learn.microsoft.com/azure)). The assistant will not
speculate or embellish beyond what the official docs state.

---

## Prerequisites

| Requirement | Notes |
|---|---|
| Python 3.9+ | [Download](https://www.python.org/downloads/) |
| Azure subscription | [Free account](https://azure.microsoft.com/free/) |
| Azure OpenAI resource | [Create a resource](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource) |
| Model deployment | Deploy a chat model (e.g. `gpt-4o`) in [Azure OpenAI Studio](https://oai.azure.com/) |

---

## Setup

### 1. Clone the repository

```bash
git clone https://github.com/abindra30/Abindra30_Projects.git
cd Abindra30_Projects
```

### 2. Install dependencies

```bash
pip install -r requirements.txt
```

### 3. Configure environment variables

Copy `.env.example` to `.env` and fill in your Azure OpenAI values:

```bash
cp .env.example .env
```

Edit `.env`:

```env
AZURE_OPENAI_ENDPOINT=https://<your-resource-name>.openai.azure.com/
AZURE_OPENAI_API_KEY=<your-api-key>
AZURE_OPENAI_DEPLOYMENT=<your-deployment-name>
AZURE_OPENAI_API_VERSION=2024-02-01
```

| Variable | Where to find it |
|---|---|
| `AZURE_OPENAI_ENDPOINT` | Azure Portal → your OpenAI resource → Keys and Endpoint |
| `AZURE_OPENAI_API_KEY` | Azure Portal → your OpenAI resource → Keys and Endpoint |
| `AZURE_OPENAI_DEPLOYMENT` | Azure OpenAI Studio → Deployments |
| `AZURE_OPENAI_API_VERSION` | [Supported API versions](https://learn.microsoft.com/azure/ai-services/openai/reference#chat-completions) |

---

## Usage

```bash
python azure_architect_bot.py
```

Example session:

```
Azure Architect Assistant
Powered by Azure OpenAI Service
Guidance is based on official Microsoft documentation.
Type 'exit' or 'quit' to end the session.

You: What is the recommended way to secure secrets in Azure?

Assistant: Per the Azure Key Vault documentation on Microsoft Learn,
the recommended approach is to use Azure Key Vault to store secrets,
keys, and certificates. Applications should authenticate to Key Vault
using managed identities (system-assigned or user-assigned) rather
than storing credentials in code or configuration files. Reference:
https://learn.microsoft.com/azure/key-vault/general/overview

You: exit
Goodbye.
```

---

## Security

- Never commit `.env` to source control. It is listed in `.gitignore`.
- For production workloads, use [Microsoft Entra ID managed identities](https://learn.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview) instead of API keys.

## References

- [Azure OpenAI Service documentation](https://learn.microsoft.com/azure/ai-services/openai/)
- [Azure OpenAI Python SDK](https://learn.microsoft.com/azure/ai-services/openai/quickstart?tabs=command-line&pivots=programming-language-python)
- [Microsoft Learn – Azure documentation](https://learn.microsoft.com/azure/)
