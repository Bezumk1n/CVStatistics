﻿using CVStatistics.Domain.Interfaces;
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
        public CVStatisticsApiHttpClient(HttpClient client)
        {
            _client = client;
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
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
