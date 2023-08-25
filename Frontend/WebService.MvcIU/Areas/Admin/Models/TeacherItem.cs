namespace WebService.Model.Entities
{
    public class TeacherItem
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string? TeacherGender { get; set; }
        public string TeacherBranch { get; set; }
        public int? BranchID { get; set; }
        public decimal TeacherSalary { get; set; }
        public int? TeacherAge { get; set; }
        public DateTime? TeacherDateofBirth { get; set; }
    }
}
