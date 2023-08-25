using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Dtos.Branch
{
    public class BranchPostDto : IDto
    {
        public string BranchName { get; set; }
    }
}
