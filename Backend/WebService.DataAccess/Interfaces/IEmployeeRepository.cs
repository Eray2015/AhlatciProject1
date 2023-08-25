using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Entities;

namespace WebService.DataAccess.EntityFramework
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetByIDAsync(int EmployeeID);
        Task<Employee> GetByNameAsync(string name);
    }
}
