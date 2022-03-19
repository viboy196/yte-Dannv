using Microsoft.AspNetCore.Mvc;
using Xcomp.Data.TinhNang;

namespace Xcomp.Web.Controllers
{
    public class ToChucController : Controller
    {
        public async Task<IActionResult> Index(string id = "")
        {
            ViewBag.id = id;

            var tc = await AC.ToChuc.GetById(id);

            if (tc.IdTrangChu != null)
            {
                var trang = await AC.Trang.GetById(tc.IdTrangChu);
                return Redirect("/tochuc/"+trang.CodeMauTrang+"/"+trang.Id);
            }       
            
            return View();
        }

        #region Mẫu web phổ thông

        #region --- Trang giới thiệu
        public async Task<IActionResult> lmt_gioithieu_phothong(string id = "")
        {
            ViewBag.idt = id;
            var trang = await AC.Trang.GetById(id);
            ViewBag.id = trang.IdToChuc;
            return View();
        }
        
        #endregion

        #endregion
    }
}
