using CVStatistics.Domain.BaseObjects;
using CVStatistics.WPF.ViewModels;
using CVStatistics.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.WPF.Extensions.HostBuilders
{
    /// <summary>
    /// Класс-расширение для регистрации ViewModel и фабрики
    /// </summary>
    internal static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                // Фабрика ViewModel
                services.AddSingleton<Func<Type, VM>>(serviceProvider => viewModelType => (VM)serviceProvider.GetRequiredService(viewModelType));

                services.AddSingleton<MainWindowV>();
                services.AddSingleton<MainWindowVM>();
                services.AddSingleton<DemoVM>();
            });
            return host;
        }
    }
}
