using FoodAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAir.Controllers
{
    public class DangNhapController : Controller
    {
        QuanLiBanHangModel db = new QuanLiBanHangModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["name"].ToString();
            string sMatKhau = f["password"].ToString();

            ThanhVien tv = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);

            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                Response.Write("<script>alert('Sai tài khoản hoặc mật khẩu')</script>");
                return View("Index");
            }
            


        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}