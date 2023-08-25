using Infrastructure.DataAccess.Implementations.EF;
using WebService.DataAccess.EntityFramework.Contexts;
using WebService.DataAccess.Interfaces;
using WebService.Model.Entities;

namespace WebService.DataAccess.Implementations.EntityFramework.Repositories
{
    public class AdminRepository : BaseRepository<Admin, SchoolAppContext>, IAdminRepository
    {
        public async Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password && x.IsActive.Value, includeList);
        }
    }
}

