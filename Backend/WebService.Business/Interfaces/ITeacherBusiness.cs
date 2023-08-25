using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.Teacher;

namespace WebService.Business.Interfaces
{
    public interface ITeacherBusiness
    {
        Task<ApiResponse<List<TeacherGetDto>>> GetTeachersAsync();
        Task<ApiResponse<TeacherGetDto>> GetTeacherByIDAsync(int id, params string[] includeList);
        Task<ApiResponse<TeacherGetDto>> GetTeacherByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<List<TeacherGetDto>>> GetTeachersByBranchAsync(string branch);
        //Task<ApiResponse<Teacher>> InsertAsync(TeacherPostDto dto);
        Task<ApiResponse<TeacherGetDto>> InsertAsync(TeacherPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(TeacherPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
