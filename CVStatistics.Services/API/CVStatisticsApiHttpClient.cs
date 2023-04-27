using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models.DTO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.API
{
    public class CVStatisticsApiHttpClient : ICVStatisticsApiHttpClient
    {
        private readonly HttpClient _client;
        public CVStatisticsApiHttpClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<ResultDTO> GetData(string uri)
        {
            var result = new ResultDTO();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ResultDTO>(jsonResponse);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
