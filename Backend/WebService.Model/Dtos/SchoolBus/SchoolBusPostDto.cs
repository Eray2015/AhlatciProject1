using Infrastructure.Model;

namespace WebService.Model.Dtos.SchoolBus
{
  public class SchoolBusPostDto : IDto
  {
        public int SchoolBusID { get; set; }
        public string BusDriverName { get; set; }
        public string BusDriverSurname { get; set; }
        public string? BusDriverGender { get; set; }
        public decimal BusDriverSalary { get; set; }
        public int? BusDriverAge { get; set; }
        public DateTime? BusDriverDateofBirth { get; set; }
        public string BusPlate { get; set; }
    }
}
