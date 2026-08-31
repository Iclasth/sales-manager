using Microsoft.AspNetCore.Mvc;
using SalesManager.Web.Models;
using SalesManager.Web.Services;

namespace SalesManager.Web.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;

    public SellersController(SellerService sellerService)
    {
        _sellerService = sellerService;
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
        return View();
    }
    
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }
}