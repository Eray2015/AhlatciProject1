using AutoMapper;
using WebService.Model.Dtos.Admin;
using WebService.Model.Entities;

namespace WebService.Business.Profiles
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<Admin, AdminGetDto>();
        }
    }
}