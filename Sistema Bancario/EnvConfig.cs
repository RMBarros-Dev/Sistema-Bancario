using Microsoft.Extensions.Configuration;
using System;

namespace SistemaBancario
{
    // Mantido por compatibilidade; agora a configuração central é appsettings.json via IConfiguration
    public static class EnvConfig
    {
        public static IConfiguration? Configuration { get; private set; }

        public static void Load(IConfiguration configuration)
        {
            Configuration = configuration;
            Console.WriteLine("Configuração carregada via IConfiguration.");
        }
    }
}
