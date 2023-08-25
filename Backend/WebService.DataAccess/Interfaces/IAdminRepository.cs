using Infrastructure.DataAccess.Interfaces;
using WebService.Model.Entities;

namespace WebService.DataAccess.Interfaces
{
  public interface IAdminRepository : IBaseRepository<Admin>
  {
    Task<Admin> GetByUserNameAndPasswordAsync(string userName,string password, params string[] includeList);
  }
}
