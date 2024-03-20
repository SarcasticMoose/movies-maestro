using Avalonia.SimpleRouter;
using DryIoc;
using MoviesMaestro.ViewModels;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
    }
}
