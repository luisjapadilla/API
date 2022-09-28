using Microsoft.EntityFrameworkCore;

namespace WebhelpAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } 

        public DbSet<AreaType> AreaTypes { get; set; }  
        
        public DbSet<IdentificationType> IdType { get; set; }
    }
}
