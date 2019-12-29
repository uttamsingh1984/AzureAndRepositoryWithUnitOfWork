using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureAndRepositoryWithUnitOfWork.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(TEntity entity)
        {
            _dbContext.Add<TEntity>(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression predicate)
        {
            //return _dbContext.Find<TEntity>(predicate);
            return null;
        }

        public TEntity Get(object Id)
        {
            return _dbContext.Find<TEntity>(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Remove(object Id)
        {
            TEntity enity= _dbContext.Find<TEntity>(Id);
            _dbContext.Remove(enity);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Remove<TEntity>(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }
    }
}
