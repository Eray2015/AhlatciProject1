using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Business.CustomExceptions;
using WebService.Business.Interfaces;
using WebService.DataAccess.EntityFramework;
using WebService.Model.Dtos.Class;
using WebService.Model.Dtos.Student;
using WebService.Model.Dtos.Teacher;
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;
        public StudentBusiness(IStudentRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var student = await _repo.GetByIDAsync(id);
            if (student != null)
            {

                await _repo.DeleteAsync(student);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<StudentGetDto>>> GetStudentsAsync()
        {
            var categories = await _repo.GetAllAsync();
            if (categories != null && categories.Count > 0)
            {
                var returnList = _mapper.Map<List<StudentGetDto>>(categories);
                var response = ApiResponse<List<StudentGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<StudentGetDto>> GetStudentByIDAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var student = await _repo.GetByIDAsync(id);
            if (student != null)
            {
                var dto = _mapper.Map<StudentGetDto>(student);
                return ApiResponse<StudentGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<StudentGetDto>> GetStudentByNameAsync(string name)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var student = await _repo.GetByNameAsync(name);
            if (student != null)
            {
                var dto = _mapper.Map<StudentGetDto>(student);
                return ApiResponse<StudentGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        //public async Task<ApiResponse<Student>> InsertAsync(StudentPostDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
        //    }
        //    dto.StudentName = dto.StudentName.Trim();
        //    dto.Description = dto.Description.Trim();
        //    if (dto.StudentName.Length < 2 || dto.Description.Length < 2)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
        //    }
        //    var student = _mapper.Map<Student>(dto);
        //    var insertedStudent = await _repo.InsertAsync(student);
        //    return ApiResponse<Student>.Success(StatusCodes.Status201Created, insertedStudent);
        //}

        public async Task<ApiResponse<StudentGetDto>> InsertAsync(StudentPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.StudentName = dto.StudentName.Trim();
            if (dto.StudentName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var student = _mapper.Map<Student>(dto);
            var insertedStudent = await _repo.InsertAsync(student);

            var retCat = _mapper.Map<StudentGetDto>(insertedStudent);

            return ApiResponse<StudentGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(StudentPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgilerini yollamalısınız.");
            }
            if (dto.StudentID <= 0)
            {
                throw new BadRequestException("StudentID değeri 0'dan büyük olmalıdır.");
            }
            dto.StudentName = dto.StudentName.Trim();
            if (dto.StudentName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var student = _mapper.Map<Student>(dto);
            await _repo.UpdateAsync(student);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
        public async Task<ApiResponse<List<StudentGetDto>>> GetStudentsByClassAsync(string Class)
        {
            var students = await _repo.GetByClassAsync(Class);
            if (students != null && students.Count() > 0)
            {
                var returnList = _mapper.Map<List<StudentGetDto>>(students);
                return ApiResponse<List<StudentGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }
        public async Task<ApiResponse<List<StudentGetDto>>> GetStudentsBySchoolBusAsync(int BusID)
        {
            var schoolbuses = await _repo.GetBySchoolBusAsync(BusID);
            if (schoolbuses != null && schoolbuses.Count() > 0)
            {
                var returnList = _mapper.Map<List<StudentGetDto>>(schoolbuses);
                return ApiResponse<List<StudentGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

    }
}
