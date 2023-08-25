namespace WebService.Model.Entities
{
    public class StudentItem
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string? StudentGender { get; set; }
        public int StudentNumber { get; set; }
        public string? StudentClass { get; set; }
        public int? ClassID { get; set; }
        public int? StudentAge { get; set; }
        public int? SchoolBusID { get; set; }
        public DateTime? StudentDateofBirth { get; set; }
    }
}
