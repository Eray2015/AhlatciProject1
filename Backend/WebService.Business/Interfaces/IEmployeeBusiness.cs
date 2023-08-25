using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.Employee;

namespace WebService.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync();
        Task<ApiResponse<EmployeeGetDto>> GetEmployeeByIDAsync(int id, params string[] includeList);
        Task<ApiResponse<EmployeeGetDto>> GetEmployeeByNameAsync(string name, params string[] includeList);
        //Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto);
        Task<ApiResponse<EmployeeGetDto>> InsertAsync(EmployeePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
