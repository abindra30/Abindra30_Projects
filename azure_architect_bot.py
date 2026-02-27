"""
Azure Architect Assistant
A CLI chatbot powered by Azure OpenAI Service that provides technical guidance
on Azure infrastructure, AI apps, applications, data, and security — based
strictly on official Microsoft documentation.
"""

import os
import sys
from openai import AzureOpenAI
from dotenv import load_dotenv

load_dotenv()

SYSTEM_PROMPT = """You are an Azure Architect with deep expertise in:
- Azure infrastructure (compute, networking, storage, hybrid)
- Azure AI and Cognitive Services applications
- Azure application development (App Service, AKS, Functions, API Management)
- Azure data services (Synapse Analytics, Azure SQL, Cosmos DB, Data Factory)
- Azure security (Microsoft Defender for Cloud, Azure AD/Entra ID, Key Vault, RBAC)

Rules you must follow without exception:
1. Only provide answers that are grounded in official Microsoft documentation,
   specifically Microsoft Learn (learn.microsoft.com) and the Azure documentation
   (docs.microsoft.com / learn.microsoft.com/azure). If a topic is not covered
   by official Microsoft sources, say so explicitly.
2. Do not speculate, embellish, or provide opinions beyond what the official
   documentation states.
3. When referencing a specific feature, service, or behavior, cite the
   relevant Microsoft Learn or Azure documentation area (e.g.
   "Per the Azure Virtual Network documentation on Microsoft Learn…").
4. If a question falls outside Azure or Microsoft technology, politely decline
   and redirect the user to ask an Azure-related question.
5. Be concise and technical. Avoid filler language."""


def create_client() -> tuple[AzureOpenAI, str]:
    """Create and return an AzureOpenAI client and deployment name from env vars."""
    endpoint = os.environ.get("AZURE_OPENAI_ENDPOINT")
    api_key = os.environ.get("AZURE_OPENAI_API_KEY")
    api_version = os.environ.get("AZURE_OPENAI_API_VERSION", "2024-02-01")
    deployment = os.environ.get("AZURE_OPENAI_DEPLOYMENT")

    if not endpoint or not api_key:
        print(
            "Error: AZURE_OPENAI_ENDPOINT and AZURE_OPENAI_API_KEY must be set.\n"
            "Copy .env.example to .env and fill in your values.",
            file=sys.stderr,
        )
        sys.exit(1)

    if not deployment:
        print(
            "Error: AZURE_OPENAI_DEPLOYMENT must be set.",
            file=sys.stderr,
        )
        sys.exit(1)

    client = AzureOpenAI(
        azure_endpoint=endpoint,
        api_key=api_key,
        api_version=api_version,
    )
    return client, deployment


def chat(client: AzureOpenAI, deployment: str, history: list[dict[str, str]], user_message: str) -> str:
    """Send a user message and return the assistant's response."""
    history.append({"role": "user", "content": user_message})

    try:
        response = client.chat.completions.create(
            model=deployment,
            messages=[{"role": "system", "content": SYSTEM_PROMPT}] + history,
            temperature=0,
        )
    except Exception as exc:
        history.pop()
        raise RuntimeError(f"Azure OpenAI request failed: {exc}") from exc

    assistant_message = response.choices[0].message.content
    history.append({"role": "assistant", "content": assistant_message})
    return assistant_message


def main() -> None:
    """Run the interactive Azure Architect assistant CLI."""
    print("Azure Architect Assistant")
    print("Powered by Azure OpenAI Service")
    print("Guidance is based on official Microsoft documentation.")
    print("Type 'exit' or 'quit' to end the session.\n")

    client, deployment = create_client()
    history: list[dict[str, str]] = []

    while True:
        try:
            user_input = input("You: ").strip()
        except (EOFError, KeyboardInterrupt):
            print("\nGoodbye.")
            break

        if not user_input:
            continue

        if user_input.lower() in {"exit", "quit"}:
            print("Goodbye.")
            break

        try:
            response = chat(client, deployment, history, user_input)
        except RuntimeError as exc:
            print(f"\nError: {exc}\n", file=sys.stderr)
            continue

        print(f"\nAssistant: {response}\n")


if __name__ == "__main__":
    main()
