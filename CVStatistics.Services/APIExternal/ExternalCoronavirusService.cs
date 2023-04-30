using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using CVStatistics.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.APIExternal
{
    public class ExternalCoronavirusService : IExternalCoronavirusService
    {
        private readonly IGetpostmanCoronavirusApiHttpClient _httpClient;

        public ExternalCoronavirusService(IGetpostmanCoronavirusApiHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultDTO> GetCountriesList()
        {
            string uri = "https://api.covid19api.com/countries";
            var response = await _httpClient.GetListData<CountryInfo>(uri);
            return response;
        }
        public async Task<ResultDTO> GetSummary()
        {
            string uri = "https://api.covid19api.com/summary";
            var response = await _httpClient.GetData<MainStatistics>(uri);
            return response;
        }
        public async Task<ResultDTO> GetStatisticsByCountry(string slug)
        {
            string uri = "https://api.covid19api.com/dayone/country/" + slug;
            var response = await _httpClient.GetListData<CountryDetailed>(uri);
            return response;
        }
    }
}
