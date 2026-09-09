using SalesManager.Web.Models;
using SalesManager.Web.Models.Enums;

namespace SalesManager.Web.Data;

public class SeedingService 
{
    private SalesManagerDbContext  _dbContext;

    public SeedingService(SalesManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Department.Any()
            || _dbContext.Seller.Any()
            || _dbContext.SalesRecord.Any())
        {
            return;
        }

        Department department = new Department(0, "Computers");
        Department department2 = new Department(0, "Electronics");
        Department department3 = new Department(0, "Fashion");
        Department department4 = new Department(0, "Books");
        
        Seller seller1 = new Seller(0, "Yuri Alberto", "y9@gmail.com", new DateTime(1999, 02, 02), 2000.00M, department4);
        Seller seller2 = new Seller(0, "Memphis Depay", "memphis@gmail.com", new DateTime(1994, 02, 13), 3500.00M, department);
        Seller seller3 = new Seller(0, "Rodrigo Garro", "garro@gmail.com", new DateTime(1998, 01, 04), 3000.00M, department2);
        Seller seller4 = new Seller(0, "Angel Romero", "romero@gmail.com", new DateTime(1992, 07, 04), 2500.00M, department3);
        Seller seller5 = new Seller(0, "Hugo Souza", "hugo@gmail.com", new DateTime(1999, 01, 31), 2200.00M, department);

        // 3. Vendas (SalesRecords)
        SalesRecord sale1 = new SalesRecord(0, new DateTime(2026, 08, 14), 2592.00M, SalesStatus.Billed, seller1);
        SalesRecord sale2 = new SalesRecord(0, new DateTime(2026, 08, 15), 1200.50M, SalesStatus.Billed, seller2);
        SalesRecord sale3 = new SalesRecord(0, new DateTime(2026, 08, 18), 3400.00M, SalesStatus.Billed, seller3);
        SalesRecord sale4 = new SalesRecord(0, new DateTime(2026, 08, 20), 450.00M, SalesStatus.Pending, seller4);
        SalesRecord sale5 = new SalesRecord(0, new DateTime(2026, 08, 21), 1800.00M, SalesStatus.Billed, seller5);
        SalesRecord sale6 = new SalesRecord(0, new DateTime(2026, 08, 22), 990.00M, SalesStatus.Cancelled, seller1);
        SalesRecord sale7 = new SalesRecord(0, new DateTime(2026, 08, 25), 5200.00M, SalesStatus.Billed, seller2);
        SalesRecord sale8 = new SalesRecord(0, new DateTime(2026, 08, 26), 1300.00M, SalesStatus.Pending, seller3);

        // Adiciona todas as coleções ao contexto
        _dbContext.Department.AddRange(department, department2, department3, department4);
        _dbContext.Seller.AddRange(seller1, seller2, seller3, seller4, seller5);
        _dbContext.SalesRecord.AddRange(sale1, sale2, sale3, sale4, sale5, sale6, sale7, sale8);

        // Salva as alterações no banco SQL Server
        _dbContext.SaveChanges();
    }
}