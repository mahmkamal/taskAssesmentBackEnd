using IBusiness;
using IDataAccessLayer;
using Models;
using Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Business.Validators
{
    public class EmployeeValidator : EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override Employee Save(Employee Employee)
        {
            if (Employee.isActive == true)
            {
                #region Validation
                if (!Employee.email.ValidPattern(Patterns.email))
                {
                    throw new Exception("Invalid Input");
                }
                if (!Employee.userName.ValidPattern(Patterns.Alphanumeric))
                {
                    throw new Exception("Invalid Input");
                }
                if (!Employee.fullName.ValidPattern(Patterns.Alphanumeric))
                {
                    throw new Exception("Invalid Input");
                }
                #endregion
            }
            return base.Save(Employee);
        }
    }
}
