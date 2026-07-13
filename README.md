# Sistema Bancário - Console Application (.NET 10)

Este projeto é uma aplicação console desenvolvida em C# com .NET 10, projetada para simular operações bancárias essenciais. O objetivo principal deste sistema é demonstrar a aplicação de conceitos de Programação Orientada a Objetos (POO), estruturação de projetos em camadas e boas práticas de desenvolvimento de software.

## 🚀 Funcionalidades

* **Gestão de Contas:** Operações de débito e crédito em Contas Corrente e Poupança.
* **Transferências:** Movimentação de saldo entre contas distintas.
* **Gestão de Cartão:** Suporte a operações de cartão (débito/crédito).
* **Histórico de Movimentações:** Rastreamento de transações realizadas.
* **Autenticação:** Sistema de login seguro para acesso aos dados.

## 🏗️ Estrutura do Projeto

O projeto segue uma organização modular para facilitar a manutenção e escalabilidade:

* `SistemaBancario/`: Projeto principal da aplicação.
    * `Models/`: Classes de domínio (Conta, Cartão, Usuário, etc.).
    * `Services/`: Lógica de negócio, serviços e gerenciamento de repositório.
    * `UI/`: Interface de console (ConsoleUI) para interação com o usuário.
* `SistemaBancario.Tests/`: Conjunto de testes automatizados com xUnit.

## 🛠️ Como Executar

Certifique-se de ter o [.NET 10 SDK](https://dotnet.microsoft.com/) instalado em sua máquina.

1. **Clone o repositório:**
   ```bash
   git clone <link-do-seu-repositorio>
   cd <nome-da-pasta>

```

2. **Restaurar dependências:**
```bash
dotnet restore

```


3. **Executar a aplicação:**
```bash
dotnet run --project "Sistema Bancario/Sistema Bancario.csproj"

```



## 🧪 Testes

Para garantir a integridade das regras de negócio, o projeto possui uma camada de testes automatizados. Execute-os com o comando:

```bash
dotnet test

```

## ⚙️ Configurações

O sistema utiliza o arquivo `appsettings.json` para gerenciar configurações globais, como limites de cartão e chaves de ambiente. Certifique-se de que o arquivo esteja preenchido corretamente antes de iniciar a aplicação.

---

## ⚠️ Aviso Legal

Este projeto foi desenvolvido estritamente para **fins educacionais e de demonstração**.

* Não utilize este código em ambientes de produção.
* A implementação não contém tratamentos de concorrência, persistência de dados em banco real ou medidas avançadas de cibersegurança necessárias para sistemas bancários reais.
