using LinkShortener.Data;
using LinkShortener.Models;
using LinkShortener.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Security.Policy;

namespace LinkShortener.Controllers
{
    public class ScriptController : Controller
    {
        private readonly LinkShortenerContext _context;

        public ScriptController(LinkShortenerContext context)
        {
            _context = context;
        }

        public IActionResult AddScript()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddScript(Script model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if (_context.Scripts.Any(c=>c.Customer == model.Customer))
            {
                ModelState.AddModelError("", "مشتری ثبت شده قبلا وجود داشته است");
                return View(model);
            }

            var user = _context.User.SingleOrDefault(u => u.UserName == User.Identity.Name);

            int value = 0;

            while (true)
            {
                value = RandomGenerator.randomNumbe();

                var urlIds = _context.ShortUrl.Any(u => u.LinkId == value);
                var urlScripts = _context.Scripts.Any(x => x.ScriptId == value);

                if (urlIds == true && urlScripts == true)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (model.ExpireDate == null)
            {
                model.ExpireDate = DateTime.Now;
            }

            Script script = new Script()
            {
                script = model.script,
                Customer = model.Customer, 
                CreateDate = DateTime.Now,
                ExpireDate = model.ExpireDate,
                Visit = 0,
                UserId = user.UserId,
                ShortLink = $"c/{value}",
                User = user
            };


            _context.Scripts.Add(script);
            _context.SaveChanges();

            return RedirectToAction("index","home");
        }
    }
}
