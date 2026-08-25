using Microsoft.EntityFrameworkCore;

namespace SalesManager.Web.Data;

public class SalesManagerDbContext : DbContext
{
    public  SalesManagerDbContext(DbContextOptions<SalesManagerDbContext> options)
        : base(options)
    {}
    
    public DbSet<SalesManager.Web.Models.Department> Department { get; set; }
}