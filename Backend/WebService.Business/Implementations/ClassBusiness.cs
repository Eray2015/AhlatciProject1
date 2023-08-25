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
using WebService.Model.Dtos.Class;
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class ClassBusiness : IClassBusiness
    {
        private readonly IClassRepository _repo;
        private readonly IMapper _mapper;
        public ClassBusiness(IClassRepository repo, IMapper mapper)
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
            var class1 = await _repo.GetByIDAsync(id);
            if (class1 != null)
            {
                await _repo.DeleteAsync(class1);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Silinecek olan içerik bulunamadı.");
        }

        public async Task<ApiResponse<List<ClassGetDto>>> GetClassesAsync()
        {
            var branches = await _repo.GetAllAsync();
            if (branches != null && branches.Count > 0)
            {
                var returnList = _mapper.Map<List<ClassGetDto>>(branches);
                var response = ApiResponse<List<ClassGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<ClassGetDto>> GetClassByIDAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var branch = await _repo.GetByIDAsync(id);
            if (branch != null)
            {
                var dto = _mapper.Map<ClassGetDto>(branch);
                return ApiResponse<ClassGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<ClassGetDto>> GetClassByNameAsync(string name)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var branch = await _repo.GetByNameAsync(name);
            if (branch != null)
            {
                var dto = _mapper.Map<ClassGetDto>(branch);
                return ApiResponse<ClassGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        //public async Task<ApiResponse<Class>> InsertAsync(ClassPostDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
        //    }
        //    dto.ClassName = dto.ClassName.Trim();
        //    dto.Description = dto.Description.Trim();
        //    if (dto.ClassName.Length < 2 || dto.Description.Length < 2)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
        //    }
        //    var branch = _mapper.Map<Class>(dto);
        //    var insertedClass = await _repo.InsertAsync(branch);
        //    return ApiResponse<Class>.Success(StatusCodes.Status201Created, insertedClass);
        //}

        public async Task<ApiResponse<ClassGetDto>> InsertAsync(ClassPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.ClassName = dto.ClassName.Trim();
            if (dto.ClassName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var branch = _mapper.Map<Class>(dto);
            var insertedClass = await _repo.InsertAsync(branch);

            var retCat = _mapper.Map<ClassGetDto>(insertedClass);

            return ApiResponse<ClassGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ClassPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgilerini girmelisiniz.");
            }
            if (dto.ClassID <= 0)
            {
                throw new BadRequestException("ClassID değeri 0'dan büyük olmalıdır.");
            }
            dto.ClassName = dto.ClassName.Trim();
            if (dto.ClassName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var branch = _mapper.Map<Class>(dto);
            await _repo.UpdateAsync(branch);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
