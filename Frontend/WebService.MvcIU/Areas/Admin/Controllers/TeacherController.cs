using WebService.MvcUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebService.MvcUI.Areas.Admin.Extensions;
using WebService.MvcUI.Areas.Admin.Filters;
using WebService.Model.Entities;
using WebService.MvcIU.Areas.Admin.HttpApiServices;
using WebService.MvcIU.Areas.Admin.Models.Dtos.TeacherDtos;
using WebService.MvcUI.Areas.Admin.Models.Dtos.TeacherDtos;

namespace WebService.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class TeacherController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpApiService _httpApiService;

        public TeacherController(IWebHostEnvironment webHost, IHttpApiService httpApiService)
        {
            _webHost = webHost;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<List<TeacherItem>>>("/teachers", token.Token);

            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<TeacherItem>>($"/teachers/{id}");

            return Json(new { TeacherName = response.Data.TeacherName, TeacherSurname = response.Data.TeacherSurname, TeacherBranch = response.Data.TeacherBranch, TeacherSalary = response.Data.TeacherSalary });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewTeacherDto dto)
        {

            var postObj = new
            {
                TeacherName = dto.TeacherName,
                TeacherSurname = dto.TeacherSurname,
                TeacherBranch = dto.TeacherBranch,
                TeacherSalary = dto.TeacherSalary
            };

            var response = await _httpApiService.PostData<ResponseBody<TeacherItem>>("/teachers", JsonSerializer.Serialize(postObj));

            if (dto.TeacherName != null && dto.TeacherSurname != null && dto.TeacherBranch != null && dto.TeacherSalary != null)
            {

                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Öğretmen Başarıyla Kaydedildi",
                          TeacherName = response.Data.TeacherName,
                          TeacherSurname = response.Data.TeacherSurname,
                          TeacherBranch = response.Data.TeacherBranch,
                          TeacherSalary = response.Data.TeacherSalary
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
            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/teachers/{id}");

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }
        [HttpPut]
        public async Task<IActionResult> Update(PutTeacherDto dto)
        {

            var putObj = new
            {
                TeacherID = dto.TeacherID,
                TeacherName = dto.TeacherName,
                TeacherSurname = dto.TeacherSurname,
                TeacherBranch = dto.TeacherBranch,
                TeacherSalary = dto.TeacherSalary
            };

            var response = await _httpApiService.PutData<ResponseBody<TeacherItem>>("/teachers", JsonSerializer.Serialize(putObj));

            if (dto.TeacherName != null && dto.TeacherSurname != null && dto.TeacherBranch != null && dto.TeacherSalary != null && dto.TeacherID != null)
            {

                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Öğretmen Başarıyla Kaydedildi",
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