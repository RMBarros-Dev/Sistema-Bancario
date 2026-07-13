using System.Collections.Generic;

namespace SistemaBancario.Models
{
    public abstract class Conta
    {
        public string Titular { get; set; }
        public int Numero { get; set; }
        protected double _saldo;
        protected List<string> _historico = new List<string>();

        // Propriedades públicas para serialização/persistência (evitam reflexão nos repositórios)
        public double Saldo
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
            _saldo = 0.0;
        }

        public virtual bool Depositar(double valor)
        {
            if (valor <= 0) return false;
            _saldo += valor;
            _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - Depósito: +R$ {valor:F2}");
            return true;
        }

        public abstract bool Sacar(double valor);

        public double ConsultarSaldo() => _saldo;
        public List<string> ObterExtrato() => _historico;

        public virtual bool Transferir(Conta destino, double valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - Transferência para {destino.Numero}: -R$ {valor:F2}");
                return true;
            }
            return false;
        }

        public void RegistrarHistorico(string entrada)
        {
            _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - {entrada}");
        }
    }
}
