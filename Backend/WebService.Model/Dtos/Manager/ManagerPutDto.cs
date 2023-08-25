using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Dtos.Manager
{
    public class ManagerPutDto : IDto
    {
        public int ManagerID { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerSurname { get; set; }
        public string? ManagerGender { get; set; }
        public string? ManagerPosition { get; set; }
        public decimal? ManagerSalary { get; set; }
        public int? ManagerAge { get; set; }
        public DateTime? ManagerDateofBirth { get; set; }
    }
}
