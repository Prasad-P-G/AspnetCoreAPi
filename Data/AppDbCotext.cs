using EmployeePortal_Angular_CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal_Angular_CoreWebApi.Data
{
    public class AppDbCotext:DbContext
    {
        public AppDbCotext(DbContextOptions options):base(options) { }  
         
        public DbSet<Employee> Employees { get; set; }
    }
}
