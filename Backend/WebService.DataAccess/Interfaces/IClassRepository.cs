using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Entities;

namespace WebService.DataAccess.EntityFramework
{
    public interface IClassRepository : IBaseRepository<Class>
    {
        Task<Class> GetByIDAsync(int ClassID);
        Task<Class> GetByNameAsync(string name);
    }
}
