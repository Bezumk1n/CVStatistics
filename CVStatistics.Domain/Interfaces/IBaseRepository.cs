using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);
        Task Create(IQueryable<T> entities);
        Task<T> Get(string id);
        Task<IQueryable<T>> GetAll();
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
