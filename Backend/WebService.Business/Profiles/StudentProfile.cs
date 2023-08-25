using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Student;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentGetDto>();
            CreateMap<StudentPostDto, Student>();
            CreateMap<StudentPutDto, Student>();
        }
    }
}
