using Microsoft.EntityFrameworkCore;
using SalesManager.Web.Data;
using SalesManager.Web.Models;

namespace SalesManager.Web.Services;

public class SalesRecordService
{
    private readonly SalesManagerDbContext _dbContext;
    
    public SalesRecordService(SalesManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        var result = from salesR in _dbContext.SalesRecord select salesR;

        if (minDate.HasValue)
        {
            result = result.Where(x => x.Date >= minDate.Value);
        }
        if (maxDate.HasValue)
        {
            result = result.Where(x => x.Date <= maxDate.Value);
        }
        
        return await result
            .Include(x => x.Seller)
            .Include(x => x.Seller.Department)
            .OrderBy(x => x.Date)
            .ToListAsync();
    }
}