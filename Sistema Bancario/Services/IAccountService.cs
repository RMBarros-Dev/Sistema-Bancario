using SistemaBancario.Models;
using System.Collections.Generic;

namespace SistemaBancario.Services
{
    public interface IAccountService
    {
        ContaCorrente CriarContaCorrente(string titular, int numero, decimal limite);
        ContaPoupanca CriarContaPoupanca(string titular, int numero);
        bool Depositar(int numeroConta, decimal valor);
        bool Sacar(int numeroConta, decimal valor);
        bool Transferir(int origem, int destino, decimal valor);
        Conta? ObterConta(int numeroConta);
        IEnumerable<Conta> ListarContas();
    }
}
