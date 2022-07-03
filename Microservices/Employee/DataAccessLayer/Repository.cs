using IDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> dbSet;
        IDbContext db;

        public Repository(IDbContext dbContext)
        {
            db = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Find(params object[] predicate)
        {
            return dbSet.Find(predicate);
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
        public int GetCountAllWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).Count<TEntity>();
        }
        public List<TEntity> GetAllByStatusID(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList<TEntity>();
        }
        public List<TEntity> GetAllByID(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList<TEntity>();
        }
        public TEntity GetByID(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault<TEntity>();
        }
        public int GetAllCount()
        {
            return dbSet.Count<TEntity>();
        }
        public TEntity Remove(TEntity entity)
        {
             dbSet.Remove(entity);
            return entity;
        }


    }
}
