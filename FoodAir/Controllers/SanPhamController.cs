using FoodAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAir.Controllers
{
    public class SanPhamController : Controller
    {
        QuanLiBanHangModel db = new QuanLiBanHangModel();

        public ViewResult Index()
        {
            var lstLoaiSP = db.LoaiSanPhams;
            return View(lstLoaiSP);
        }
        public ActionResult SanPhamPartial(int MaLoaiSP)
        {
            var lstSanPham = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP);
            return PartialView(lstSanPham);
        }
      
    }
}