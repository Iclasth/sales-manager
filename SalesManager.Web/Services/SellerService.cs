using SalesManager.Web.Data;
using SalesManager.Web.Models;

namespace SalesManager.Web.Services;

public class SellerService
{
    private readonly SalesManagerDbContext  _context;
    
    public SellerService(SalesManagerDbContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }
}