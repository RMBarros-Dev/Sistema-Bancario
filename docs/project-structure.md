# Organização do repositório — Sistema Bancário

A aplicação principal está organizada por domínio, serviços, interfaces de repositório e interface de console. Os testes ficam em projeto separado.

| Caminho | Responsabilidade |
| --- | --- |
| `Sistema Bancario/Models/` | Modelos de domínio. |
| `Sistema Bancario/Services/` | Serviços e abstrações de persistência. |
| `Sistema Bancario/UI/` | Interação via console. |
| `Sistema Bancario/Resources/` | Recursos de localização. |
| `Sistema Bancario/Program.cs` | Composição e ponto de entrada. |
| `SistemaBancario.Tests/` | Testes automatizados xUnit. |
| `.github/workflows/` | Workflow de CI .NET. |
| `assets/brand/` | Logotipo, banner e marca do projeto. |

## Convenções

- Manter regras de domínio fora da interface de console.
- Usar interfaces para desacoplar serviços dos mecanismos de persistência.
- Acompanhar alterações de comportamento com testes.
- Não usar dados financeiros reais nem tratar a aplicação como sistema bancário operacional.
