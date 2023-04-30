using CVStatistics.Domain.Models;
using CVStatistics.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface IExternalCoronavirusService
    {
        Task<ResultDTO> GetSummary();
        Task<ResultDTO> GetCountriesList();
        Task<ResultDTO> GetStatisticsByCountry(string slug);
    }
}
