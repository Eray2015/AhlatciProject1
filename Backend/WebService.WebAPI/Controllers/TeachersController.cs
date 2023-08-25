using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WebService.Business.Interfaces;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.Teacher;
using WebService.WebAPI.Controllers;

namespace WebService.DataAccess.EntityFramework
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : BaseController
    {
        private readonly ITeacherBusiness _teacherBusiness;
        public TeachersController(ITeacherBusiness teacherBusiness)
        {
            _teacherBusiness = teacherBusiness;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<TeacherGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _teacherBusiness.GetTeacherByIDAsync(id, "Teachers");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<TeacherGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var response = await _teacherBusiness.GetTeacherByNameAsync(name, "Teachers");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<TeacherGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var response = await _teacherBusiness.GetTeachersAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<TeacherGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewTeacher([FromBody] TeacherPostDto dto)
        {
            var response = await _teacherBusiness.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetByID), new { id = response.Data.TeacherID }, response);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherPutDto dto)
        {
            var response = await _teacherBusiness.UpdateAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] int id)
        {
            var response = await _teacherBusiness.DeleteAsync(id);
            return SendResponse(response);
        }
        [HttpGet("getByBranch")]
        public async Task<IActionResult> GetByBranch([FromQuery] string branch)
        {
            var response = await _teacherBusiness.GetTeachersByBranchAsync(branch);
            return SendResponse(response);
        }
    }
}
