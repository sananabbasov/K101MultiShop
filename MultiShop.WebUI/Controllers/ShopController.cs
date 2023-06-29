using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Entities.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiShop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ShopController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            var products = _productService.GetAllFilteredProductList("Az",0,null,null, true);

            ShopVM vm = new()
            {
                ProductList =  products,
                Categories= _categoryService.GetCategoriesByLanguage("Az")
            };

            return View(vm);
        }
    }
}

