using Microsoft.EntityFrameworkCore;
using WebService.Model.Entities;

namespace WebService.DataAccess.EntityFramework.Contexts
{
    public class SchoolAppContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetail>().HasNoKey();
            //modelBuilder.Entity<EmployeeTerritory>().HasKey("EmployeeId", "TerritoryId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=.\\SQLEXPRESS; Database = SchoolApp; trusted_connection = true;");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<SchoolBus> SchoolBuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
