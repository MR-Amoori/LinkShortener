using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    public class ScriptController : Controller
    {
        public IActionResult AddScript()
        {
            return View();
        }
    }
}
