using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Core.Entities.Concrete;
using MultiShop.Entities.DTOs.CartDTO;
using MultiShop.Entities.DTOs.OrderDTO;
using MultiShop.Entities.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;

        public CartController(IProductService productService, IHttpContextAccessor httpContext, UserManager<User> userManager, IOrderService orderService)
        {
            _productService = productService;
            _httpContext = httpContext;
            _userManager = userManager;
            _orderService = orderService;
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

        public async Task<IActionResult> CheckOut()
        {
            string? userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var findUser = await _userManager.FindByIdAsync(userId);
            var cookie = Request.Cookies["products"];
            if (cookie == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var datas = JsonSerializer.Deserialize<List<CartItemDTO>>(cookie);
            List<string> ids = datas.Select(x => x.Id).ToList();
            List<int> quantity = datas.Select(x => x.Quantity).ToList();
            var products = _productService.GetProductsById("En", ids, quantity);


            CheckOutVM vm = new()
            {
               User = findUser,
               CartProducts = products
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderItemDTO orderItem)
        {
            orderItem.UserId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _orderService.OrderProduct(orderItem);
            Response.Cookies.Delete("products");
            return RedirectToAction("Index");
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
            return Json("Ok");
        }
    }
}

