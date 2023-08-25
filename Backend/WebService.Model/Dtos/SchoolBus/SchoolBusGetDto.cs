using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model.Dtos.Student;

namespace WebService.Model.Dtos.SchoolBus
{
    public class SchoolBusGetDto : IDto
    {
        public int SchoolBusID { get; set; }
        public string BusDriverName { get; set; }
        public string BusDriverSurname { get; set; }
        public string? BusDriverGender { get; set; }
        public decimal BusDriverSalary { get; set; }
        public int? BusDriverAge { get; set; }
        public DateTime? BusDriverDateofBirth { get; set; }
        public string BusPlate { get; set; }
        public List<StudentGetDto> Students { get; set; }
    }
}
