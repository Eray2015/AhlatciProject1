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
    public class SchoolBusRepository : BaseRepository<SchoolBus, SchoolAppContext>, ISchoolBusRepository
    {
        public async Task<List<SchoolBus>> GetBySchoolBusAsync(int SchoolBusID)
        {
            return await GetAllAsync(prd => prd.SchoolBusID == SchoolBusID);
        }

        public async Task<SchoolBus> GetByNameAsync(string SchoolBusName)
        {
            return await GetAsync(prd => prd.BusDriverName.ToLower() == SchoolBusName.ToLower());
        }

        public async Task<SchoolBus> GetByIDAsync(int SchoolBusID)
        {
            return await GetAsync(prd => prd.SchoolBusID == SchoolBusID);
        }
    }
}
