using CVStatistics.Domain.Models.DTO;

namespace CVStatistics.Domain.Interfaces
{
    public interface ICVStatisticsApiHttpClient
    {
        Task<RequestResultDTO> GetData(string uri);
    }
}