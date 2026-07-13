namespace SistemaBancario.Models
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string titular, int numero) : base(titular, numero) { }

        public override bool Sacar(double valor)
        {
            if (valor > 0 && _saldo >= valor)
            {
                _saldo -= valor;
                _historico.Add($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} - Saque CP: -R$ {valor:F2}");
                return true;
            }
            return false;
        }
    }
}
