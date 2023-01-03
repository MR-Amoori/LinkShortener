using LinkShortener.Data;
using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LinkShortener.Controllers
{
    public class LinkController : Controller
    {
        private LinkShortenerContext _context;
        public LinkController(LinkShortenerContext context)
        {
            _context = context;
        }
        public IActionResult Delete(int id)
        {
            var url = _context.ShortUrl.SingleOrDefault(u => u.LinkId == id);
            _context.ShortUrl.Remove(url);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        private ShortUrl shortUrl;
        public IActionResult Update(int id)
        {
            shortUrl = _context.ShortUrl.SingleOrDefault(u => u.LinkId == id);
            return View(shortUrl);
        }

        [HttpPost]
        public IActionResult Update(ShortUrl url)
        {
            if (url == null)
                return View(url);

            var urlInfo = _context.ShortUrl
                .SingleOrDefault(u => u.LinkId == url.LinkId);

            if (urlInfo != null)
            {

                _context.ShortUrl.SingleOrDefault(u => u.LinkId == urlInfo.LinkId).Link = url.Link;
                _context.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                ModelState.AddModelError("Link", "مشکلی روی داده است !");
                return View(url);
            }
        }

    }
}
