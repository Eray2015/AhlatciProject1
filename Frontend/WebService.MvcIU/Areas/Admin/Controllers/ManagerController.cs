using WebService.MvcUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebService.MvcUI.Areas.Admin.Extensions;
using WebService.MvcUI.Areas.Admin.Filters;
using WebService.Model.Entities;
using WebService.MvcIU.Areas.Admin.HttpApiServices;
using WebService.MvcUI.Areas.Admin.Models.Dtos.ManagerDtos;

namespace WebService.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class ManagerController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpApiService _httpApiService;

        public ManagerController(IWebHostEnvironment webHost, IHttpApiService httpApiService)
        {
            _webHost = webHost;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<List<ManagerItem>>>("/managers", token.Token);

            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> GetManager(int id)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<ManagerItem>>($"/managers/{id}");

            return Json(new { ManagerName = response.Data.ManagerName, ManagerSurname = response.Data.ManagerSurname, ManagerPosition = response.Data.ManagerPosition, ManagerSalary = response.Data.ManagerSalary });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewManagerDto dto)
        {

            var postObj = new
            {
                ManagerName = dto.ManagerName,
                ManagerSurname = dto.ManagerSurname,
                ManagerPosition = dto.ManagerPosition,
                ManagerSalary = dto.ManagerSalary
            };

            var response = await _httpApiService.PostData<ResponseBody<ManagerItem>>("/managers", JsonSerializer.Serialize(postObj));

            if (dto.ManagerName != null && dto.ManagerSurname != null && dto.ManagerPosition != null && dto.ManagerSalary != null)
            {

                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Menajer Başarıyla Kaydedildi",
                          ManagerName = response.Data.ManagerName,
                          ManagerSurname = response.Data.ManagerSurname,
                          ManagerPosition = response.Data.ManagerPosition,
                          ManagerSalary = response.Data.ManagerSalary
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
            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/managers/{id}");

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(PutManagerDto dto)
        {

            var putObj = new
            {
                ManagerID = dto.ManagerID,
                ManagerName = dto.ManagerName,
                ManagerSurname = dto.ManagerSurname,
                ManagerPosition = dto.ManagerPosition,
                ManagerSalary = dto.ManagerSalary
            };

            var response = await _httpApiService.PutData<ResponseBody<ManagerItem>>("/managers", JsonSerializer.Serialize(putObj));

            if (dto.ManagerName != null && dto.ManagerSurname != null && dto.ManagerPosition != null && dto.ManagerSalary != null && dto.ManagerID != null)
            {

                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Menajer Başarıyla Kaydedildi",
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