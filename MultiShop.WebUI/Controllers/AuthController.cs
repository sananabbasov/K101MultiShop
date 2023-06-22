using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Core.Entities.Concrete;
using MultiShop.Core.Helpers;
using MultiShop.Entities.DTOs.UserDTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;
        private readonly EmailHelper _emailHelper;
        public AuthController(UserManager<User> userManager, SignInManager<User> singInManager, EmailHelper emailHelper)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _emailHelper = emailHelper;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _singInManager.PasswordSignInAsync(user,loginDTO.Password,loginDTO.RememberMe,false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (user != null)
            {
                return View();
            }
            string userToken = Guid.NewGuid().ToString().Replace("-","") + Guid.NewGuid().ToString().Replace("-", "");
            User newUser = new()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                BirthDay = DateTime.Now,
                UserToken = userToken
            };
            var result = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (result.Succeeded)
            {
                //_emailHelper.SendConfirmationEmail(newUser.Email, userToken, newUser.FirstName, newUser.LastName);
                return RedirectToAction("Login");
            }
            return View(registerDTO);
        }


        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user =await _userManager.FindByEmailAsync(email);
            if (user.UserToken == token)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login");
            }

            return NotFound();
         
        }


        public async Task<IActionResult> Logout()
        {
           await _singInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

