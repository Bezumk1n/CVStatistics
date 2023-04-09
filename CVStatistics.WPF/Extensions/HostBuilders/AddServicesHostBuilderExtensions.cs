using CVStatistics.Domain.Interfaces;
using CVStatistics.Services;
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
    /// Класс-расширение для регистрации сервисов приложения
    /// </summary>
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigationService, NavigationService>();
            });
            return host;
        }
    }
}
