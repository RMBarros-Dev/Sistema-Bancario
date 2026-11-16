# Como contribuo com o Sistema Bancário

Mantenho este projeto como uma simulação educacional de operações bancárias em C#/.NET. As operações não representam um serviço financeiro real.

## Ambiente

Utilizo o .NET 10 SDK.

## Verificações antes de enviar alterações

```bash
dotnet restore "Sistema Bancario.slnx"
dotnet build "Sistema Bancario.slnx" --configuration Release
dotnet test "SistemaBancario.Tests/SistemaBancario.Tests.csproj" --configuration Release
```

## Diretrizes

- Incluo testes para alterações em depósitos, saques, transferências, cartões e regras de saldo.
- Utilizo tipos decimais para valores monetários.
- Não trato a simulação como sistema bancário de produção.
- Não incluo credenciais ou dados pessoais reais.
