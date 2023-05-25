using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DataAccess.Abstract;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductDal _productDal;

    public HomeController(ILogger<HomeController> logger, IProductDal productDal)
    {
        _logger = logger;
        _productDal = productDal;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

