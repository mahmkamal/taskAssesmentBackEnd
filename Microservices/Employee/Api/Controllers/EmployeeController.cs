using APIS.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Models;
using IBusiness;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;
using Ocelot.JwtAuthorize;
using System.Net;

namespace APIS.Controllers
{
    [EnableCors("TaskPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _service;
        private readonly IMapper _AutoMapper;
        public EmployeeController(IEmployee service, IMapper AutoMapper)
        {
            _service = service;
            _AutoMapper = AutoMapper;
        }
        [HttpPost]
        [Route("Save")]
        public VmEmployee Save(VmEmployee posted)
        {
            try
            {
                var _Employee = _service.Save(_AutoMapper.Map<Employee>(posted));
                _Employee.password = null;
                return _AutoMapper.Map<VmEmployee>(_Employee);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        public List<VmEmployeeTiny> GetAll()
        {
            var data = _service.GetAll();
            return _AutoMapper.Map<List<VmEmployeeTiny>>(data);
        }
        [HttpGet("{id}")]
        public VmEmployee GetById(int id)
        {
            var _Employee = _service.Get(id);
            _Employee.password = null;
            return _AutoMapper.Map<VmEmployee>(_Employee);
        }


        public class logindata
        {
            public Employee? Employee { get; set; }
            public string? Token { get; set; }
            public bool isSucceeded { get; set; }
            public bool isBlocked { get; set; }
            public bool lastLogin { get; set; }
        }
    }
}
