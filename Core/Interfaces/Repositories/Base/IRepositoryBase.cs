using Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate);

        Task Save(TEntity entity);

        Task Delete(TEntity entity);
    }
}
