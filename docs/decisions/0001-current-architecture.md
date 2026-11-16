# ADR-0001 — Separar interface, serviços, modelos e repositórios

- **Status:** Registrado (arquitetura atual, documentada retrospectivamente)
- **Data do registro:** 2026-11-15

## Contexto

O projeto organiza a aplicação em uma interface de console, serviços de conta/cartão, modelos de domínio e abstrações de repositório com implementações em memória e arquivo.

## Decisão atual

Mantenho a separação entre interface, serviços, modelos e persistência para facilitar o estudo de orientação a objetos e a substituição da implementação do repositório.

## Consequências

- Posso testar serviços sem depender da interface de console.
- As implementações de repositório precisam respeitar o mesmo contrato.
- A persistência em arquivo e em memória possui limites diferentes.
- Operações financeiras simuladas precisam de testes que cubram saldos e invariantes.

## Nota histórica

Registrei a arquitetura observada no código de forma retrospectiva.
