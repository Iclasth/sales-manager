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
    public IActionResult Index()
    {
        var sellers = _sellerService.FindAll();
        return View(sellers);
    }
    
    // Get
    public IActionResult Create()
    {
        var departments = _departmentService.FindAll();
        var viewModel = new SellerFormViewModel { Departments = departments };
        return View(viewModel);
    }
    
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "id not provide" });
        }
        
        var seller = _sellerService.FindById(id.Value);
        if (seller == null) return RedirectToAction(nameof(Error), new { message = "id not find" });
        
        return View(seller);
        
            
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _sellerService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "id not provide" });
        }
        
        var seller = _sellerService.FindById(id.Value);
        if (seller == null) return RedirectToAction(nameof(Error), new { message = "id not find" });
        
        return View(seller);
    }

    
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();

        var seller = _sellerService.FindById(id.Value);

        if (seller == null)
        {
            return RedirectToAction(nameof(Error), new { message = "id not provide" });
        }

        List<Department> departments = _departmentService.FindAll();
        SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Seller seller)
    {
        if(id != seller.Id) return BadRequest();

        try
        {
            _sellerService.Update(seller);
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