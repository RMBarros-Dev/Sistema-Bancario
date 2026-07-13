namespace SistemaBancario.Models
{
    public class ContaCorrente : Conta
    {
        public double Limite { get; set; }

        public ContaCorrente(string titular, int numero, double limite) : base(titular, numero)
        {
            Limite = limite;
        }

        public override bool Sacar(double valor)
        {
            if (valor > 0 && (_saldo + Limite) >= valor)
            {
                _saldo -= valor;
                _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - Saque CC: -R$ {valor:F2}");
                return true;
            }
            return false;
        }
    }
}
