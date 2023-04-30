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
        private readonly IExternalCoronavirusService _service;
        public CoronavirusStatisticsController(IExternalCoronavirusService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetCountriesList")]
        /// <summary>
        /// Метод получает список всех стран без дополнительной информации для статистики
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetCountriesList()
        {
            var result = await _service.GetCountriesList();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSummary")]
        /// <summary>
        /// Метод возвращает суммарную информацию по всем странам
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetSummary()
        {
            var result = await _service.GetSummary();
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
            var result = await _service.GetStatisticsByCountry(slug);
            return Ok(result);
        }
    }
}
