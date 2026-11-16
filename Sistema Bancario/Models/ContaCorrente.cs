namespace SistemaBancario.Models
{
    public class ContaCorrente : Conta
    {
        public decimal Limite { get; set; }

        public ContaCorrente(string titular, int numero, decimal limite) : base(titular, numero)
        {
            Limite = limite;
        }

        public override bool Sacar(decimal valor)
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
