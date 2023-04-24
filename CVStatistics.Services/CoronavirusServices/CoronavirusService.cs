using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models.DTO;
using CVStatistics.Domain.Models.PL;
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
        public async Task<SummaryStatistics> GetSummary()
        {
            string uri = "http://192.168.0.175:5000/api/v1/CoronavirusStatistics/GetSummary";

            var result = new SummaryStatistics();

            var response = await _client.GetData(uri);
            
            if (response.IsSuccess)
            {
                var value = response.Value as IEnumerable<object>; 
                var deserializedList = value.Select(q => JsonConvert.DeserializeObject<SummaryStatistics>(q.ToString())).ToArray();
                result = deserializedList.FirstOrDefault();
            }
            else
            {
                //TODO Сообщить пользователю об ошибке
            }

            return result;
        }
    }
}
