using Infrastructure.Utilities.ApiResponses;
using WebService.Model.Dtos.Admin;

namespace WebService.Business.Interfaces
{
    public interface IAdminBusiness
    {
        Task<ApiResponse<AdminGetDto>> LogIn(string userName, string password, params string[] includeList);
    }
}
