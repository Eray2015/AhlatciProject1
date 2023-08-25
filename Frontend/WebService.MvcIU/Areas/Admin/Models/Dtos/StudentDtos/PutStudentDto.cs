namespace WebService.MvcUI.Areas.Admin.Models.Dtos.StudentDtos
{
  public class PutStudentDto
  {
    public int? StudentID { get; set; }
    public string StudentName { get; set; }
    public string StudentSurname { get; set; }
    public string StudentClass { get; set; }
    public string StudentNumber { get; set; }
    }
}
