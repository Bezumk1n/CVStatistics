using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using CVStatistics.Services.APIExternal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CVStatistics.Services
{
    public class UpdateLocalStatisticsService : BackgroundService
    {
        private readonly IExternalCoronavirusService _externalCoronavirusService;

        public UpdateLocalStatisticsService(IServiceProvider serviceProvider)
        {
            _externalCoronavirusService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IExternalCoronavirusService>();
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                try
                {
                    var result = await _externalCoronavirusService.GetSummary();
                    await Task.Delay(new TimeSpan(0,0,10));
                }
                catch (OperationCanceledException)
                {
                    // execution cancelled
                }
                catch (Exception e)
                {
                    // Catch and log all exceptions,
                    // So we can continue processing other tasks
                }
            }
        }
    }
}
