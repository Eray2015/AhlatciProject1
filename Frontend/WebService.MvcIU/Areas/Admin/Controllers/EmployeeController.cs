using WebService.MvcUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebService.MvcUI.Areas.Admin.Extensions;
using WebService.MvcUI.Areas.Admin.Filters;
using WebService.Model.Entities;
using WebService.MvcIU.Areas.Admin.HttpApiServices;
using WebService.MvcIU.Areas.Admin.Models.Dtos.EmployeeDtos;
using WebService.MvcUI.Areas.Admin.Models.Dtos.EmployeeDtos;

namespace WebService.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpApiService _httpApiService;

        public EmployeeController(IWebHostEnvironment webHost, IHttpApiService httpApiService)
        {
            _webHost = webHost;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<List<EmployeeItem>>>("/employees", token.Token);

            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<EmployeeItem>>($"/employees/{id}");

            return Json(new { EmployeeName = response.Data.EmployeeName, EmployeeSurname = response.Data.EmployeeSurname, EmployeeJob = response.Data.EmployeeJob, EmployeeSalary = response.Data.EmployeeSalary });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewEmployeeDto dto)
        {

            var postObj = new
            {
                EmployeeName = dto.EmployeeName,
                EmployeeSurname = dto.EmployeeSurname,
                EmployeeJob = dto.EmployeeJob,
                EmployeeSalary = dto.EmployeeSalary
            };

            var response = await _httpApiService.PostData<ResponseBody<EmployeeItem>>("/employees", JsonSerializer.Serialize(postObj));

            if (dto.EmployeeName != null && dto.EmployeeSurname != null && dto.EmployeeJob != null && dto.EmployeeSalary != null)
            {

                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Personel Başarıyla Kaydedildi",
                          EmployeeName = response.Data.EmployeeName,
                          EmployeeSurname = response.Data.EmployeeSurname,
                          EmployeeJob = response.Data.EmployeeJob,
                          EmployeeSalary = response.Data.EmployeeSalary
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
            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/employees/{id}");

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }
        [HttpPut]
        public async Task<IActionResult> Update(PutEmployeeDto dto)
        {

            var putObj = new
            {
                EmployeeID = dto.EmployeeID,
                EmployeeName = dto.EmployeeName,
                EmployeeSurname = dto.EmployeeSurname,
                EmployeeJob = dto.EmployeeJob,
                EmployeeSalary = dto.EmployeeSalary
            };

            var response = await _httpApiService.PutData<ResponseBody<EmployeeItem>>("/employees", JsonSerializer.Serialize(putObj));

            if (dto.EmployeeName != null && dto.EmployeeSurname != null && dto.EmployeeJob != null && dto.EmployeeSalary != null && dto.EmployeeID != null)
            {

                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Personel Başarıyla Kaydedildi",
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