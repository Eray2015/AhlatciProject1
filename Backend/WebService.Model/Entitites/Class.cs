using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Entities
{
    public class Class : IEntity
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public List<Student> Students { get; set; }
    }
}
