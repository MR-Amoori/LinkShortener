using LinkShortener.Data;
using LinkShortener.Models;
using LinkShortener.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.Linq;
using ZXing.QrCode;
using ZXing;
using Microsoft.AspNetCore.Hosting;


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
                ShortLink = $"u/{value}",
                User = user
            };


            _context.ShortUrl.Add(shortUrl);
            _context.SaveChanges();


            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }



        [Route("u/{id?}")]
        public IActionResult ActionLink(int id)
        {
            var url = _context.ShortUrl.FirstOrDefault(u => u.ShortLink == $"u/{id}");
            if (url != null)
            {
                _context.ShortUrl.FirstOrDefault(u => u.ShortLink == $"u/{id}").Visit += 1;
                _context.SaveChanges();
                return Redirect(url.Link);
            }

            return NotFound(url);
        }



        public IActionResult QR(string id, string customerName)
        {
            string url;
            var baseUrl = HttpContext.Request.Host.Value;
            url = id.Remove(0, 4);
            url = url.Insert(0, "u/");
            url = url.Insert(0, baseUrl + "/");
            url = url.Insert(0, "https://");

            //generate QR Code
            ViewBag.qr = $"https://api.qrserver.com/v1/create-qr-code/?data={url}&amp;size=100x100";

            ViewBag.Name = customerName;

            return View();
        }


    }
}
