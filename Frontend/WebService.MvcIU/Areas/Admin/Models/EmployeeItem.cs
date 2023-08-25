using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Entities
{
    public class EmployeeItem
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string? EmployeeGender { get; set; }
        public string? EmployeeJob { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int? EmployeeAge { get; set; }
        public DateTime? EmployeeDateofBirth { get; set; }
    }
}
