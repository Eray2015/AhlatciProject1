using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Entities;

namespace WebService.Business.Interfaces
{
    public interface IBranchBusiness
    {
        Task<ApiResponse<List<BranchGetDto>>> GetBranchesAsync(params string[] includeList);
        Task<ApiResponse<BranchGetDto>> GetBranchByIDAsync(int id, params string[] includeList);
        Task<ApiResponse<BranchGetDto>> GetBranchByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<Branch>> InsertAsync(BranchPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(BranchPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
