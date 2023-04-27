using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CVStatistics.Server.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CoronavirusStatisticsController : Controller
    {
        private readonly IGetpostmanCoronavirusApiHttpClient _httpClient;
        public CoronavirusStatisticsController(IGetpostmanCoronavirusApiHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        [Route("GetCountriesList")]
        /// <summary>
        /// Метод получает список всех стран без дополнительной информации для статистики
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetCountriesList()
        {
            string uri = "https://api.covid19api.com/countries";
            var response = await _httpClient.GetListData<CountryInfo>(uri);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetSummary")]
        /// <summary>
        /// Метод возвращает суммарную информацию по всем странам
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetSummary()
        {
            string uri = "https://api.covid19api.com/summary";
            var result = await _httpClient.GetData<MainStatistics>(uri);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetStatisticsByCountry/{slug}")]
        /// <summary>
        /// Метод получает всю статистику по выбранной стране (по дням)
        /// </summary>
        /// <param name="slug">Код страны из списка стран</param>
        /// <returns></returns>
        public async Task<IActionResult> GetStatisticsByCountry(string slug)
        {
            string uri = "https://api.covid19api.com/dayone/country/" + slug;
            var result = await _httpClient.GetListData<CountryDetailed>(uri);
            return Ok(result);
        }
    }
}
