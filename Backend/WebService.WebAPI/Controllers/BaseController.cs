using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace WebService.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction] // Bu bir endpoint değil, dolayısıyla clientlar buraya erişemezler
        public IActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
            {
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            }
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
