using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Teacher;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherGetDto>();
            CreateMap<TeacherPostDto, Teacher>();
            CreateMap<TeacherPutDto, Teacher>();
        }
    }
}
