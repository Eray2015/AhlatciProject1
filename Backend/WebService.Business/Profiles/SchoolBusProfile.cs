using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.SchoolBus;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class SchoolBusProfile : Profile
    {
        public SchoolBusProfile()
        {
            CreateMap<SchoolBus, SchoolBusGetDto>();
            CreateMap<SchoolBusPostDto, SchoolBus>();
            CreateMap<SchoolBusPutDto, SchoolBus>();
        }
    }
}
