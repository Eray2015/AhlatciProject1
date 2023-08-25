using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Class;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassGetDto>();
            CreateMap<ClassPostDto, Class>();
            CreateMap<ClassPutDto, Class>();
        }
    }
}
