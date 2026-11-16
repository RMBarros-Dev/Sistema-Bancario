using SistemaBancario.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SistemaBancario.Services
{
    public class CardService
    {
        private readonly IAccountRepository _repo;
        private readonly ILogger<CardService>? _logger;
        private readonly decimal _defaultLimit;

        public CardService(IAccountRepository repo, ILogger<CardService>? logger = null, IConfiguration? configuration = null)
        {
            _repo = repo;
            _logger = logger;
            if (configuration != null && decimal.TryParse(configuration["Banco:DefaultCardLimit"], out var lim)) _defaultLimit = lim; else _defaultLimit = 1000.0m;
        }

        public Cartao? CriarCartaoDebito(string numeroCartao, int numeroConta)
        {
            var conta = _repo.Get(numeroConta);
            if (conta == null) return null;
            var cartao = new Cartao(numeroCartao, conta, TipoCartao.Debito);
            _logger?.LogInformation("Criado cartão de débito {numero} para conta {conta}", numeroCartao, numeroConta);
            return cartao;
        }

        public Cartao? CriarCartaoCredito(string numeroCartao, int numeroConta, decimal? limite = null)
        {
            var conta = _repo.Get(numeroConta);
            if (conta == null) return null;
            var cartao = new Cartao(numeroCartao, conta, TipoCartao.Credito)
            {
                LimiteCredito = limite ?? _defaultLimit
            };
            _logger?.LogInformation("Criado cartão de crédito {numero} para conta {conta} com limite {limite}", numeroCartao, numeroConta, cartao.LimiteCredito);
            return cartao;
        }
    }
}
