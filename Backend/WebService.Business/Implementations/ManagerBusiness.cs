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
using WebService.Model.Dtos.Branch;
using WebService.Model.Dtos.Manager;
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class ManagerBusiness : IManagerBusiness
    {
        private readonly IManagerRepository _repo;
        private readonly IMapper _mapper;
        public ManagerBusiness(IManagerRepository repo, IMapper mapper)
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
            var manager = await _repo.GetByIDAsync(id);
            if (manager != null)
            {

                await _repo.DeleteAsync(manager);
                //await _repo.UpdateAsync(manager);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<ManagerGetDto>>> GetManagersAsync()
        {
            var managers = await _repo.GetAllAsync();
            if (managers != null && managers.Count > 0)
            {
                var returnList = _mapper.Map<List<ManagerGetDto>>(managers);
                var response = ApiResponse<List<ManagerGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<ManagerGetDto>> GetManagerByIDAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var manager = await _repo.GetByIDAsync(id);
            if (manager != null)
            {
                var dto = _mapper.Map<ManagerGetDto>(manager);
                return ApiResponse<ManagerGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<ManagerGetDto>> GetManagerByNameAsync(string name)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var manager = await _repo.GetByNameAsync(name);
            if (manager != null)
            {
                var dto = _mapper.Map<ManagerGetDto>(manager);
                return ApiResponse<ManagerGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        //public async Task<ApiResponse<Manager>> InsertAsync(ManagerPostDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
        //    }
        //    dto.ManagerName = dto.ManagerName.Trim();
        //    dto.Description = dto.Description.Trim();
        //    if (dto.ManagerName.Length < 2 || dto.Description.Length < 2)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
        //    }
        //    var manager = _mapper.Map<Manager>(dto);
        //    var insertedManager = await _repo.InsertAsync(manager);
        //    return ApiResponse<Manager>.Success(StatusCodes.Status201Created, insertedManager);
        //}

        public async Task<ApiResponse<ManagerGetDto>> InsertAsync(ManagerPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.ManagerName = dto.ManagerName.Trim();
            if (dto.ManagerName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var manager = _mapper.Map<Manager>(dto);
            var insertedManager = await _repo.InsertAsync(manager);

            var retCat = _mapper.Map<ManagerGetDto>(insertedManager);

            return ApiResponse<ManagerGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ManagerPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            if (dto.ManagerID <= 0)
            {
                throw new BadRequestException("ManagerID değeri 0'dan büyük olmalıdır.");
            }
            dto.ManagerName = dto.ManagerName.Trim();
            if (dto.ManagerName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin isim kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var manager = _mapper.Map<Manager>(dto);
            await _repo.UpdateAsync(manager);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
