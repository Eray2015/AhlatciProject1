using Infrastructure.Model;

namespace WebService.Model.Entities
{
  public class Admin : IEntity
  {
    public int AdminID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool? IsActive { get; set; }
  }
}
