using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Manager;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<Manager, ManagerGetDto>();
            CreateMap<ManagerPostDto, Manager>();
            CreateMap<ManagerPutDto, Manager>();
        }
    }
}
