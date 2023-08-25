using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Class;

namespace WebService.Business.Interfaces
{
    public interface IClassBusiness
    {
        Task<ApiResponse<List<ClassGetDto>>> GetClassesAsync();
        Task<ApiResponse<ClassGetDto>> GetClassByIDAsync(int id);
        Task<ApiResponse<ClassGetDto>> GetClassByNameAsync(string name);
        //Task<ApiResponse<Class>> InsertAsync(ClassPostDto dto);
        Task<ApiResponse<ClassGetDto>> InsertAsync(ClassPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ClassPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
