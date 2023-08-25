using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model.Dtos.Student
{
    public class StudentPutDto : IDto
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string? StudentGender { get; set; }
        public int StudentNumber { get; set; }
        public string StudentClass { get; set; }
        public int? ClassID { get; set; }
        public int? StudentAge { get; set; }
        public int? SchoolBusID { get; set; }
        public DateTime? StudentDateofBirth { get; set; }
    }
}
