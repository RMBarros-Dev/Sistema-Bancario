# Sistema Bancário

<p align="center">
  <img src="assets/brand/banner.svg" alt="Sistema Bancário — simulação educacional em C#" width="100%" />
</p>
<p align="center"><img src="assets/brand/logo.svg" alt="Sistema Bancário logo" width="76"/></p>

<p align="center">
  <strong>Simulação educacional de operações bancárias em C#.</strong><br/>
  Projeto de console para praticar orientação a objetos, serviços, repositórios e testes.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-.NET%2010-512BD4?logo=dotnet&logoColor=white" alt="C# .NET 10"/>
  <img src="https://img.shields.io/badge/Tests-xUnit-512BD4?logo=dotnet&logoColor=white" alt="xUnit"/>
  <img src="https://img.shields.io/badge/CI-GitHub_Actions-2088FF?logo=githubactions&logoColor=white" alt="GitHub Actions"/>
</p>

---

## Visão geral

Aplicação de console organizada em modelos, serviços, interfaces de repositório e camada de interação com o usuário. O repositório também contém um projeto de testes automatizados com xUnit.

O objetivo é demonstrar conceitos de domínio e separação de responsabilidades em C#/.NET, não oferecer um produto bancário real.

## Funcionalidades documentadas

- Operações de crédito e débito.
- Transferências entre contas.
- Modelos de conta corrente e conta poupança.
- Fluxos demonstrativos relacionados a cartões.
- Histórico e persistência local por repositório de arquivos.
- Implementação alternativa de repositório em memória.
- Recursos de texto para localização, incluindo português do Brasil.
- Testes automatizados de contas e cartões.

## Arquitetura

```mermaid
flowchart TD
    UI[ConsoleUI] --> Program[Program]
    Program --> AccountService[AccountService]
    Program --> CardService[CardService]
    AccountService --> Interface[IAccountRepository]
    Interface --> FileRepo[FileAccountRepository]
    Interface --> MemoryRepo[InMemoryAccountRepository]
    AccountService --> Models[Domain Models]
    CardService --> Models
    Tests[xUnit Tests] --> AccountService
    Tests --> CardService
```

## Tecnologias e conceitos

| Área | Implementação |
| --- | --- |
| Linguagem | C# |
| Plataforma | .NET 10 |
| Testes | xUnit |
| Domínio | Contas, cartões e usuários |
| Organização | Models, Services, UI e interfaces |
| Persistência demonstrativa | Repositório em arquivo e repositório em memória |
| Localização | Arquivos de recursos `.resx` |

## Requisitos

- .NET 10 SDK.
- Terminal compatível com a execução de aplicações .NET.

## Executar

Na raiz do repositório:

```bash
dotnet restore "Sistema Bancario.slnx"
dotnet run --project "Sistema Bancario/Sistema Bancario.csproj"
```

## Executar os testes

```bash
dotnet test "SistemaBancario.Tests/SistemaBancario.Tests.csproj"
```

Os testes estão separados da aplicação principal no diretório `SistemaBancario.Tests/`.

## Estrutura do repositório

```text
Sistema-Bancario/
├── .github/
│   └── workflows/
│       └── dotnet.yml
├── Sistema Bancario/
│   ├── Models/
│   ├── Resources/
│   ├── Services/
│   ├── UI/
│   ├── EnvConfig.cs
│   └── Program.cs
├── SistemaBancario.Tests/
├── assets/
│   └── brand/
│       ├── banner.svg
│       ├── logo.svg
│       └── project-mark.svg
├── appsettings.json
├── build-release.ps1
└── Sistema Bancario.slnx
```

## Segurança e limites de uso

Este é um projeto educacional. As operações e fluxos são simulações. Não utilize dados bancários reais, credenciais reais ou este software para movimentações financeiras. Antes de qualquer aplicação real seriam necessários, entre outros pontos, controles de segurança, auditoria, criptografia, conformidade regulatória, testes adicionais e revisão independente.

## Identidade visual

Paleta, símbolo e banner estão em [assets/brand](assets/brand/). Consulte [docs/brand/README.md](docs/brand/README.md).

## Licença

Consulte [LICENSE.txt](LICENSE.txt).
