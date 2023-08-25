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
    public class BranchRepository : BaseRepository<Branch, SchoolAppContext>, IBranchRepository
    {
        public async Task<List<Branch>> GetByBranchAsync(int BranchID, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.BranchID == BranchID, includeList);
        }

        public async Task<Branch> GetByIDAsync(int BranchID)
        {
            return await GetAsync(prd => prd.BranchID == BranchID);
        }
        public async Task<Branch> GetByNameAsync(string name)
        {
            return await GetAsync(prd => prd.BranchName.ToLower() == name.ToLower());
        }
    }
}
