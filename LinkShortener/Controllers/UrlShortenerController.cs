using LinkShortener.Data;
using LinkShortener.Models;
using LinkShortener.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LinkShortener.Controllers
{
    public class UrlShortenerController : Controller
    {
        private LinkShortenerContext _context;

        public UrlShortenerController(LinkShortenerContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GenerateLink()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateLink(ShortUrl url)
        {
            if (!ModelState.IsValid)
            {
                return View(url);
            }

            var user = _context.User.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (_context.ShortUrl.Where(u => u.UserId == user.UserId).Any(l => l.Link == url.Link))
            {
                ModelState.AddModelError("Link", "قبلا این لینک وارد شده است");
                return View(url);
            }

            int value = 0;

            while (true)
            {
                value = RandomGenerator.randomNumbe();

                var urlIds = _context.ShortUrl.Any(u => u.LinkId == value);

                if (urlIds == true)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }


            ShortUrl shortUrl = new ShortUrl()
            {
                Link = url.Link,
                CreateDate = DateTime.Now,
                Visit = 0,
                UserId = user.UserId,
                ShortLink = $"c/{value}",
                User = user
            };


            _context.ShortUrl.Add(shortUrl);
            _context.SaveChanges();


            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }



        [Route("c/{id?}")]
        public IActionResult ActionLink(int id)
        {
            var url = _context.ShortUrl.FirstOrDefault(u => u.ShortLink == $"c/{id}");
            if (url != null)
            {
                _context.ShortUrl.FirstOrDefault(u => u.ShortLink == $"c/{id}").Visit += 1;
                _context.SaveChanges();
                return Redirect(url.Link);
            }

            return NotFound(url);
        }


    }
}
