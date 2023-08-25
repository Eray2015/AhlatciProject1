using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebService.MvcUI.Areas.Admin.Filters
{
  public class SessionAspect : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      // Bu metod, bu classın attribute olarak uygulandığı action metod çalışmaya başladığında otomatik olarak tetiklenecektir. 

      var sessionJson = context.HttpContext.Session.GetString("ActiveAdminUser");

      if (string.IsNullOrEmpty(sessionJson))
      {
        context.Result = new RedirectToActionResult("LogIn", "Authentication", null);
      }
    }
  }
}
