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
    public class ManagerRepository : BaseRepository<Manager, SchoolAppContext>, IManagerRepository
    {
        public async Task<List<Manager>> GetByManagerAsync(int ManagerID, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.ManagerID == ManagerID, includeList);
        }

        public async Task<Manager> GetByNameAsync(string ManagerName)
        {
            return await GetAsync(prd => prd.ManagerName.ToLower() == ManagerName.ToLower());
        }

        public async Task<Manager> GetByIDAsync(int ManagerID)
        {
            return await GetAsync(prd => prd.ManagerID == ManagerID);
        }
    }
}
