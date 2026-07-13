namespace SistemaBancario.Models
{
    public enum TipoCartao { Debito, Credito }

    public class Cartao
    {
        public string Numero { get; set; }
        public Conta ContaAssociada { get; }
        public bool Bloqueado { get; private set; }

        // Para cartão de crédito simples
        public TipoCartao Tipo { get; set; }
        public double Fatura { get; private set; }
        public double LimiteCredito { get; set; }

        public Cartao(string numero, Conta conta, TipoCartao tipo = TipoCartao.Debito)
        {
            Numero = numero;
            ContaAssociada = conta;
            Bloqueado = false;
            Tipo = tipo;
            Fatura = 0.0;
            LimiteCredito = 0.0;
        }

        public void Bloquear() => Bloqueado = true;
        public void Desbloquear() => Bloqueado = false;

        public bool Pagar(double valor)
        {
            if (Bloqueado) return false;

            if (Tipo == TipoCartao.Debito)
            {
                if (ContaAssociada.Sacar(valor))
                {
                    ContaAssociada.RegistrarHistorico($"Pagamento Cartão {Numero}: -R$ {valor:F2}");
                    return true;
                }
                return false;
            }
            else
            {
                // Crédito: adiciona à fatura se houver limite
                if (valor <= 0) return false;
                if ((Fatura + valor) <= LimiteCredito)
                {
                    Fatura += valor;
                    ContaAssociada.RegistrarHistorico($"Compra no crédito Cartão {Numero}: +R$ {valor:F2} (fatura)");
                    return true;
                }
                return false;
            }
        }

        public bool PagarFatura(double valor)
        {
            if (valor <= 0) return false;
            if (ContaAssociada.Sacar(valor))
            {
                Fatura = System.Math.Max(0, Fatura - valor);
                ContaAssociada.RegistrarHistorico($"Pagamento fatura Cartão {Numero}: -R$ {valor:F2}");
                return true;
            }
            return false;
        }
    }
}
