namespace WebService.MvcUI.Areas.Admin.Models.Dtos.ManagerDtos
{
  public class PutSchoolBusDto
  {
    public int? SchoolBusID { get; set; }
    public string BusDriverName { get; set; }
    public string BusDriverSurname { get; set; }
    public string BusPlate { get; set; }
    public string BusDriverSalary { get; set; }
    }
}
