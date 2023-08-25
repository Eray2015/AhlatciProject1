using WebService.MvcUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebService.MvcUI.Areas.Admin.Extensions;
using WebService.MvcUI.Areas.Admin.Filters;
using WebService.Model.Entities;
using WebService.MvcIU.Areas.Admin.HttpApiServices;
using WebService.MvcUI.Areas.Admin.Models.Dtos.StudentDtos;
using WebService.MvcIU.Areas.Admin.Models.Dtos.StudentDtos;

namespace WebService.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpApiService _httpApiService;

        public StudentController(IWebHostEnvironment webHost, IHttpApiService httpApiService)
        {
            _webHost = webHost;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<List<StudentItem>>>("/students", token.Token);

            return View(response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> GetStudent(int id)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<StudentItem>>($"/students/{id}");

            return Json(new { StudentName = response.Data.StudentName, StudentSurname = response.Data.StudentSurname, StudentClass = response.Data.StudentClass, StudentNumber = response.Data.StudentNumber });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewStudentDto dto)
        {

                var postObj = new
                {
                    StudentName = dto.StudentName,
                    StudentSurname = dto.StudentSurname,
                    StudentClass = dto.StudentClass,
                    StudentNumber = dto.StudentNumber
                };
           
            var response = await _httpApiService.PostData<ResponseBody<StudentItem>>("/students", JsonSerializer.Serialize(postObj));
            
            if (dto.StudentName != null && dto.StudentSurname != null && dto.StudentClass != null && dto.StudentNumber != null)
            {

                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Öğrenci Başarıyla Kaydedildi",
                          StudentName = response.Data.StudentName,
                          StudentSurname = response.Data.StudentSurname,
                          StudentClass = response.Data.StudentClass,
                          StudentNumber = response.Data.StudentNumber
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "Bir sorun oluştu." });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Tüm Bilgiler Eksiksiz Girilmelidir."});
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/students/{id}");

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }
        [HttpPut]
        public async Task<IActionResult> Update(PutStudentDto dto)
        {

            var putObj = new
            {
                StudentID = dto.StudentID,
                StudentName = dto.StudentName,
                StudentSurname = dto.StudentSurname,
                StudentClass = dto.StudentClass,
                StudentNumber = dto.StudentNumber
            };

            var response = await _httpApiService.PutData<ResponseBody<StudentItem>>("/students", JsonSerializer.Serialize(putObj));

            if (dto.StudentName != null && dto.StudentSurname != null && dto.StudentClass != null && dto.StudentNumber != null && dto.StudentID != null)
            {

                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Öğrenci Başarıyla Kaydedildi",
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