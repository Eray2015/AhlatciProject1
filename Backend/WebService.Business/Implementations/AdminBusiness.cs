using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WebService.Business.CustomExceptions;
using WebService.Business.Interfaces;
using WebService.DataAccess.Interfaces;
using WebService.Model.Dtos.Admin;

namespace WebService.Business.Implementations
{
    public class AdminBusiness : IAdminBusiness
    {
        private readonly IAdminRepository _repo;
        private readonly IMapper _mapper;
        public AdminBusiness(IAdminRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ApiResponse<AdminGetDto>> LogIn(string userName, string password, params string[] includeList)
        {
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Kullanıcı Adı Boş Bırakılamaz.");
            }

            if (userName.Length <= 2)
            {
                throw new BadRequestException("Kullanıcı Adı en az 3 karakter olmalıdır.");
            }

            password = password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Şifre Boş Bırakılamaz.");
            }

            var adminUser = await _repo.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser != null)
            {
                var dto = _mapper.Map<AdminGetDto>(adminUser);
                return ApiResponse<AdminGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kullanıcı adı veya şifre yanlış.");
        }
    }
}
