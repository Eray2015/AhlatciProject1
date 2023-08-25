using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WebService.Business.CustomExceptions;
using WebService.Business.Interfaces;
using WebService.DataAccess.EntityFramework;
using WebService.Model.Dtos.Employee;
using WebService.Model.Entities;

namespace WebService.Business.Implementations
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeBusiness(IEmployeeRepository repo, IMapper mapper)
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
            var employee = await _repo.GetByIDAsync(id);
            if (employee != null)
            {

                await _repo.DeleteAsync(employee);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync()
        {
            var employees = await _repo.GetAllAsync();
            if (employees != null && employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);
                var response = ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<EmployeeGetDto>> GetEmployeeByIDAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ID değeri 0'dan büyük olmalıdır.");
            }
            var employee = await _repo.GetByIDAsync(id);
            if (employee != null)
            {
                var dto = _mapper.Map<EmployeeGetDto>(employee);
                return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<EmployeeGetDto>> GetEmployeeByNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var employee = await _repo.GetByNameAsync(name);
            if (employee != null)
            {
                var dto = _mapper.Map<EmployeeGetDto>(employee);
                return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        //public async Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto)
        //{
        //    if (dto == null)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
        //    }
        //    dto.EmployeeName = dto.EmployeeName.Trim();
        //    dto.Description = dto.Description.Trim();
        //    if (dto.EmployeeName.Length < 2 || dto.Description.Length < 2)
        //    {
        //        throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
        //    }
        //    var employee = _mapper.Map<Employee>(dto);
        //    var insertedEmployee = await _repo.InsertAsync(employee);
        //    return ApiResponse<Employee>.Success(StatusCodes.Status201Created, insertedEmployee);
        //}

        public async Task<ApiResponse<EmployeeGetDto>> InsertAsync(EmployeePostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgileri bulunamadı.");
            }
            dto.EmployeeName = dto.EmployeeName.Trim();
            if (dto.EmployeeName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var employee = _mapper.Map<Employee>(dto);
            var insertedEmployee = await _repo.InsertAsync(employee);

            var retCat = _mapper.Map<EmployeeGetDto>(insertedEmployee);

            return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek içeriğin bilgilerini yollamalısınız.");
            }
            if (dto.EmployeeID <= 0)
            {
                throw new BadRequestException("EmployeeID değeri 0'dan büyük olmalıdır.");
            }
            dto.EmployeeName = dto.EmployeeName.Trim();
            if (dto.EmployeeName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek içeriğin ismi en az 2 karakter uzunluğunda olmalıdır.");
            }
            var employee = _mapper.Map<Employee>(dto);
            await _repo.UpdateAsync(employee);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
