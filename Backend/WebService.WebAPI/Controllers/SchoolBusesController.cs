using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Business.Interfaces;
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.SchoolBus;
using WebService.WebAPI.Controllers;

namespace WebService.DataAccess.EntityFramework
{
    [Route("api/schoolbuses")]
    [ApiController]
    public class SchoolBusesController : BaseController
    {
        private readonly ISchoolBusBusiness _schoolbusBusiness;
        public SchoolBusesController(ISchoolBusBusiness schoolbusBusiness)
        {
            _schoolbusBusiness = schoolbusBusiness;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SchoolBusGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _schoolbusBusiness.GetSchoolBusByIDAsync(id, "SchoolBuses");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<SchoolBusGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var response = await _schoolbusBusiness.GetSchoolBusByNameAsync(name);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<SchoolBusGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetSchoolBuses()
        {
            var response = await _schoolbusBusiness.GetSchoolBusesAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<SchoolBusGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewSchoolBus([FromBody] SchoolBusPostDto dto)
        {
            var response = await _schoolbusBusiness.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetByID), new { id = response.Data.SchoolBusID}, response);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateSchoolBus([FromBody] SchoolBusPutDto dto)
        {
            var response = await _schoolbusBusiness.UpdateAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolBus([FromRoute] int id)
        {
            var response = await _schoolbusBusiness.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
