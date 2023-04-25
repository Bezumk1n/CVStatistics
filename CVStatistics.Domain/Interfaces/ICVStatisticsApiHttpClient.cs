using CVStatistics.Domain.Models.DTO;

namespace CVStatistics.Domain.Interfaces
{
    public interface ICVStatisticsApiHttpClient
    {
        Task<ResultDTO> GetData(string uri);
    }
}