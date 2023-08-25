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
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<Manager> GetByIDAsync(int ManagerID);
        Task<Manager> GetByNameAsync(string name);
    }
}
