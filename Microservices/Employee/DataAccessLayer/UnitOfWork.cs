using IDataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private IRepository<Employee> _employeeRepository;
        public UnitOfWork(IDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public IRepository<Employee> EmployeeRepository => _employeeRepository ?? (_employeeRepository = new Repository<Employee>(_dbContext));

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
