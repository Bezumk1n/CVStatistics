using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using CVStatistics.Domain.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.CoronavirusServices
{
    /// <summary>
    /// Сервис, предоставляющий данные от открытого API сервиса
    /// https://documenter.getpostman.com/view/10808728/SzS8rjbc
    /// </summary>
    public class CoronavirusService : ICoronavirusService
    {
        private readonly ICVStatisticsApiHttpClient _client;
        public CoronavirusService(ICVStatisticsApiHttpClient client)
        {
            _client = client;
        }
        /// <summary>
        /// Метод возвращает суммарную информацию по всем странам
        /// </summary>
        /// <returns></returns>
        public async Task<MainStatistics> GetSummary()
        {
            string uri = "http://192.168.0.175:5000/api/v1/CoronavirusStatistics/GetSummary";
            var response = await _client.GetData(uri);

            var result = new MainStatistics();
            
            if (response.IsSuccess)
            {
                var value = response.Value as IEnumerable<object>;
                var deserializedList = value.Select(q => JsonConvert.DeserializeObject<MainStatistics>(q.ToString())).ToArray();
                result = deserializedList.FirstOrDefault();
            }
            else
            {
                //TODO Сообщить пользователю об ошибке
            }
            return result;
        }
        /// <summary>
        /// Метод получает список всех стран без дополнительной информации для статистики
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CountryInfo>> GetCountriesList()
        {
            string uri = "http://192.168.0.175:5000/api/v1/CoronavirusStatistics/GetCountriesList";
            var response = await _client.GetData(uri);

            var result = Enumerable.Empty<CountryInfo>();
            
            if (response.IsSuccess)
            {
                var value = response.Value as ICollection<object>;
                var deserializedList = response.Value.Select(q => JsonConvert.DeserializeObject<CountryInfo>(q.ToString())).ToArray();
                result = deserializedList;
            }
            else
            {
                //TODO Сообщить пользователю об ошибке
            }
            return result;
        }
        /// <summary>
        /// Метод получает всю статистику по выбранной стране (по дням)
        /// </summary>
        /// <param name="slug">Код страны из списка стран</param>
        /// <returns></returns>
        public async Task<IEnumerable<CountryDetailed>> GetStatisticsByCountry(string slug)
        {
            string uri = "http://192.168.0.175:5000/api/v1/CoronavirusStatistics/GetStatisticsByCountry/" + slug;
            var response = await _client.GetData(uri);

            var result = Enumerable.Empty<CountryDetailed>();

            if (response.IsSuccess)
            {
                var value = response.Value as IEnumerable<object>;
                var deserializedList = value.Select(q => JsonConvert.DeserializeObject<CountryDetailed>(q.ToString())).ToArray();
                result = deserializedList;
            }
            else
            {
                //TODO Сообщить пользователю об ошибке
            }
            return result;
        }
    }
}
