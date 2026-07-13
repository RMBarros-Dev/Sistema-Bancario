using SistemaBancario.Models;
using System.Collections.Generic;

namespace SistemaBancario.Services
{
    public interface IAccountService
    {
        ContaCorrente CriarContaCorrente(string titular, int numero, double limite);
        ContaPoupanca CriarContaPoupanca(string titular, int numero);
        bool Depositar(int numeroConta, double valor);
        bool Sacar(int numeroConta, double valor);
        bool Transferir(int origem, int destino, double valor);
        Conta? ObterConta(int numeroConta);
        IEnumerable<Conta> ListarContas();
    }
}
