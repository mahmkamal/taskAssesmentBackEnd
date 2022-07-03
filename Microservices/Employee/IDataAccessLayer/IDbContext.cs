using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IDataAccessLayer
{

    public interface IDbContext  :IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        //DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

    }
}
