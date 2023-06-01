using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        List<ProductLanguageDTO> productLanguageDTOs = new();

        ProductLanguageDTO languageAz = new()
        {
            Name = "Salam",
            Description = "Haqqinda",
            LangCode = "az",
        };

        ProductLanguageDTO languageEn = new()
        {
            Name = "Hello",
            Description = "About",
            LangCode = "en",
        };


        productLanguageDTOs.Add(languageAz);
        productLanguageDTOs.Add(languageEn);

        ProductCreateDTO productCreateDTO = new()
        {
            ProductLanguages = productLanguageDTOs,
            Categories = new List<string>() { "Test 1", "Test 2"},
            PhotoUrl = new List<string>() { "img1.png", "img2.png" },
            Discount = 10,
            Price = 100,
            DiscountEndDate = DateTime.Now
        };


        _productService.AddProduct(productCreateDTO);



        return View();
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

