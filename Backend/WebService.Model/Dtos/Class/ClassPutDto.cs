using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Dtos.Class
{
    public class ClassPutDto : IDto
    {
        public string ClassName { get; set; }
        public int ClassID { get; set; }
    }
}
