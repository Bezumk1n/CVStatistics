using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.EntityFramework
{
    public class StatisticsRepository : BaseRepository<MainStatistics>, IStatisticsRepository
    {
        public StatisticsRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    }
}
