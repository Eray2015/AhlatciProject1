using Microsoft.Extensions.DependencyInjection;
using WebService.Business.Implementations;
using WebService.Business.Interfaces;
using WebService.Business.Profiles;
using WebService.DataAccess.EntityFramework;
using WebService.DataAccess.Implementations.EntityFramework.Repositories;
using WebService.DataAccess.Interfaces;

namespace WebService.Business
{
  public static class ServiceCollectionExtensions
  {
     public static void AddBusinessServices(this IServiceCollection services)
     {
            services.AddAutoMapper(typeof(ManagerProfile));

            services.AddScoped<IAdminBusiness, AdminBusiness>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddScoped<IBranchBusiness, BranchBusiness>();
            services.AddScoped<IBranchRepository, BranchRepository>();

            services.AddScoped<IClassBusiness, ClassBusiness>();
            services.AddScoped<IClassRepository, ClassRepository>();

            services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IManagerBusiness, ManagerBusiness>();
            services.AddScoped<IManagerRepository, ManagerRepository>();

            services.AddScoped<ISchoolBusBusiness, SchoolBusBusiness>();
            services.AddScoped<ISchoolBusRepository, SchoolBusRepository>();

            services.AddScoped<IStudentBusiness, StudentBusiness>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ITeacherBusiness, TeacherBusiness>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

     }   
  }
}
