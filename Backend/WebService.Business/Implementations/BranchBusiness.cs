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
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class BranchBusiness : IBranchBusiness
    {
        private readonly IBranchRepository _repo;
        private readonly IMapper _mapper;
        public BranchBusiness(IBranchRepository repo, IMapper mapper)
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
            var branch = await _repo.GetByIDAsync(id);
            if (branch != null)
            {
                await _repo.DeleteAsync(branch);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Silinecek olan içerik bulunamadı.");
        }

        public async Task<ApiResponse<List<BranchGetDto>>> GetBranchesAsync(params string[] includeList)
        {
            var branches = await _repo.GetAllAsync();
            if (branches != null && branches.Count > 0)
            {
                var returnList = _mapper.Map<List<BranchGetDto>>(branches);
                var response = ApiResponse<List<BranchGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<BranchGetDto>> GetBranchByIDAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var branch = await _repo.GetByIDAsync(id);
            if (branch != null)
            {
                var dto = _mapper.Map<BranchGetDto>(branch);
                return ApiResponse<BranchGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<BranchGetDto>> GetBranchByNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var branch = await _repo.GetByNameAsync(name);
            if (branch != null)
            {
                var dto = _mapper.Map<BranchGetDto>(branch);
                return ApiResponse<BranchGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<Branch>> InsertAsync(BranchPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.BranchName = dto.BranchName.Trim();
           if (dto.BranchName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin adı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var branch = _mapper.Map<Branch>(dto);
            var insertedBranch = await _repo.InsertAsync(branch);
            return ApiResponse<Branch>.Success(StatusCodes.Status201Created, insertedBranch);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(BranchPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içerik bilgilerini girmelisiniz.");
            }
            if (dto.BranchID <= 0)
            {
                throw new BadRequestException("BranchID değeri 0'dan büyük olmalıdır.");
            }
            dto.BranchName = dto.BranchName.Trim();
            if (dto.BranchName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var branch = _mapper.Map<Branch>(dto);
            await _repo.UpdateAsync(branch);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
