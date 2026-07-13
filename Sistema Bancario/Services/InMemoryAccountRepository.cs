using System.Collections.Concurrent;
using SistemaBancario.Models;

namespace SistemaBancario.Services
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly ConcurrentDictionary<int, Conta> _contas = new();

        public void Add(Conta conta) => _contas[conta.Numero] = conta;
        public Conta? Get(int numero) => _contas.TryGetValue(numero, out var c) ? c : null;
        public IEnumerable<Conta> GetAll() => _contas.Values;
        public void Save() { /* in-memory: nothing to persist */ }
    }
}
