using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodAir.Models;

namespace FoodAir.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        QuanLiBanHangModel db = new QuanLiBanHangModel();
        public ActionResult Index()
        {
            //var lstKH = from KH in db.KhachHangs select KH;
            var lstKH = db.KhachHangs.ToList();
            return View(lstKH);
        }
        public ActionResult Index1()
        {
            var lstKH = from KH in db.KhachHangs select KH;
            return View(lstKH);
        }
        public ActionResult TruyVanDoiTuong()
        {
            KhachHang khachHang = db.KhachHangs.SingleOrDefault(n => n.MaKH == 2);
            return View(khachHang);
        }

        public ActionResult SortDuLieu()
        {
            List<KhachHang> list = db.KhachHangs.OrderByDescending(n => n.TenKH).ToList();
            return View(list);
        }
        
    }
}