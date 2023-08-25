using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WebService.Business.CustomExceptions;
using WebService.Business.Interfaces;
using WebService.DataAccess.EntityFramework;
using WebService.Model.Dtos.Teacher;
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class TeacherBusiness : ITeacherBusiness
    {
        private readonly ITeacherRepository _repo;
        private readonly IMapper _mapper;
        public TeacherBusiness(ITeacherRepository repo, IMapper mapper)
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
            var teacher = await _repo.GetByIDAsync(id);
            if (teacher != null)
            {

                await _repo.DeleteAsync(teacher);
                //await _repo.UpdateAsync(teacher);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<TeacherGetDto>>> GetTeachersAsync()
        {
            var teachers = await _repo.GetAllAsync();
            if (teachers != null && teachers.Count > 0)
            {
                var returnList = _mapper.Map<List<TeacherGetDto>>(teachers);
                var response = ApiResponse<List<TeacherGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<TeacherGetDto>> GetTeacherByIDAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var teacher = await _repo.GetByIDAsync(id);
            if (teacher != null)
            {
                var dto = _mapper.Map<TeacherGetDto>(teacher);
                return ApiResponse<TeacherGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<TeacherGetDto>> GetTeacherByNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var teacher = await _repo.GetByNameAsync(name);
            if (teacher != null)
            {
                var dto = _mapper.Map<TeacherGetDto>(teacher);
                return ApiResponse<TeacherGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        //public async Task<ApiResponse<Teacher>> InsertAsync(TeacherPostDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
        //    }
        //    dto.TeacherName = dto.TeacherName.Trim();
        //    dto.Description = dto.Description.Trim();
        //    if (dto.TeacherName.Length < 2 || dto.Description.Length < 2)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
        //    }
        //    var teacher = _mapper.Map<Teacher>(dto);
        //    var insertedTeacher = await _repo.InsertAsync(teacher);
        //    return ApiResponse<Teacher>.Success(StatusCodes.Status201Created, insertedTeacher);
        //}

        public async Task<ApiResponse<TeacherGetDto>> InsertAsync(TeacherPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.TeacherName = dto.TeacherName.Trim();
            if (dto.TeacherName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var teacher = _mapper.Map<Teacher>(dto);
            var insertedTeacher = await _repo.InsertAsync(teacher);

            var retCat = _mapper.Map<TeacherGetDto>(insertedTeacher);

            return ApiResponse<TeacherGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(TeacherPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgilerini girmelisiniz.");
            }
            if (dto.TeacherID <= 0)
            {
                throw new BadRequestException("TeacherID değeri 0'dan büyük olmalıdır.");
            }
            dto.TeacherName = dto.TeacherName.Trim();
            if (dto.TeacherName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var teacher = _mapper.Map<Teacher>(dto);
            await _repo.UpdateAsync(teacher);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<TeacherGetDto>>> GetTeachersByBranchAsync(string branch)
        {
            var teachers = await _repo.GetByBranchAsync(branch);
            if (teachers != null && teachers.Count() > 0)
            {
                var returnList = _mapper.Map<List<TeacherGetDto>>(teachers);
                return ApiResponse<List<TeacherGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }
    }
}
