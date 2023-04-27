using CVStatistics.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface IGetpostmanCoronavirusApiHttpClient
    {
        Task<ResultDTO> GetData<T>(string uri);
        Task<ResultDTO> GetListData<T>(string uri);
    }
}
