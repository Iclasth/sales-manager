using Microsoft.EntityFrameworkCore;
using SalesManager.Web.Models;

namespace SalesManager.Web.Data;

public class SalesManagerDbContext : DbContext
{
    public  SalesManagerDbContext(DbContextOptions<SalesManagerDbContext> options)
        : base(options)
    {}
    
    public DbSet<Department> Department { get; set; }
    public DbSet<SalesRecord>  SalesRecord { get; set; }
    public DbSet<Seller>  Seller { get; set; }
}