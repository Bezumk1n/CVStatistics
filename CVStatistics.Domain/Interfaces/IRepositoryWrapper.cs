using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IStatisticsRepository Statistics { get; }
        Task Save();
    }
}
