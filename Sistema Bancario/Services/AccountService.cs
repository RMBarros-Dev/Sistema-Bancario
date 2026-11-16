using SistemaBancario.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace SistemaBancario.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly ILogger<AccountService>? _logger;

        public AccountService(IAccountRepository repo, ILogger<AccountService>? logger = null)
        {
            _repo = repo;
            _logger = logger;
        }

        public ContaCorrente CriarContaCorrente(string titular, int numero, decimal limite)
        {
            var c = new ContaCorrente(titular, numero, limite);
            _repo.Add(c);
            return c;
        }

        public ContaPoupanca CriarContaPoupanca(string titular, int numero)
        {
            var c = new ContaPoupanca(titular, numero);
            _repo.Add(c);
            return c;
        }

        public bool Depositar(int numeroConta, decimal valor)
        {
            var c = _repo.Get(numeroConta);
            if (c == null) return false;
            var ok = c.Depositar(valor);
            if (ok) _logger?.LogInformation("Depósito {valor} na conta {numero}", valor, numeroConta);
            if (ok) _repo.Save();
            return ok;
        }

        public bool Sacar(int numeroConta, decimal valor)
        {
            var c = _repo.Get(numeroConta);
            if (c == null) return false;
            var ok = c.Sacar(valor);
            if (ok) _logger?.LogInformation("Saque {valor} da conta {numero}", valor, numeroConta);
            if (ok) _repo.Save();
            return ok;
        }

        public bool Transferir(int origem, int destino, decimal valor)
        {
            var cOrig = _repo.Get(origem);
            var cDest = _repo.Get(destino);
            if (cOrig == null || cDest == null) return false;
            var ok = cOrig.Transferir(cDest, valor);
            if (ok) _logger?.LogInformation("Transferência {valor} de {origem} para {destino}", valor, origem, destino);
            if (ok) _repo.Save();
            return ok;
        }

        public Conta? ObterConta(int numeroConta) => _repo.Get(numeroConta);
        public IEnumerable<Conta> ListarContas() => _repo.GetAll();
    }
}
