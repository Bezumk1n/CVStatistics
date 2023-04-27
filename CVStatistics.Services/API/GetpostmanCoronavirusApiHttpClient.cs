using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.API
{
    public class GetpostmanCoronavirusApiHttpClient : IGetpostmanCoronavirusApiHttpClient
    {
        private readonly HttpClient _client;

        public GetpostmanCoronavirusApiHttpClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<ResultDTO> GetData<T>(string uri)
        {
            var result = new ResultDTO();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                result.IsSuccess = response.IsSuccessStatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    var definition = new { Message = string.Empty };
                    var message = JsonConvert.DeserializeAnonymousType(jsonResponse, definition);
                    result.Message = message.Message;
                }
                else
                {
                    result.Value = new[] { JsonConvert.DeserializeObject<T>(jsonResponse) };
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        public async Task<ResultDTO> GetListData<T>(string uri)
        {
            var result = new ResultDTO();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                result.IsSuccess = response.IsSuccessStatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    var definition = new { Message = string.Empty };
                    var message = JsonConvert.DeserializeAnonymousType(jsonResponse, definition);
                    result.Message = message.Message;

                    return result;
                }
                else
                {
                    result.Value = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
