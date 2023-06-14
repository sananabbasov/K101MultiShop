using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.ViewModels;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
    {
        _logger = logger;
        _productService = productService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {

        var categories = _categoryService.GetCategoriesByLanguage("Az");
        var recentProducts = _productService.RecentProductList("Az");
        var discountProducts = _productService.DiscountProductList("Az");
        HomeVM vm = new()
        {
            Categories = categories,
            RecentProducts = recentProducts,
            DiscountProducts = discountProducts
        };
        return View(vm);
    }

    public IActionResult Create()
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

