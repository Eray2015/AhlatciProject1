using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.Business.Interfaces;
using WebService.Model.Dtos.Admin;

namespace WebService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminBusiness _adminBusiness;
        public AuthenticationController(IAdminBusiness adminBusiness, IConfiguration configuration)
        {
            _adminBusiness = adminBusiness;
            _configuration = configuration;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("gettoken")]
        public async Task<IActionResult> GetToken()
        {
            var accessToken = new JwtGenerator(_configuration).CreateAccessToken();
            ApiResponse<AccessToken> response = new ApiResponse<AccessToken>() { Data = accessToken, StatusCode = 200 };

            return SendResponse(response);
        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<AdminGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("logIn")]
        public async Task<IActionResult> LogIn([FromQuery] string userName, [FromQuery] string password)
        {
            var response = await _adminBusiness.LogIn(userName, password);
            return SendResponse(response);
        }
    }
}