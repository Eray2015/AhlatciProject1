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
    public class ClassRepository : BaseRepository<Class, SchoolAppContext>, IClassRepository
    {
        public async Task<List<Class>> GetByClassAsync(int ClassID, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.ClassID == ClassID, includeList);
        }

        public async Task<Class> GetByNameAsync(string name)
        {
            return await GetAsync(prd => prd.ClassName.ToLower() == name.ToLower());
        }

        public async Task<Class> GetByIDAsync(int ClassID)
        {
            return await GetAsync(prd => prd.ClassID == ClassID);
        }
    }
}
