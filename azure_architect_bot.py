"""
Azure Architect Assistant
A CLI chatbot powered by Claude claude-opus-4-6 (Anthropic) that provides technical guidance
on Azure infrastructure, AI apps, applications, data, and security — based
strictly on official Microsoft documentation.
"""

import os
import sys
import anthropic
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


MODEL = "claude-opus-4-6"


def create_client() -> anthropic.Anthropic:
    """Create and return an Anthropic client using environment variables."""
    api_key = os.environ.get("ANTHROPIC_API_KEY")

    if not api_key:
        print(
            "Error: ANTHROPIC_API_KEY must be set.\n"
            "Copy .env.example to .env and fill in your values.",
            file=sys.stderr,
        )
        sys.exit(1)

    return anthropic.Anthropic(api_key=api_key)


def chat(client: anthropic.Anthropic, history: list[dict[str, str]], user_message: str) -> str:
    """Send a user message and return the assistant's response."""
    history.append({"role": "user", "content": user_message})

    try:
        response = client.messages.create(
            model=MODEL,
            max_tokens=4096,
            system=SYSTEM_PROMPT,
            messages=history,
        )
    except Exception as exc:
        history.pop()
        raise RuntimeError(f"Anthropic API request failed: {exc}") from exc

    assistant_message = response.content[0].text
    history.append({"role": "assistant", "content": assistant_message})
    return assistant_message


def main() -> None:
    """Run the interactive Azure Architect assistant CLI."""
    print("Azure Architect Assistant")
    print(f"Powered by {MODEL}")
    print("Guidance is based on official Microsoft documentation.")
    print("Type 'exit' or 'quit' to end the session.\n")

    client = create_client()
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
            response = chat(client, history, user_input)
        except RuntimeError as exc:
            print(f"\nError: {exc}\n", file=sys.stderr)
            continue

        print(f"\nAssistant: {response}\n")


if __name__ == "__main__":
    main()
