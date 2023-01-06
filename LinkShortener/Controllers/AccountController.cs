using LinkShortener.Data;
using LinkShortener.Models;
using LinkShortener.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace LinkShortener.Controllers
{
    public class AccountController : Controller
    {

        private LinkShortenerContext _context;
        public AccountController(LinkShortenerContext context)
        {
            _context = context;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            else if (_context.User.Any(u => u.Email == register.Email))
            {
                //  return Content(content: $"ثبت نام کرده است '{register.Email}' قبلا ایمیل");

                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است، برای بازنشانی رمز عبور با پشتیبانی در ارتباط باشید.");
                return View(register);
            }

            else if (_context.User.Any(u => u.UserName == register.UserName))
            {
                //  return Content(content: $"ثبت نام کرده است '{register.Email}' قبلا ایمیل");

                ModelState.AddModelError("UserName", "نام کاربری وارد شده قبلا ثبت نام کرده است، لطفا نام دیگری انتخاب کنید");
                return View(register);
            }

            else
            {

                User user = new User()
                {
                    Email = register.Email.ToLower(),
                    Password = register.Password,
                    IsAdmin = false,
                    NumberPhone = register.NumberPhone,
                    UserName = register.UserName.ToLower(),
                    IsActive = false
                };

                _context.User.Add(user);
                _context.SaveChanges();

                int userId = _context.User.SingleOrDefault(u => u.Email == user.Email).UserId;

            }

            return View("SuccessRegister", register.UserName);
        }





        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = _context.User
                .SingleOrDefault(u => u.Email == login.Email.ToLower() &&
                u.Password == login.Password);

            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
                return View(login);
            }

            if(!user.IsActive)
            {
                ModelState.AddModelError("", "حساب شما تایید نشده است، با پشتیبانی در تماس باشید.");
                return View(login);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.NumberPhone),
                new Claim(type: "IsAdmin", user.IsAdmin.ToString())
            };


            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);


            return Redirect("/");
        }




        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(actionName: "Login", controllerName: "Account");
        }

    }
}
