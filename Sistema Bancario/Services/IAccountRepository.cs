using System.Collections.Generic;
using SistemaBancario.Models;

namespace SistemaBancario.Services
{
    public interface IAccountRepository
    {
        void Add(Conta conta);
        Conta? Get(int numero);
        IEnumerable<Conta> GetAll();
        void Save();
    }
}
