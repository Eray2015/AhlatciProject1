using WebService.MvcUI.Areas.Admin.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebService.MvcUI.Areas.Admin.Controllers
{
  [Area("Admin")]
  [SessionAspect]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
   
  }
}
