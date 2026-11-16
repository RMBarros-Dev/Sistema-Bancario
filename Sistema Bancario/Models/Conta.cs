using System.Collections.Generic;

namespace SistemaBancario.Models
{
    public abstract class Conta
    {
        public string Titular { get; set; }
        public int Numero { get; set; }
        protected decimal _saldo;
        protected List<string> _historico = new List<string>();

        // Propriedades públicas para serialização/persistência (evitam reflexão nos repositórios)
        public decimal Saldo
        {
            get => _saldo;
            set => _saldo = value;
        }

        public List<string> Historico
        {
            get => _historico;
            set => _historico = value ?? new List<string>();
        }

        public Conta(string titular, int numero)
        {
            Titular = titular;
            Numero = numero;
            _saldo = 0.0m;
        }

        public virtual bool Depositar(decimal valor)
        {
            if (valor <= 0) return false;
            _saldo += valor;
            _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - Depósito: +R$ {valor:F2}");
            return true;
        }

        public abstract bool Sacar(decimal valor);

        public decimal ConsultarSaldo() => _saldo;
        public List<string> ObterExtrato() => _historico;

        public virtual bool Transferir(Conta destino, decimal valor)
        {
            if (destino == null || valor <= 0 || ReferenceEquals(destino, this))
                return false;

            if (!Sacar(valor))
                return false;

            if (!destino.Depositar(valor))
            {
                Depositar(valor);
                return false;
            }

            _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - Transferência para {destino.Numero}: -R$ {valor:F2}");
            return true;
        }

        public void RegistrarHistorico(string entrada)
        {
            _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - {entrada}");
        }
    }
}
