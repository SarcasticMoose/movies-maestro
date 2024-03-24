using Microsoft.Extensions.Configuration;
using MoviesMaestro.Interfaces;
using System;
using System.IO.Abstractions;

namespace MoviesMaestro.Providers
{
    public class ConfigurationProvider : IProvider<IConfiguration>
    {
        private const string AppSettings = "appsettings.json";
        private readonly IFileSystem _fileSystem;

        public ConfigurationProvider(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IConfiguration Get()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(_fileSystem.Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
               .Build();

            return configuration;
        }
    }
}
