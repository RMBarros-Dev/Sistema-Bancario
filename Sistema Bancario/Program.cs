using System;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaBancario;
using SistemaBancario.Services;
using SistemaBancario.Models;

// Configure Serilog from appsettings.json (fallback if file missing)
var tempConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(tempConfig).CreateLogger();

var builder = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Registrar repositório de arquivo usando caminho de configuração
        var dataPath = context.Configuration["Banco:DataPath"] ?? "data/accounts.json";
        services.AddSingleton<IAccountRepository>(sp => new FileAccountRepository(dataPath));
        services.AddSingleton<IAccountService, AccountService>();
        services.AddSingleton<CardService>();
        services.AddSingleton<ConsoleUI>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    });

using var host = builder.Build();

// Carrega configuração global
var config = host.Services.GetRequiredService<IConfiguration>();
EnvConfig.Load(config);

// Inicializa dados de exemplo
var repo = host.Services.GetRequiredService<IAccountRepository>();
var accountService = host.Services.GetRequiredService<IAccountService>();
var cardService = host.Services.GetRequiredService<CardService>();

// Cria contas de exemplo somente se não existirem
if (repo.Get(1001) == null) accountService.CriarContaCorrente("Cliente", 1001, 500.0);
if (repo.Get(1002) == null) accountService.CriarContaPoupanca("Cliente", 1002);

var ui = host.Services.GetRequiredService<ConsoleUI>();
await ui.RunAsync();

return 0;
