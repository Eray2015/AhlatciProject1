namespace WebService.MvcUI.Areas.Admin.Models.Dtos.ManagerDtos
{
  public class PutManagerDto
  {
    public int? ManagerID { get; set; }
    public string ManagerName { get; set; }
    public string ManagerSurname { get; set; }
    public string ManagerPosition { get; set; }
    public string ManagerSalary { get; set; }
    }
}
