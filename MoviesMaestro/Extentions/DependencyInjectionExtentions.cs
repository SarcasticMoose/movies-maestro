using Avalonia.SimpleRouter;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoviesMaestro.Interfaces;
using MoviesMaestro.ViewModels;
using Serilog;
using Serilog.Core;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;

namespace MoviesMaestro.Extentions
{
    public static class DependencyInjectionExtentions
    {
        public static IContainer RegisterRouter(this IContainer container)
        {
            container.RegisterDelegate(r =>
            new HistoryRouter<ViewModelBase>(t => (ViewModelBase)r.Resolve(t)), Reuse.Singleton);

            return container;
        }

        public static IContainer RegisterViewModels(this IContainer container)
        {
            Type[] assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

            container.RegisterMany(assemblyTypes,
                serviceTypeCondition: type =>
                    type.Name.EndsWith("ViewModel"));

            return container;
        }

        public static IContainer RegisterProviders(this IContainer container)
        {
            RegisterLoggerConfiguration(container);

            return container;
        }

        public static IContainer RegisterFileSystem(this IContainer container)
        {
            container.Register<IFileSystem, FileSystem>();

            return container;
        }

        public static IContainer RegisterLogger(this IContainer container)
        {
            IServiceCollection services = new ServiceCollection();

            IProvider<IConfiguration> configuration = container.Resolve<IProvider<IConfiguration>>();

            Logger logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration.Get())
                .CreateLogger();

            services.AddLogging(builder =>
            {
                builder.AddSerilog(logger, dispose: true);
            });

            services.BuildServiceProvider();

            container.Populate(services);

            return container;
        }

        private static void RegisterLoggerConfiguration(this IContainer container)
        {
            container.Register<IProvider<IConfiguration>, Providers.ConfigurationProvider>();
            IProvider<IConfiguration> configuration = container.Resolve<IProvider<IConfiguration>>();
            container.RegisterInstance(configuration);
        }

    }
}
