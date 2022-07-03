using BCrypt.Net;
using IBusiness;
using IDataAccessLayer;
using Models;

namespace Business
{
    public class EmployeeService: IEmployee
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Employee Get(int id)
        {
            var record = _unitOfWork.EmployeeRepository.Find(id);
            return record!=null && record.isActive? record: null;
        }

        public List<Employee> GetAll()
        {
            return _unitOfWork.EmployeeRepository.Where(M => M.isActive).OrderByDescending(M => M.creationDate).ToList();
        }

        public virtual Employee Save(Employee Employee)
        {
            try
            {
                DateTime SysDate = DateTime.Now;
                var original = Employee.id == 0 ? null : _unitOfWork.EmployeeRepository.Find(Employee.id);
                bool IsNew = original == null;
                if (!IsNew && original != null && original.isActive)
                {
                    original.editDate = SysDate;
                    original.editUser = Employee.creationUser;
                }
                if (IsNew)
                {
                    original = new Employee()
                    {
                        creationUser = Employee.creationUser,
                        password = BCrypt.Net.BCrypt.HashPassword(Employee.password),
                        creationDate = SysDate,
                        isActive = true
                    };
                    _unitOfWork.EmployeeRepository.Add(original);
                }
                if (IsNew || Employee.isActive)
                {
                    original.userName = Employee.userName;
                    original.fullName = Employee.fullName;
                    original.email = Employee.email;
                    if (Employee.password != null)
                        original.password = BCrypt.Net.BCrypt.HashPassword(Employee.password);
                }
                else
                {
                    original.isActive = false;
                }
                _unitOfWork.Commit();
                return original;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}