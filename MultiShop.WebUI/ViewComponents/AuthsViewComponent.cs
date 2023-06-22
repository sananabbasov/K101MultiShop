using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Core.Entities.Concrete;

namespace MultiShop.WebUI.ViewComponents
{
	public class AuthsViewComponent : ViewComponent
	{

		private readonly IHttpContextAccessor _httpContext;
		private readonly UserManager<User> _userManager;

        public AuthsViewComponent(IHttpContextAccessor httpContext, UserManager<User> userManager)
        {
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var user = await _userManager.FindByIdAsync(userId);
			return View("Auths", user);
		}
	}
}

