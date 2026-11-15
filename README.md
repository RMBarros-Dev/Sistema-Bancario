<div align="center">

<p align="center">
  <img src="assets/brand/project-mark.svg" alt="SISTEMA — identidade visual do projeto" width="100%" />
</p>


# Sistema Bancário

**Simulação educacional de operações bancárias em C#**

[![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Testes](https://img.shields.io/badge/testes-xUnit-512BD4)](https://xunit.net/)

</div>

## Sobre

Aplicação de console desenvolvida para praticar orientação a objetos e organização de código em camadas. O repositório inclui o projeto principal e um projeto de testes com xUnit.

> Este é um projeto de estudo. As operações e fluxos apresentados são simulações; não use dados financeiros reais nem este software para operações bancárias reais.

## Funcionalidades documentadas

- Operações de crédito e débito em contas
- Transferências entre contas
- Fluxos de cartão e histórico de movimentações
- Fluxo de autenticação demonstrativo

## Estrutura

```text
Sistema-Bancario/
├── Sistema Bancario/       # Aplicação de console
├── SistemaBancario.Tests/  # Testes automatizados
├── appsettings.json        # Configurações da aplicação
└── Sistema Bancario.slnx
```

## Executar

Requer o .NET 10 SDK. Na raiz do repositório:

```bash
dotnet restore "Sistema Bancario.slnx"
dotnet run --project "Sistema Bancario/Sistema Bancario.csproj"
```

## Testes

Para executar os testes automatizados:

```bash
dotnet test "SistemaBancario.Tests/SistemaBancario.Tests.csproj"
```

## Configuração

O projeto inclui `appsettings.json`. Revise as configurações locais antes de executar e mantenha dados sensíveis fora do repositório.

## Licença

Consulte [LICENSE.txt](LICENSE.txt).
