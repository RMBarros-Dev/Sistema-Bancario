using System;
using System.Threading.Tasks;
using SistemaBancario.Services;
using SistemaBancario.Models;

namespace SistemaBancario
{
    public class ConsoleUI
    {
        private readonly IAccountService _accounts;
        private readonly CardService _cards;
        private readonly Microsoft.Extensions.Logging.ILogger<ConsoleUI>? _logger;

        public ConsoleUI(IAccountService accounts, CardService cards, Microsoft.Extensions.Logging.ILogger<ConsoleUI>? logger = null)
        {
            _accounts = accounts;
            _cards = cards;
            _logger = logger;
        }

        public async Task RunAsync()
        {
            var rm = new System.Resources.ResourceManager("SistemaBancario.Resources.Strings", typeof(ConsoleUI).Assembly);
            var previous = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(rm.GetString("Started") ?? "--- SISTEMA BANCÁRIO INICIADO ---");
            Console.ForegroundColor = previous;

            bool rodando = true;
            while (rodando)
            {
                Console.WriteLine("\n" + (rm.GetString("Menu") ?? "1-Depositar | 2-Sacar | 3-Consultar | 4-Transferir | 5-Extrato | 6-Pagar com Cartão | 7-Bloquear/Desbloquear Cartão | 0-Sair"));
                string? op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        HandleDepositar();
                        break;
                    case "2":
                        HandleSacar();
                        break;
                    case "3":
                        HandleConsultar();
                        break;
                    case "4":
                        HandleTransferir();
                        break;
                    case "5":
                        HandleExtrato();
                        break;
                    case "6":
                        HandlePagarCartao();
                        break;
                    case "7":
                        HandleBloquearCartao();
                        break;
                    case "0":
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine(rm.GetString("InvalidOption") ?? "Opção inválida.");
                        break;
                }
            }

            await Task.CompletedTask;
        }

        private void HandleDepositar()
        {
            Console.Write("Número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int num)) { Console.WriteLine("Entrada inválida."); return; }
            Console.Write("Valor a depositar: ");
            if (!double.TryParse(Console.ReadLine(), out double v)) { Console.WriteLine("Entrada inválida."); return; }
            if (_accounts.Depositar(num, v)) Console.WriteLine("Depósito realizado."); else Console.WriteLine("Falha no depósito.");
        }

        private void HandleSacar()
        {
            Console.Write("Número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int num)) { Console.WriteLine("Entrada inválida."); return; }
            Console.Write("Valor a sacar: ");
            if (!double.TryParse(Console.ReadLine(), out double v)) { Console.WriteLine("Entrada inválida."); return; }
            if (_accounts.Sacar(num, v)) Console.WriteLine("Saque realizado."); else Console.WriteLine("Saldo insuficiente.");
        }

        private void HandleConsultar()
        {
            foreach (var c in _accounts.ListarContas())
            {
                Console.WriteLine($"Conta {c.Numero} - Titular: {c.Titular} - Saldo: {c.ConsultarSaldo():F2}");
            }
        }

        private void HandleTransferir()
        {
            Console.Write("Conta origem: ");
            if (!int.TryParse(Console.ReadLine(), out int o)) { Console.WriteLine("Entrada inválida."); return; }
            Console.Write("Conta destino: ");
            if (!int.TryParse(Console.ReadLine(), out int d)) { Console.WriteLine("Entrada inválida."); return; }
            Console.Write("Valor: ");
            if (!double.TryParse(Console.ReadLine(), out double v)) { Console.WriteLine("Entrada inválida."); return; }
            if (_accounts.Transferir(o, d, v)) Console.WriteLine("Transferência efetuada."); else Console.WriteLine("Falha na transferência: saldo indisponível ou conta não encontrada.");
        }

        private void HandleExtrato()
        {
            Console.Write("Número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int num)) { Console.WriteLine("Entrada inválida."); return; }
            var c = _accounts.ObterConta(num);
            if (c == null) { Console.WriteLine("Conta não encontrada."); return; }
            Console.WriteLine($"Extrato conta {c.Numero}:");
            foreach (var e in c.ObterExtrato()) Console.WriteLine(e);
        }

        private void HandlePagarCartao()
        {
            Console.Write("Número da conta vinculada ao cartão: ");
            if (!int.TryParse(Console.ReadLine(), out int num)) { Console.WriteLine("Entrada inválida."); return; }
            Console.Write("Valor a pagar: ");
            if (!double.TryParse(Console.ReadLine(), out double v)) { Console.WriteLine("Entrada inválida."); return; }

            var card = _cards.CriarCartaoDebito("virtual", num);
            if (card == null) { Console.WriteLine("Conta não encontrada para cartão."); return; }
            if (card.Pagar(v)) Console.WriteLine("Pagamento com cartão efetuado."); else Console.WriteLine(card.Bloqueado ? "Cartão bloqueado." : "Pagamento recusado: saldo insuficiente ou fatura com limite.");
        }

        private void HandleBloquearCartao()
        {
            Console.Write("Número da conta vinculada ao cartão: ");
            if (!int.TryParse(Console.ReadLine(), out int num)) { Console.WriteLine("Entrada inválida."); return; }
            var card = _cards.CriarCartaoDebito("virtual", num);
            if (card == null) { Console.WriteLine("Conta não encontrada para cartão."); return; }
            Console.WriteLine(card.Bloqueado ? "Cartão está bloqueado. Deseja desbloquear? s/n" : "Cartão está ativo. Deseja bloquear? s/n");
            var resp = Console.ReadLine();
            if (!string.IsNullOrEmpty(resp) && resp.ToLower().StartsWith("s"))
            {
                if (card.Bloqueado) { card.Desbloquear(); Console.WriteLine("Cartão desbloqueado."); }
                else { card.Bloquear(); Console.WriteLine("Cartão bloqueado."); }
            }
        }
    }
}
