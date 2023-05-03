using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.EntityFramework
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly RepositoryContext _repositoryContext;

        public BaseRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async virtual Task<T> Create(T entity)
        {
            var savedEntity = await _repositoryContext.Set<T>().AddAsync(entity);
            return savedEntity.Entity;
        }
        public async virtual Task Create(IQueryable<T> entities)
        {
            await _repositoryContext.Set<T>().AddRangeAsync(entities);
        }
        public async virtual Task<T> Get(string id)
        {
            var entity = await _repositoryContext.Set<T>().FirstOrDefaultAsync(q => q.ID == id && q.IsDeleted == false);
            return entity;
        }
        public async virtual Task<IQueryable<T>> GetAll()
        {
            IQueryable<T> query = _repositoryContext.Set<T>();
            var entities = query.Where(q => q.IsDeleted == false).AsNoTracking();
            return entities;
        }

        public async virtual Task<T> Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
            return entity;
        }
        public async virtual Task Delete(T entity)
        {
            entity.IsDeleted = true;
            await Update(entity);
        }
    }
}
