using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Entities.DTOs.CartDTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var cookie = Request.Cookies["products"];
            if (cookie != null)
            {
                var datas = JsonSerializer.Deserialize<List<CartItemDTO>>(cookie);
                List<string> ids = datas.Select(x => x.Id).ToList();
                List<int> quantity = datas.Select(x => x.Quantity).ToList();
                var product = _productService.GetProductsById("En", ids, quantity);
                return View(product);
            }

            return View();
         
        }

        public JsonResult AddToCart(string Id, int Quantity)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";
            CartItemDTO cartItemDTO = new()
            {
                Id = Id,
                Quantity = Quantity
            };
            var cookie = Request.Cookies["products"];
            if (cookie == null)
            {
                List<CartItemDTO> cartItems = new();
                cartItems.Add(cartItemDTO);
                var result = JsonSerializer.Serialize<List<CartItemDTO>>(cartItems);

                Response.Cookies.Append("products", result, cookieOptions);
            }
            else
            {
                var datas = JsonSerializer.Deserialize<List<CartItemDTO>>(cookie);

                var pro = datas.FirstOrDefault(x => x.Id == Id);
                if (pro != null)
                {
                    pro.Quantity += Quantity;
                }
                else
                {
                    datas.Add(cartItemDTO);
                }

                var updatedDate = JsonSerializer.Serialize<List<CartItemDTO>>(datas);
                Response.Cookies.Append("products", updatedDate, cookieOptions);

            }

            return Json("");
        }
    }
}

