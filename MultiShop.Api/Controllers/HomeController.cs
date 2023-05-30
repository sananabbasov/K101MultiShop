using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;

namespace MultiShop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getproducts")]
    public IActionResult GetAllProduct()
    {
        return Ok(_productService.GetProducts());
    }
}

