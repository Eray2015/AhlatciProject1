using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Employee;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeePostDto, Employee>();
            CreateMap<EmployeePutDto, Employee>();
        }
    }
}
