using Microsoft.EntityFrameworkCore;

namespace EmployeeValidation.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }
        public DbSet<Sales> Sales { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DOB = new DateTime(1985, 5, 15),
                    DateOfHire = new DateTime(2010, 6, 1),
                    ManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    DOB = new DateTime(1990, 8, 22),
                    DateOfHire = new DateTime(2015, 9, 15),
                    ManagerId = 1
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Bob",
                    LastName = "Jones",
                    DOB = new DateTime(1979, 1, 5),
                    DateOfHire = new DateTime(2005, 3, 26),
                    ManagerId = 1
                });
            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 4,
                    Year = 2021,
                    Amount = 23456,
                    EmployeeId = 2
                },
                new Sales
                {
                    SalesId = 2,
                    Quarter = 1,
                    Year = 2022,
                    Amount = 34567,
                    EmployeeId = 2
                },
                new Sales
                {
                    SalesId = 3,
                    Quarter = 4,
                    Year = 2021,
                    Amount = 19867,
                    EmployeeId = 3
                },
                new Sales
                {
                    SalesId = 4,
                    Quarter = 1,
                    Year = 2022,
                    Amount = 45678,
                    EmployeeId = 3
                });
        }
    }
}
