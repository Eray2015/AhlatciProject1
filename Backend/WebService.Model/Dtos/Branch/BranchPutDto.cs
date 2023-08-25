using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Dtos.Branch
{
    public class BranchPutDto : IDto
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
