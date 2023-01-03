using LinkShortener.Data;
using LinkShortener.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace LinkShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LinkShortenerContext _context;

        public HomeController(ILogger<HomeController> logger, LinkShortenerContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        public IActionResult Index()
        {
            ViewData["urlSite"] = HttpContext.Request.GetDisplayUrl().ToString();
            if (User.Identity.IsAuthenticated)
            {
                var userId = _context.User.FirstOrDefault(u => u.UserName == User.Identity.Name).UserId;
                var urls = _context.ShortUrl.Include(u => u.User).Where(u => u.UserId == userId);
                return View(urls);
            }
            else
            {
                return View();
            }

        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
