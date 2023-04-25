using CVStatistics.Domain.Models.DTO;
using CVStatistics.Domain.Models.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface ICoronavirusService
    {
        Task<SummaryStatistics> GetSummary();
        Task<IEnumerable<CountryInfo>> GetCountriesList();
        Task<IEnumerable<CountryDetailed>> GetStatisticsByCountry(string slug);
    }
}
