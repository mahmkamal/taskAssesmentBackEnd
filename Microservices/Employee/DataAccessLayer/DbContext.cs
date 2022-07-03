using IDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class TaskDbContext : DbContext, IDbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; }

    }
}
