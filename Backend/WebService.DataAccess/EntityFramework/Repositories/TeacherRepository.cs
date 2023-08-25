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
    public class TeacherRepository : BaseRepository<Teacher, SchoolAppContext>, ITeacherRepository
    {
        public async Task<List<Teacher>> GetByTeacherAsync(int TeacherID)
        {
            return await GetAllAsync(prd => prd.TeacherID == TeacherID);
        }

        public async Task<Teacher> GetByNameAsync(string TeacherName)
        {
            return await GetAsync(prd => prd.TeacherName.ToLower() == TeacherName.ToLower());
        }

        public async Task<Teacher> GetByIDAsync(int TeacherID)
        {
            return await GetAsync(prd => prd.TeacherID == TeacherID);
        }

        public async Task<List<Teacher>> GetByBranchAsync(string TeacherBranch)
        {
            return await GetAllAsync(prd => prd.TeacherBranch == TeacherBranch);
        }
    }
}
