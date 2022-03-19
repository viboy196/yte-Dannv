using Microsoft.AspNetCore.Mvc;
using Xcomp.Data.TinhNang;

namespace Xcomp.Web.Controllers
{
    public class SanController : Controller
    {
        public async Task<IActionResult> Index(string id = "", string idls = "")
        {
            if (idls != "")
            {
                var ls = await AC.LoaiSan.GetById(idls);
                if (ls != null)
                {
                    var dss = await AC.San.GetByCode(ls.Code);
                    if (dss.Count > 0)
                    {
                        TempData["idsan"] = dss[0].Id;
                    }
                    else return Redirect("/");
                }
            }
            else TempData["idsan"] = id;  
                        
            return View();
        }
    }
}
