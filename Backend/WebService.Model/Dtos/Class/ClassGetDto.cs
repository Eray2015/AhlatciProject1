using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Student;
using WebService.Model.Dtos.Teacher;

namespace WebService.Model.Dtos.Class
{
    public class ClassGetDto : IDto
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public List<StudentGetDto> Students { get; set; }
    }
}
