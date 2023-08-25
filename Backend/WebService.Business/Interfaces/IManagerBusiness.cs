using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.Manager;

namespace WebService.Business.Interfaces
{
    public interface IManagerBusiness
    {
        Task<ApiResponse<List<ManagerGetDto>>> GetManagersAsync();
        Task<ApiResponse<ManagerGetDto>> GetManagerByIDAsync(int id, params string[] includeList);
        Task<ApiResponse<ManagerGetDto>> GetManagerByNameAsync(string name);
        //Task<ApiResponse<Manager>> InsertAsync(ManagerPostDto dto);
        Task<ApiResponse<ManagerGetDto>> InsertAsync(ManagerPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ManagerPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
