using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null) return;
            else
            {
                var dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                    _dbContext.SaveChanges();
                }
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Save(T entity)
        {
            if (entity.Id != new Guid())
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
