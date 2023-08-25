using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Entities
{
    public class ManagerItem
    {
        public int? ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerPosition { get; set; }
        public decimal ManagerSalary { get; set; }
    }
}
