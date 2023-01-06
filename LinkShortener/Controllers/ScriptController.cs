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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_context.Scripts.Any(c => c.Customer == model.Customer))
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


            Script script = new Script()
            {
                script = model.script,
                Customer = model.Customer,
                CreateDate = DateTime.Now,
                IsActive = model.IsActive,
                Visit = 0,
                UserId = user.UserId,
                ShortLink = $"s/{value}",
                User = user
            };


            _context.Scripts.Add(script);
            _context.SaveChanges();

            return RedirectToAction("index", "home");
        }


        public IActionResult UpdateScript(int id)
        {
            var script = _context.Scripts.FirstOrDefault(x => x.ScriptId == id);
            return View(script);
        }

        [HttpPost]
        public IActionResult UpdateScript(Script scriptt)
        {
            var target = _context.Scripts.FirstOrDefault(c => c.ScriptId == scriptt.ScriptId);

            if (_context.Scripts.Any(x => x.Customer == scriptt.Customer))
            {
                if (target.Customer == scriptt.Customer)
                {

                }
                else
                {
                    return View(scriptt);
                }
            }

            target.Customer = scriptt.Customer;
            target.script = scriptt.script;
            target.IsActive = scriptt.IsActive;

            _context.Scripts.Update(target);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}
