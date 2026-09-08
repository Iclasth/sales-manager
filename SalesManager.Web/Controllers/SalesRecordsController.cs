using Microsoft.AspNetCore.Mvc;

namespace SalesManager.Web.Controllers;

public class SalesRecordsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult SimpleSearch()
    {
        return View();
    }
    
    public IActionResult GroupingSearch()
    {
        return View();
    }
}