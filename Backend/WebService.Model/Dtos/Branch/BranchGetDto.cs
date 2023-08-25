using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Teacher;

namespace WebService.Model.Dtos.Branch
{
    public class BranchGetDto : IDto
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        
        // Navigation Property
        public List<TeacherGetDto> Teachers { get; set; }
    }
}
