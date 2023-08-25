using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.DataAccess.EntityFramework.Contexts;
using WebService.DataAccess.EntityFramework;
using WebService.Model.Entities;

namespace WebService.DataAccess.Implementations.EntityFramework.Repositories
{
    public class StudentRepository : BaseRepository<Student, SchoolAppContext>, IStudentRepository
    {
        public async Task<List<Student>> GetByStudentAsync(int StudentID)
        {
            return await GetAllAsync(prd => prd.StudentID == StudentID);
        }

        public async Task<Student> GetByNameAsync(string StudentName)
        {
            return await GetAsync(prd => prd.StudentName.ToLower() == StudentName.ToLower());
        }

        public async Task<Student> GetByIDAsync(int StudentID)
        {
            return await GetAsync(prd => prd.StudentID == StudentID);
        }
        public async Task<List<Student>> GetByClassAsync(string StudentClass)
        {
            return await GetAllAsync(prd => prd.StudentClass == StudentClass);
        }

 //       public async Task<List<Student>> GetByClassAsync(string Class)
 //       {
 //          return await GetAllAsync(prd => prd.StudentClass == Class);
 //       }

        public async Task<List<Student>> GetBySchoolBusAsync(int BusID)
        {
            return await GetAllAsync(prd => prd.SchoolBusID == BusID);
        }
    }
}
