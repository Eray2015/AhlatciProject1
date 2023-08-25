namespace WebService.MvcUI.Areas.Admin.Models.Dtos.TeacherDtos
{
  public class PutTeacherDto
  {
    public int? TeacherID { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }
    public string TeacherBranch { get; set; }
    public string TeacherSalary { get; set; }
    }
}
