using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;
using Xcomp.Web.Models;

namespace Xcomp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Index

        public IActionResult ChuyenHeThong()
        {
            return View();
        }

        public IActionResult Index()
        {
            var action = "index";
            var controller = "home";

            if (SystemInfo.SystemType == SystemType.HeThong)
            {
                switch (SystemInfo.CodeHeThong)
                {
                    case CodeHeThong.YTeMoi:
                        action = "index_ytemoi"; break;
                    case CodeHeThong.VaoLop:
                        action = "index_vaolop"; break;
                    case CodeHeThong.Xcomp:
                        action = "index_xcomp"; break;
                    case CodeHeThong.CuaPhat:
                        action = "index_cuaphat"; break;
                    case CodeHeThong.BaoHiem:
                        action = "index_baohiem"; break;
                    case CodeHeThong.LamBep:
                        action = "index_lambep"; break;
                    case CodeHeThong.IoT:
                        action = "index_iot"; break;
                    case CodeHeThong.Kachiusa:
                        action = "index_kachiusa"; break;
                    case CodeHeThong.PhongChayChuaChay:
                        action = "index_pccc"; break;
                    case CodeHeThong.NongNghiep:
                        action = "index_nongnghiep"; break;
                    case CodeHeThong.AnNinh:
                        action = "index_anninh"; break;

                    default: action = "index"; break;
                }
            } else
            if (SystemInfo.SystemType == SystemType.Kios)
            {
                controller = "kios";
                action = "index";
            } else
            if (SystemInfo.SystemType == SystemType.San)
            {
                controller = "San";
                action = "index";
            } 
            else
            if (SystemInfo.SystemType == SystemType.ToChuc)
            {
                controller = "ToChuc";
                action = "index";
            }

            //Chạy vào giao diện của hệ thống hiện tại
            var routeValue = new RouteValueDictionary
            (new { action = action, controller = controller });
            return RedirectToRoute(routeValue);
        }

        public async Task<IActionResult> go(string id)
        {
            SystemInfo.HeThong = await AC.HeThong.GetById(id);
            SystemInfo.CodeHeThong = SystemInfo.HeThong.CodeHeThong;
            return Redirect("/");
        }


        public IActionResult Index_ytemoi()
        {
            return View();
        }


        public IActionResult Index_nongnghiep()
        {
            return View();
        }


        public IActionResult Index_baohiem()
        {
            return View();
        }


        public IActionResult Index_vaolop()
        {
            return View();
        }


        public IActionResult Index_lambep()
        {
            return View();
        }


        public IActionResult Index_iot()
        {
            return View();
        }

        public IActionResult Index_anninh()
        {
            return View();
        }


        public IActionResult Index_xcomp()
        {
            return View();
        }

        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var ehf = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewData["ErrorMessage"] = ehf.Error.Message;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}