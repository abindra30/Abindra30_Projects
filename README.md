# Azure Architect Assistant

A CLI chatbot powered by **Claude claude-opus-4-6** (Anthropic) that acts as an Azure
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
| Anthropic API key | [Get an API key](https://console.anthropic.com/) |

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

Copy `.env.example` to `.env` and fill in your Anthropic API key:

```bash
cp .env.example .env
```

Edit `.env`:

```env
ANTHROPIC_API_KEY=<your-anthropic-api-key>
```

| Variable | Where to find it |
|---|---|
| `ANTHROPIC_API_KEY` | [Anthropic Console](https://console.anthropic.com/) → API Keys |

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
- Rotate your `ANTHROPIC_API_KEY` regularly and restrict it to only the necessary permissions in the [Anthropic Console](https://console.anthropic.com/).

## References

- [Anthropic API documentation](https://docs.anthropic.com/)
- [Anthropic Python SDK](https://github.com/anthropic/anthropic-sdk-python)
- [Microsoft Learn – Azure documentation](https://learn.microsoft.com/azure/)
