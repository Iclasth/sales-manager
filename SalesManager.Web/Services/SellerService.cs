using Microsoft.EntityFrameworkCore;
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

    public void Insert(Seller seller)
    {
        _context.Add(seller);
        _context.SaveChanges();
    }

    public Seller FindById(int id)
    {
        return _context.Seller.Include(sl => sl.Department).FirstOrDefault(sl => sl.Id == id);
    }

    public void Remove(int id)
    {
        var seller = FindById(id);
        _context.Seller.Remove(seller);
        _context.SaveChanges();
    }
    
}