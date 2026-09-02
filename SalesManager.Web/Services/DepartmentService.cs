using SalesManager.Web.Data;
using SalesManager.Web.Models;

namespace SalesManager.Web.Services;

public class DepartmentService
{
    private readonly SalesManagerDbContext  _context;
    
    public DepartmentService(SalesManagerDbContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(d => d.Name).ToList();
    }
}