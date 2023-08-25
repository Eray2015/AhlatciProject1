using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.SchoolBus;

namespace WebService.Business.Interfaces
{
    public interface ISchoolBusBusiness
    {
        Task<ApiResponse<List<SchoolBusGetDto>>> GetSchoolBusesAsync();
        Task<ApiResponse<SchoolBusGetDto>> GetSchoolBusByIDAsync(int id, params string[] includeList);
        Task<ApiResponse<SchoolBusGetDto>> GetSchoolBusByNameAsync(string name);
        //Task<ApiResponse<SchoolBus>> InsertAsync(SchoolBusPostDto dto);
        Task<ApiResponse<SchoolBusGetDto>> InsertAsync(SchoolBusPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(SchoolBusPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
