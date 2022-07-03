using System;
using Models;

namespace IDataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();        
        IRepository<Employee> EmployeeRepository { get; }
    }
}

