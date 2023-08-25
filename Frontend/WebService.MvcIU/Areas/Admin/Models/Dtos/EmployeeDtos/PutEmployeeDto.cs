namespace WebService.MvcUI.Areas.Admin.Models.Dtos.EmployeeDtos
{
  public class PutEmployeeDto
  {
    public int? EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeeJob { get; set; }
    public string EmployeeSalary { get; set; }
    }
}
