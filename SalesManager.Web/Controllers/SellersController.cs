using Microsoft.AspNetCore.Mvc;

namespace SalesManager.Web.Controllers;

public class SellersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}