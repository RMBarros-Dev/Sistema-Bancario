<p align="right"><strong>Idioma:</strong> <a href="README.md">Português (Brasil)</a> · <a href="README.en.md">English</a></p>

<p align="center"><img src="assets/brand/banner.svg" alt="Sistema Bancário — simulação educacional em C#" width="100%" /></p>
<p align="center"><img src="assets/brand/logo.svg" alt="Logotipo do Sistema Bancário" width="76" /></p>
<h1 align="center">Sistema Bancário</h1>
<p align="center"><strong>Simulação educacional de operações bancárias em C# para terminal.</strong></p>
<p align="center">
  <img src="https://img.shields.io/badge/C%23-.NET%2010-512BD4?logo=dotnet&logoColor=white" alt="C# .NET 10" />
  <img src="https://img.shields.io/badge/Tests-xUnit-512BD4?logo=dotnet&logoColor=white" alt="xUnit" />
  <a href="https://github.com/RMBarros-Dev/Sistema-Bancario/actions/workflows/dotnet.yml"><img src="https://github.com/RMBarros-Dev/Sistema-Bancario/actions/workflows/dotnet.yml/badge.svg?branch=master" alt="Status da CI" /></a>
  <a href="https://github.com/RMBarros-Dev/Sistema-Bancario/actions/workflows/codeql.yml"><img src="https://github.com/RMBarros-Dev/Sistema-Bancario/actions/workflows/codeql.yml/badge.svg?branch=master" alt="Status do CodeQL" /></a>
</p>

## Índice

- [01 · Contexto e posicionamento](#01--contexto-e-posicionamento)
- [02 · Demonstração real e referências visuais](#02--demonstracao-real-e-referencias-visuais)
- [03 · Funcionalidades e estado de implementação](#03--funcionalidades-e-estado-de-implementacao)
- [04 · Arquitetura geral](#04--arquitetura-geral)
- [05 · Stack tecnológica](#05--stack-tecnologica)
- [06 · Estrutura de diretórios](#06--estrutura-de-diretorios)
- [07 · Pré-requisitos e instalação](#07--pre-requisitos-e-instalacao)
- [08 · Configuração de ambiente e dados](#08--configuracao-de-ambiente-e-dados)
- [09 · Guia de utilização](#09--guia-de-utilizacao)
- [10 · Testes e qualidade](#10--testes-e-qualidade)
- [11 · Internacionalização e localização](#11--internacionalizacao-e-localizacao)
- [12 · Deploy e infraestrutura](#12--deploy-e-infraestrutura)
- [13 · Segurança e limitações](#13--seguranca-e-limitacoes)
- [14 · Documentação complementar](#14--documentacao-complementar)
- [15 · Contribuição, licença e créditos](#15--contribuicao-licenca-e-creditos)

## 01 · Contexto e posicionamento



### Visão geral

Aplicação de console em C#/.NET organizada em modelos de domínio, serviços, interfaces de repositório e camada de interação com o usuário. O repositório também contém um projeto de testes automatizados com xUnit.

### Objetivo e escopo educacional

O projeto simula conceitos selecionados do domínio bancário para praticar orientação a objetos, regras de negócio, abstrações de persistência e testes automatizados. Não é um produto bancário nem um serviço financeiro real.

## 02 · Demonstração real e referências visuais

O README atual não identifica uma URL pública nem uma captura real da execução. Use a demonstração local ou as referências visuais indicadas nesta seção.

## 03 · Funcionalidades e estado de implementação

O estado apresentado nesta seção corresponde ao escopo descrito no README e no material referenciado pelo repositório. Não equivale, por si só, a uma homologação operacional ou a uma validação independente.

### Funcionalidades documentadas

- Operações de crédito e débito.
- Transferências entre contas.
- Modelos de conta corrente e conta poupança.
- Fluxos demonstrativos relacionados a cartões.
- Histórico e persistência local por repositório de arquivos.
- Implementação alternativa de repositório em memória.
- Recursos de texto para localização, incluindo português do Brasil.
- Testes automatizados de contas e cartões.

## 04 · Arquitetura geral



### Modelo de domínio

A aplicação representa conceitos de contas, cartões e usuários. Os serviços coordenam as operações de domínio, enquanto as abstrações de repositório isolam as opções de persistência. O modelo é educacional e não deve ser interpretado como uma especificação financeira completa.

### Arquitetura

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

## 05 · Stack tecnológica



### Tecnologias

| Área | Implementação |
|---|---|
| Linguagem | C# |
| Plataforma | .NET 10 |
| Testes | xUnit |
| Domínio | Contas, cartões e usuários |
| Organização | Models, Services, UI e interfaces |
| Persistência demonstrativa | Repositório em arquivo e repositório em memória |
| Localização | Arquivos de recursos `.resx` |

## 06 · Estrutura de diretórios



### Estrutura do repositório

```text
Sistema-Bancario/
├── .github/workflows/dotnet.yml
├── Sistema Bancario/
│   ├── Models/
│   ├── Resources/
│   ├── Services/
│   ├── UI/
│   ├── EnvConfig.cs
│   └── Program.cs
├── SistemaBancario.Tests/
├── assets/brand/
├── appsettings.json
├── build-release.ps1
└── Sistema Bancario.slnx
```

## 07 · Pré-requisitos e instalação



### Requisitos

- SDK do .NET 10.
- Terminal ou IDE compatível com aplicações .NET.
- Git para clonar o repositório.

### Restaurar e executar

Na raiz do repositório:

```bash
dotnet restore "Sistema Bancario.slnx"
dotnet run --project "Sistema Bancario/Sistema Bancario.csproj"
```

## 08 · Configuração de ambiente e dados

Esta seção reúne as informações documentadas sobre configuração e armazenamento. Variáveis sensíveis devem ser fornecidas pelo ambiente de execução, nunca commitadas.

### Precisão monetária

O domínio utiliza `decimal` para representar valores monetários, em vez de tipos de ponto flutuante binário. Cálculos com valores financeiros simulados devem preservar regras explícitas de arredondamento e validação. Essa decisão melhora a representação decimal, mas não torna a aplicação adequada para transações reais.

### Persistência

O repositório contém uma implementação de persistência em arquivo e uma alternativa em memória. A gravação em arquivo utiliza substituição atômica para reduzir o risco de deixar um JSON parcialmente escrito. Arquivos JSON inválidos geram erros explícitos, em vez de serem ignorados silenciosamente.

O armazenamento é local e educacional; não é uma solução financeira gerenciada, criptografada ou de alta disponibilidade.

## 09 · Guia de utilização

Consulte os comandos e comportamentos documentados neste README. Não são presumidos recursos adicionais além dos descritos no repositório.

## 10 · Testes e qualidade



### Executar os testes

```bash
dotnet test "SistemaBancario.Tests/SistemaBancario.Tests.csproj"
```

Os testes ficam separados da aplicação principal no diretório `SistemaBancario.Tests/`.

### Qualidade e testes

Os testes xUnit cobrem comportamentos selecionados de contas e cartões. Execute a suíte antes de depender de alterações. A cobertura e os resultados de CI devem ser avaliados a partir dos workflows atuais; eles não comprovam ausência de defeitos.

## 11 · Internacionalização e localização



### Recursos de localização

O projeto contém arquivos de recursos `.resx` para localização de textos, incluindo português do Brasil. A presença desses arquivos não comprova cobertura completa de tradução ou seleção de idioma em todos os fluxos.

## 12 · Deploy e infraestrutura

Deploy de serviço web não se aplica à aplicação de console descrita aqui. Não há ambiente hospedado ou processo de publicação documentado.

## 13 · Segurança e limitações



### Segurança e uso responsável

Este é um projeto educacional. Operações e fluxos são simulações. Não utilize dados bancários reais, credenciais reais ou este software para movimentar dinheiro. Um sistema financeiro real exigiria, entre outros controles, engenharia de segurança, auditabilidade, criptografia, conformidade regulatória, testes adicionais e revisão independente.

### Limitações conhecidas

A aplicação é uma simulação local, sem integração bancária, autorização regulatória, processamento de pagamentos, infraestrutura de produção ou controles suficientes para uso financeiro real. Não utilize dados pessoais ou financeiros verdadeiros.

## 14 · Documentação complementar



### Documentação e licença

- [Organização de arquivos](docs/project-structure.md).
- [Identidade visual](docs/brand/README.md).
- [Workflow .NET](.github/workflows/dotnet.yml).

Consulte [LICENSE.txt](LICENSE.txt) para os termos da licença.

## 15 · Contribuição, licença e créditos

Ao propor alterações, descreva o objetivo, os arquivos afetados e a validação realizada. Prefira mudanças pequenas e revisáveis; inclua testes quando alterar comportamento e nunca envie credenciais, tokens ou dados pessoais.

### Metodologia de desenvolvimento

Modelos representam conceitos de domínio, serviços coordenam operações, interfaces de repositório desacoplam persistência e testes verificam comportamentos selecionados. Alterações em regras financeiras simuladas devem incluir testes correspondentes.
