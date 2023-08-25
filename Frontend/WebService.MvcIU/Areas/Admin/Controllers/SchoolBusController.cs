using WebService.MvcUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebService.MvcUI.Areas.Admin.Extensions;
using WebService.MvcUI.Areas.Admin.Filters;
using WebService.Model.Entities;
using WebService.MvcIU.Areas.Admin.HttpApiServices;
using WebService.MvcIU.Areas.Admin.Models.Dtos.SchoolBusDtos;
using WebService.MvcUI.Areas.Admin.Models.Dtos.ManagerDtos;

namespace WebService.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class SchoolBusController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpApiService _httpApiService;

        public SchoolBusController(IWebHostEnvironment webHost, IHttpApiService httpApiService)
        {
            _webHost = webHost;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<List<SchoolBusItem>>>("/schoolbuses", token.Token);

            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> GetSchoolBus(int id)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<SchoolBusItem>>($"/schoolbuses/{id}");

            return Json(new { BusDriverName = response.Data.BusDriverName, BusDriverSurname = response.Data.BusDriverSurname, BusDriverSalary = response.Data.BusDriverSalary, BusPlate = response.Data.BusPlate });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewSchoolBusDto dto)
        {

            var postObj = new
            {
                BusDriverName = dto.BusDriverName,
                BusDriverSurname = dto.BusDriverSurname,
                BusPlate = dto.BusPlate,
                BusDriverSalary = dto.BusDriverSalary
            };

            var response = await _httpApiService.PostData<ResponseBody<SchoolBusItem>>("/schoolbuses", JsonSerializer.Serialize(postObj));

            if (dto.BusDriverName != null && dto.BusDriverSurname != null && dto.BusPlate != null && dto.BusDriverSalary != null)
            {

                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Servis Başarıyla Kaydedildi",
                          BusDriverName = response.Data.BusDriverName,
                          BusDriverSurname = response.Data.BusDriverSurname,
                          BusPlate = response.Data.BusPlate,
                          BusDriverSalary = response.Data.BusDriverSalary
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "Bir sorun oluştu." });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Tüm Bilgiler Eksiksiz Girilmelidir." });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/schoolbuses/{id}");

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }
        [HttpPut]
        public async Task<IActionResult> Update(PutSchoolBusDto dto)
        {

            var putObj = new
            {
                SchoolBusID = dto.SchoolBusID,
                BusDriverName = dto.BusDriverName,
                BusDriverSurname = dto.BusDriverSurname,
                BusPlate = dto.BusPlate,
                BusDriverSalary = dto.BusDriverSalary
            };

            var response = await _httpApiService.PutData<ResponseBody<SchoolBusItem>>("/schoolbuses", JsonSerializer.Serialize(putObj));

            if (dto.BusDriverName != null && dto.BusDriverSurname != null && dto.BusPlate != null && dto.BusDriverSalary != null && dto.SchoolBusID != null)
            {

                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Servis Başarıyla Kaydedildi",
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "Bir sorun oluştu." });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Tüm Bilgiler Eksiksiz Girilmelidir." });
            }
        }
    }
}