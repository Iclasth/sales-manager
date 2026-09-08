using Microsoft.EntityFrameworkCore;
using SalesManager.Web.Data;
using SalesManager.Web.Models;
using SalesManager.Web.Services.Exceptions;

namespace SalesManager.Web.Services;

public class SellerService
{
    private readonly SalesManagerDbContext  _context;
    
    public SellerService(SalesManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Seller>> FindAllAsync()
    {
        return await _context.Seller.ToListAsync();
    }

    public async Task InsertAsync(Seller seller)
    {
        _context.Add(seller);
        await _context.SaveChangesAsync();
    }

    public async Task<Seller> FindByIdAsync(int id)
    {
        return await _context.Seller.Include(sl => sl.Department).FirstOrDefaultAsync(sl => sl.Id == id);
    }

    public async Task RemoveAsync(int id)
    {
        var seller = await FindByIdAsync(id);
        _context.Seller.Remove(seller);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seller seller)
    {
        bool hasAny = await _context.Seller.AnyAsync(s => s.Id == seller.Id);
        if (!hasAny)
        {
            throw new NotFoundException("Seller not found");
        }

        try
        {
            _context.Update(seller);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbConcurrencyException(e.Message);
        }
        
    }
    
}