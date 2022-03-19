using Microsoft.AspNetCore.Mvc;

namespace Xcomp.Web.Controllers
{
    public class KiosController : Controller
    {
        public IActionResult Index(string id = "")
        {
            ViewBag.id = id;
            return View();
        }
    }
}
