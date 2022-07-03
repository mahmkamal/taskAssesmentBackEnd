using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIS.Models;

namespace APIs.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, VmEmployee>().ReverseMap();
            CreateMap<Employee, VmEmployeeTiny>().ReverseMap();
        }
    }
}
