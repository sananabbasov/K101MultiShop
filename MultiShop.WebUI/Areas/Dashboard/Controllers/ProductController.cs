using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Business.Abstract;
using MultiShop.Entities.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiShop.WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment env)
        {
            _productService = productService;
            _categoryService = categoryService;
            _env = env;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _productService.GetDashboardProducts("Az");
            return View(products);
        }

        public IActionResult Create()
        {

            var categories = _categoryService.GetCategoriesByLanguage("Az");
            ViewBag.Category = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDTO productCreate, List<IFormFile> Photos)
        {
            try
            {
                List<string> photoList = new();
                for (int i = 0; i < Photos.Count; i++)
                {
                    var path = "/uploads/" + Guid.NewGuid() + Photos[i].FileName;
                    using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                    {
                        Photos[i].CopyTo(fileStream);
                    }
                    photoList.Add(path);
                }
                productCreate.PhotoUrl = photoList;
                _productService.AddProduct(productCreate);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(productCreate);
            }
        }
    }
}

