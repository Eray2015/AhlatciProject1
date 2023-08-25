
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
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> GetByIDAsync(int StudentID);
        Task<Student> GetByNameAsync(string name);
        Task<List<Student>> GetByClassAsync(string Class);
        Task<List<Student>> GetBySchoolBusAsync(int BusID);
    }
}
