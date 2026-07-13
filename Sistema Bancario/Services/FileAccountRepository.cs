using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SistemaBancario.Models;

namespace SistemaBancario.Services
{
    public class FileAccountRepository : IAccountRepository
    {
        private readonly ConcurrentDictionary<int, Conta> _contas = new();
        private readonly string _path;

        public FileAccountRepository(string path)
        {
            _path = path;
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_path)) return;
            var text = File.ReadAllText(_path);
            try
            {
                var dtos = JsonSerializer.Deserialize<List<AccountDto>>(text);
                if (dtos == null) return;
                foreach (var d in dtos)
                {
                    Conta c;
                    if (d.Type == "CC") c = new ContaCorrente(d.Titular, d.Numero, d.Limite);
                    else c = new ContaPoupanca(d.Titular, d.Numero);
                    // restore saldo and history via propriedades públicas
                    c.Saldo = d.Saldo;
                    c.Historico = d.Historico ?? new List<string>();
                    _contas[d.Numero] = c;
                }
            }
            catch { /* ignore malformed file */ }
        }

        public void Add(Conta conta)
        {
            _contas[conta.Numero] = conta;
            Save();
        }

        public Conta? Get(int numero) => _contas.TryGetValue(numero, out var c) ? c : null;

        public IEnumerable<Conta> GetAll() => _contas.Values.ToList();

        public void Save()
        {
            var list = _contas.Values.Select(c => new AccountDto
            {
                Numero = c.Numero,
                Titular = c.Titular,
                Type = c is ContaCorrente ? "CC" : "CP",
                Saldo = c.Saldo,
                Limite = c is ContaCorrente cc ? cc.Limite : 0.0,
                Historico = c.Historico
            }).ToList();

            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(_path) ?? "");
            File.WriteAllText(_path, json);
        }

        private class AccountDto
        {
            public string Type { get; set; } = "CP";
            public string Titular { get; set; } = string.Empty;
            public int Numero { get; set; }
            public double Saldo { get; set; }
            public double Limite { get; set; }
            public List<string>? Historico { get; set; }
        }
    }
}
