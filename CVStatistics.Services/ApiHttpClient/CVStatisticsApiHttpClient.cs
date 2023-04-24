using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models.DTO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.ApiHttpClient
{
    public class CVStatisticsApiHttpClient : ICVStatisticsApiHttpClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<CVStatisticsApiHttpClient> _logger;
        public CVStatisticsApiHttpClient(HttpClient client, ILogger<CVStatisticsApiHttpClient> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<RequestResultDTO> GetData(string uri)
        {
            var result = new RequestResultDTO();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<RequestResultDTO>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                //TODO Оповестить пользователя об ошибке
                //$"Ошибка при попытке получить информацию по запросу:{Environment.NewLine}{uri}"
            }
            return result;
        }
    }
}
