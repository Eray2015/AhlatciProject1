using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchGetDto>();
            CreateMap<BranchPostDto, Branch>();
            CreateMap<BranchPutDto, Branch>();
        }
    }
}
