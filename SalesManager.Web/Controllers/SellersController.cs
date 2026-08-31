using Microsoft.AspNetCore.Mvc;
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
}