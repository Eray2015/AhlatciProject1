using Infrastructure.DataAccess.Interfaces;
using WebService.Model.Entities;

namespace WebService.DataAccess.EntityFramework
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Task<Branch> GetByIDAsync(int BranchID);
        Task<Branch> GetByNameAsync(string BranchName);
    }
}
