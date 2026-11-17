# Diretrizes de identidade visual — Sistema Bancário

## Posicionamento

Identidade visual de um projeto educacional de console desenvolvido em C#/.NET 10. A marca deve comunicar precisão, organização de domínio, rastreabilidade e disciplina técnica, sem sugerir que o software seja um banco real, uma instituição financeira ou um serviço de pagamentos.

## Conceito

O símbolo utiliza dois módulos verticais conectados por um eixo central. Os módulos representam contas e repositórios independentes; o núcleo representa as operações e regras de negócio que os conectam. A construção geométrica evita clichês de fachadas bancárias, moedas ou cartões de crédito.

## Paleta oficial

| Token | HEX | Aplicação |
| --- | --- | --- |
| Grafite azulado | `#101D2B` | Base institucional e fundos |
| Azul petróleo | `#1B3440` | Superfícies e profundidade |
| Verde mineral | `#35B7B1` | Conexões, indicadores e ênfase |
| Âmbar suave | `#E2B66F` | Destaques secundários |
| Marfim | `#F4F1EA` | Texto e contraste |
| Cinza mineral | `#AAB7BC` | Metadados e texto auxiliar |

## Ativos

- `assets/brand/logo.svg`: símbolo principal para fundos escuros.
- `assets/brand/logo-light.svg`: símbolo para fundos claros.
- `assets/brand/banner.svg`: banner horizontal do repositório.
- `assets/brand/project-mark.svg`: assinatura horizontal.

## Regras de aplicação

- Preservar proporções, cores e área de respiro dos SVGs.
- Utilizar os ativos locais do repositório.
- Em fundos escuros, utilizar `logo.svg`; em fundos claros, utilizar `logo-light.svg`.
- Não representar operações simuladas como transações reais.
- Não sugerir certificação, autorização regulatória, segurança bancária de produção ou vínculo com instituição financeira.
- A identidade visual não altera regras de negócio, persistência ou arquitetura do código.

## Assinatura

**Precisão nas regras. Clareza nas operações.**
