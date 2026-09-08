using SalesManager.Web.Data;
using SalesManager.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesManager.Web.Services;

public class DepartmentService
{
    private readonly SalesManagerDbContext  _context;
    
    public DepartmentService(SalesManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> FindAllAsync()
    {
        return await _context.Department.OrderBy(d => d.Name).ToListAsync();
    }
}