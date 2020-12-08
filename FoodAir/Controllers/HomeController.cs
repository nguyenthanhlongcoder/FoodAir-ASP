using FoodAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAir.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLiBanHangModel db = new QuanLiBanHangModel();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPhamMoiPartial()
        {
            var lstSanPhamMoi = db.SanPhams.Where(n => n.Moi == 1);
            return PartialView(lstSanPhamMoi);
        }
    }
}