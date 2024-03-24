using DryIoc;
using MoviesMaestro.Interfaces;

namespace MoviesMaestro.Providers
{
    public class ContainerProvider : IProvider<IContainer?>
    {
        public IContainer? Get() => _container;

        public ContainerProvider()
        {
            InitializeContainer();
        }

        public void InitializeContainer()
        {
            _container = new Container(
                rules =>
                {
                    return rules
                        .WithMicrosoftDependencyInjectionRules()
                        .WithoutImplicitCheckForReuseMatchingScope();
                });
        }

        private IContainer? _container;
    }
}
