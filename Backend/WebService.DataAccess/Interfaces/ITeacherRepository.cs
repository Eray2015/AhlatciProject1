﻿using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Entities;

namespace WebService.DataAccess.EntityFramework
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Task<Teacher> GetByIDAsync(int TeacherID);
        Task<Teacher> GetByNameAsync(string TeacherName);
        Task<List<Teacher>> GetByBranchAsync(string branch);
    }
}
