using Xunit;
using SistemaBancario.Services;
using SistemaBancario.Models;

namespace SistemaBancario.Tests
{
    public class CardTests
    {
        [Fact]
        public void CartaoCredito_AumentaFaturaAoComprar()
        {
            var repo = new InMemoryAccountRepository();
            var accountService = new AccountService(repo);
            var cardService = new CardService(repo);

            var c = accountService.CriarContaCorrente("Cli", 9030, 100);
            var card = cardService.CriarCartaoCredito("1111", 9030, 500);

            var ok = card.Pagar(200);
            Assert.True(ok);
            Assert.Equal(200m, card.Fatura);
        }

        [Fact]
        public void PagarFatura_RejeitaValorAcimaDaFatura()
        {
            var repo = new InMemoryAccountRepository();
            var accountService = new AccountService(repo);
            var cardService = new CardService(repo);

            var account = accountService.CriarContaCorrente("Cli", 9041, 100m);
            accountService.Depositar(9041, 500m);
            var card = cardService.CriarCartaoCredito("3333", 9041, 1000m);
            Assert.True(card.Pagar(100m));

            Assert.False(card.PagarFatura(150m));
            Assert.Equal(500m, account.ConsultarSaldo());
            Assert.Equal(100m, card.Fatura);
        }

        [Fact]
        public void PagarFatura_DebitaContaEReduzFatura()
        {
            var repo = new InMemoryAccountRepository();
            var accountService = new AccountService(repo);
            var cardService = new CardService(repo);

            var c = accountService.CriarContaCorrente("Cli", 9040, 100);
            accountService.Depositar(9040, 800);
            var card = cardService.CriarCartaoCredito("2222", 9040, 1000);

            var compra = card.Pagar(300);
            Assert.True(compra);
            Assert.Equal(300m, card.Fatura);

            var pago = card.PagarFatura(300);
            Assert.True(pago);
            Assert.Equal(0m, card.Fatura);
            Assert.Equal(500m, c.ConsultarSaldo());
        }
    }
}
