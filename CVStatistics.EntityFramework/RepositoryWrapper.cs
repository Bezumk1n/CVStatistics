using CVStatistics.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.EntityFramework
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IStatisticsRepository _statistics;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
        public IStatisticsRepository Statistics
        {
            get
            {
                if (_statistics == null)
                {
                    _statistics = new StatisticsRepository(_repoContext);
                }
                return _statistics;
            }
        }
    }
}
