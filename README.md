# Sistema Bancário

Projeto de exemplo em .NET 10 que simula operações bancárias básicas: contas corrente e poupança, transferências, cartão (débito/crédito) e histórico.

Como executar:

- Restaurar e executar:
  dotnet restore
  dotnet run --project "Sistema Bancario/Sistema Bancario.csproj"

- Executar testes:
  dotnet test

Configuração:
- Valores de configuração estão em `appsettings.json` (DefaultCardLimit etc.).

Estrutura:
- Sistema Bancario/: projeto principal
  - Models/: classes de domínio (Conta, Cartão...)
  - Services/: serviços e repositório em memória
  - UI/: ConsoleUI
- SistemaBancario.Tests/: testes xUnit

Observações:
- Implementação simples para fins de demonstração e aprendizado. Não usar em produção sem validações, persistência segura e tratamento de concorrência apropriado.
