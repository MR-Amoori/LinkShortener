using LinkShortener.Data;
using LinkShortener.Models;
using LinkShortener.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using ZXing.QrCode;
using ZXing;
using Microsoft.AspNetCore.Http.Extensions;

namespace LinkShortener.Controllers
{
    public class ScriptController : Controller
    {
        private readonly LinkShortenerContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ScriptController(LinkShortenerContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult AddScript()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddScript(Script model)
        {
            DateTime Expry = DateTime.Now.AddDays(model.ExpiryDateNum);
            model.ExpiryDate = Expry;

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
                ExpiryDate = model.ExpiryDate,
                ExpiryDateNum = model.ExpiryDateNum,
                IsActive = model.IsActive,
                Visit = 0,
                UserId = user.UserId,
                ShortLink = $"s/{value}",
                NumberPhone = model.NumberPhone,
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

            DateTime Expry = scriptt.CreateDate.AddDays(scriptt.ExpiryDateNum);
            scriptt.ExpiryDate = Expry;

            target.Customer = scriptt.Customer;
            target.NumberPhone = scriptt.NumberPhone;
            target.script = scriptt.script;
            target.IsActive = scriptt.IsActive;
            target.ExpiryDate = scriptt.ExpiryDate;
            target.ExpiryDateNum = scriptt.ExpiryDateNum;
            target.Visit = scriptt.Visit;

            _context.Scripts.Update(target);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult DeleteScript(int id)
        {
            var script = _context.Scripts.FirstOrDefault(x => x.ScriptId == id);
            return View(script);
        }

        [HttpPost]
        public IActionResult DeleteScript(string id)
        {
            var script = _context.Scripts.Find(int.Parse(id));
            _context.Scripts.Remove(script);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



        [Route("s/{id?}")]
        public string ActionScript(int id)
        {
            var script = _context.Scripts.FirstOrDefault(s => s.ShortLink == $"s/{id}");
            if (script != null)
            {
                if (script.IsActive)
                {
                    if (DateTime.Now < script.ExpiryDate)
                    {
                        _context.Scripts.FirstOrDefault(s => s.ShortLink == $"s/{id}").Visit += 1;
                        _context.SaveChanges();
                        return script.script;
                    }
                    else
                    {
                        script.IsActive = false;
                        _context.Scripts.Update(script);
                        _context.SaveChanges();
                        return "vmess://ewogICAgImFkZCI6ICJOb3RGb3VuZCIsCiAgICAiYWlkIjogIjAiLAogICAgImhvc3QiOiAiIiwKICAgICJpZCI6ICI4Y2E3YWJlNS1hNjFjLTQzNDItZGM5MC05NjhiYmQ5NzE4MmEiLAogICAgIm5ldCI6ICJ3cyIsCiAgICAicGF0aCI6ICIvIiwKICAgICJwb3J0IjogIjk5OTk5IiwKICAgICJwcyI6ICLYqtin2LHbjNiuINin2YbZgti22Kcg2K3Ys9in2Kgg2LTZhdinINio2Ycg2b7Yp9uM2KfZhiDYsdiz24zYr9mHINin2LPYqi4iLAogICAgInNjeSI6ICJhdXRvIiwKICAgICJzbmkiOiAiIiwKICAgICJ0bHMiOiAidGxzIiwKICAgICJ0eXBlIjogIiIsCiAgICAidiI6ICIyIgp9Cg==";
                    }
                }
            }

            return "vmess://eyJhZGQiOiJOb3RGb3VuZCIsImFpZCI6IjAiLCJob3N0IjoiIiwiaWQiOiI4Y2E3YWJlNS1hNjFjLTQzNDItZGM5MC05NjhiYmQ5NzE4MmEiLCJuZXQiOiJ3cyIsInBhdGgiOiIvIiwicG9ydCI6Ijk5OTk5IiwicHMiOiLYrdiz2KfYqCDYtNmF2Kcg2LrbjNixINmB2LnYp9mEINin2LPYqiIsInNjeSI6ImF1dG8iLCJzbmkiOiIiLCJ0bHMiOiJ0bHMiLCJ0eXBlIjoiIiwidiI6IjIifQ==";
        }


        public IActionResult QR(string id, string customerName)
        {
            HttpContextAccessor ss = new HttpContextAccessor();
            string url;
            var baseUrl = HttpContext.Request.Host.Value;
            url = id.Remove(0, 4);
            url = url.Insert(0, "s/");
            url = url.Insert(0, baseUrl + "/");
            url = url.Insert(0, "https://");
            var writer = new QRCodeWriter();
            //generate QR Code
            var resultBit = writer.encode(url, BarcodeFormat.QR_CODE, 100, 100);
            //get Bitmatrix result
            var matrix = resultBit;

            //convert bitmatrix into image 
            int scale = 2;

            Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
            for (int x = 0; x < matrix.Height; x++)
                for (int y = 0; y < matrix.Width; y++)
                {
                    Color pixel = matrix[x, y] ? Color.Black : Color.White;
                    for (int i = 0; i < scale; i++)
                        for (int j = 0; j < scale; j++)
                            result.SetPixel(x * scale + i, y * scale + j, pixel);
                }

            //get wwwroot folder location
            string webRootPath = _hostingEnvironment.WebRootPath;

            //save result as png inside 'Images' folder
            result.Save(webRootPath + "\\Images\\Qrcode.png");

            //pass the image in result
            ViewBag.QrCode = "\\Images\\Qrcode.png";
            ViewBag.Name = customerName;

            return View();
        }
    }
}
