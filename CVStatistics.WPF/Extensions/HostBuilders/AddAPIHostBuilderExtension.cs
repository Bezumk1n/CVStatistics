using CVStatistics.Domain.Interfaces;
using CVStatistics.Services.ApiHttpClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.WPF.Extensions.HostBuilders
{
    public static class AddAPIHostBuilderExtension
    {
        public static IHostBuilder AddAPI(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddHttpClient<ICVStatisticsApiHttpClient, CVStatisticsApiHttpClient>();
            });

            return host;
        }
    }
}
