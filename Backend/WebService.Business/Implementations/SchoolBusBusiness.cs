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
using WebService.Model.Dtos.SchoolBus;
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class SchoolBusBusiness : ISchoolBusBusiness
    {
        private readonly ISchoolBusRepository _repo;
        private readonly IMapper _mapper;
        public SchoolBusBusiness(ISchoolBusRepository repo, IMapper mapper)
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
            var schoolbus = await _repo.GetByIDAsync(id);
            if (schoolbus != null)
            {

                await _repo.DeleteAsync(schoolbus);
                //await _repo.UpdateAsync(schoolbus);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<SchoolBusGetDto>>> GetSchoolBusesAsync()
        {
            var schoolbuses = await _repo.GetAllAsync();
            if (schoolbuses != null && schoolbuses.Count > 0)
            {
                var returnList = _mapper.Map<List<SchoolBusGetDto>>(schoolbuses);
                var response = ApiResponse<List<SchoolBusGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<SchoolBusGetDto>> GetSchoolBusByIDAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var schoolbus = await _repo.GetByIDAsync(id);
            if (schoolbus != null)
            {
                var dto = _mapper.Map<SchoolBusGetDto>(schoolbus);
                return ApiResponse<SchoolBusGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<SchoolBusGetDto>> GetSchoolBusByNameAsync(string name)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var schoolbus = await _repo.GetByNameAsync(name);
            if (schoolbus != null)
            {
                var dto = _mapper.Map<SchoolBusGetDto>(schoolbus);
                return ApiResponse<SchoolBusGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        //public async Task<ApiResponse<SchoolBus>> InsertAsync(SchoolBusPostDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
        //    }
        //    dto.SchoolBusName = dto.SchoolBusName.Trim();
        //    dto.Description = dto.Description.Trim();
        //    if (dto.SchoolBusName.Length < 2 || dto.Description.Length < 2)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
        //    }
        //    var schoolbus = _mapper.Map<SchoolBus>(dto);
        //    var insertedSchoolBus = await _repo.InsertAsync(schoolbus);
        //    return ApiResponse<SchoolBus>.Success(StatusCodes.Status201Created, insertedSchoolBus);
        //}

        public async Task<ApiResponse<SchoolBusGetDto>> InsertAsync(SchoolBusPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.BusDriverName = dto.BusDriverName.Trim();
            if (dto.BusDriverName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var schoolbus = _mapper.Map<SchoolBus>(dto);
            var insertedSchoolBus = await _repo.InsertAsync(schoolbus);

            var retCat = _mapper.Map<SchoolBusGetDto>(insertedSchoolBus);

            return ApiResponse<SchoolBusGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(SchoolBusPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgilerini yollamalısınız.");
            }
            if (dto.SchoolBusID <= 0)
            {
                throw new BadRequestException("SchoolBusID değeri 0'dan büyük olmalıdır.");
            }
            dto.BusDriverName = dto.BusDriverName.Trim();
            if (dto.BusDriverName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var schoolbus = _mapper.Map<SchoolBus>(dto);
            await _repo.UpdateAsync(schoolbus);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
