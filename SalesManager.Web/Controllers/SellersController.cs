using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesManager.Web.Models;
using SalesManager.Web.Models.ViewModels;
using SalesManager.Web.Services;
using SalesManager.Web.Services.Exceptions;

namespace SalesManager.Web.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;
    private readonly DepartmentService _departmentService;

    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
        _sellerService = sellerService;
        _departmentService = departmentService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var sellers = await _sellerService.FindAllAsync();
        return View(sellers);
    }
    
    // Get
    public async Task<IActionResult> Create()
    {
        var departments = await _departmentService.FindAllAsync();
        var viewModel = new SellerFormViewModel { Departments = departments };
        return View(viewModel);
    }
    
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Seller seller)
    {
        if (ModelState.IsValid)
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }
        await _sellerService.InsertAsync(seller);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "id not provide" });
        }
        
        var seller = await _sellerService.FindByIdAsync(id.Value);
        if (seller == null) return RedirectToAction(nameof(Error), new { message = "id not find" });
        
        return View(seller);
        
            
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException e)
        {
            return RedirectToAction(nameof(Error), new { message = e.Message });
        }
        
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "id not provide" });
        }
        
        var seller = await _sellerService.FindByIdAsync(id.Value);
        if (seller == null) return RedirectToAction(nameof(Error), new { message = "id not find" });
        
        return View(seller);
    }

    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var seller = await _sellerService.FindByIdAsync(id.Value);

        if (seller == null)
        {
            return RedirectToAction(nameof(Error), new { message = "id not provide" });
        }

        List<Department> departments = await _departmentService.FindAllAsync();
        SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Seller seller)
    {
        
        if (ModelState.IsValid)
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }
        
        if(id != seller.Id) return BadRequest();

        try
        {
            await _sellerService.UpdateAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        catch (ApplicationException e)
        {
            return RedirectToAction(nameof(Error), new { message = e.Message });
        }
    }

    public IActionResult Error(string message)
    {
        var viewModel = new ErrorViewModel()
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(viewModel);
    }
}