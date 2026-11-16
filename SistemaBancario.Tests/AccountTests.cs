using Xunit;
using SistemaBancario.Services;
using SistemaBancario.Models;

namespace SistemaBancario.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Deposito_IncrementaSaldo()
        {
            var repo = new InMemoryAccountRepository();
            var service = new AccountService(repo);
            var c = service.CriarContaCorrente("T", 9001, 100);

            var result = service.Depositar(9001, 200);
            Assert.True(result);
            Assert.Equal(200m, c.ConsultarSaldo());
        }

        [Fact]
        public void Saque_DecrementaSaldo()
        {
            var repo = new InMemoryAccountRepository();
            var service = new AccountService(repo);
            var c = service.CriarContaCorrente("T", 9002, 100);
            service.Depositar(9002, 300);

            var res = service.Sacar(9002, 150);
            Assert.True(res);
            Assert.Equal(150m, c.ConsultarSaldo());
        }

        [Fact]
        public void Transferencia_DevolveTrueQuandoSucesso()
        {
            var repo = new InMemoryAccountRepository();
            var service = new AccountService(repo);
            var c1 = service.CriarContaCorrente("A", 9010, 100);
            var c2 = service.CriarContaPoupanca("B", 9011);
            service.Depositar(9010, 500);

            var ok = service.Transferir(9010, 9011, 200);
            Assert.True(ok);
            Assert.Equal(300m, c1.ConsultarSaldo());
            Assert.Equal(200m, c2.ConsultarSaldo());
        }

        [Fact]
        public void Cartao_Debito_PagaQuandoSaldoSuficiente()
        {
            var repo = new InMemoryAccountRepository();
            var service = new AccountService(repo);
            var cardService = new CardService(repo);
            var c = service.CriarContaCorrente("C", 9020, 100);
            service.Depositar(9020, 400);
            var card = cardService.CriarCartaoDebito("0000", 9020);

            var pago = card.Pagar(150);
            Assert.True(pago);
            Assert.Equal(250m, c.ConsultarSaldo());
        }
    }
}
