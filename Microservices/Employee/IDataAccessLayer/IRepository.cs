using System.Linq.Expressions;
using System.Data.Entity.Core.Objects;
using Microsoft.EntityFrameworkCore;

namespace IDataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Find(params object[] predicate);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetByID(Expression<Func<TEntity, bool>> predicate);
        TEntity Remove(TEntity entity);
    }
}
