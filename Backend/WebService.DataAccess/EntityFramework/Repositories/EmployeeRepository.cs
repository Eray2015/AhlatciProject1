using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.DataAccess.EntityFramework;
using WebService.DataAccess.EntityFramework.Contexts;
using WebService.Model.Entities;
using WebService.DataAccess.Interfaces;

namespace WebService.DataAccess.Implementations.EntityFramework.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, SchoolAppContext>, IEmployeeRepository
    {
        public async Task<List<Employee>> GetByEmployeeAsync(int EmployeeID)
        {
            return await GetAllAsync(prd => prd.EmployeeID == EmployeeID);
        }

        public async Task<Employee> GetByNameAsync(string EmployeeName)
        {
            return await GetAsync(prd => prd.EmployeeName.ToLower() == EmployeeName.ToLower());
        }

        public async Task<Employee> GetByIDAsync(int EmployeeID)
        {
            return await GetAsync(prd => prd.EmployeeID == EmployeeID);
        }
    }
}