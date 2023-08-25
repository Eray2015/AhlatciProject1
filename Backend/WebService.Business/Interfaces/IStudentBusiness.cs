using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.Student;
using WebService.Model.Dtos.Teacher;

namespace WebService.Business.Interfaces
{
    public interface IStudentBusiness
    {
        Task<ApiResponse<List<StudentGetDto>>> GetStudentsAsync();
        Task<ApiResponse<StudentGetDto>> GetStudentByIDAsync(int id, params string[] includeList);
        Task<ApiResponse<StudentGetDto>> GetStudentByNameAsync(string name);
        Task<ApiResponse<List<StudentGetDto>>> GetStudentsByClassAsync(string Class);
        Task<ApiResponse<List<StudentGetDto>>> GetStudentsBySchoolBusAsync(int BusID);
        //Task<ApiResponse<Student>> InsertAsync(StudentPostDto dto);
        Task<ApiResponse<StudentGetDto>> InsertAsync(StudentPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(StudentPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
