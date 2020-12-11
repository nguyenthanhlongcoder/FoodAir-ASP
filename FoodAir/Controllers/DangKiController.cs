using FoodAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
using System.Web.UI;

namespace FoodAir.Controllers
{
   
    public class DangKiController : Controller
    {
        QuanLiBanHangModel db = new QuanLiBanHangModel();
        // GET: DangKi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangKi(FormCollection f)
        {
            string sHoVaTen = f["name"].ToString();
            string sEmail = f["email"].ToString();
            string sSoDienThoai = f["phone"].ToString();
            string sUsername = f["username"].ToString();
            string sPasword1 = f["password1"].ToString();
            string sPassword2 = f["password2"].ToString();
            string sDiaCHi = f["diachi"].ToString();

            ThanhVien tv = new ThanhVien();
            tv.HoTen = sHoVaTen;
            tv.Email = sEmail;
            tv.DiaChi = sDiaCHi;
            tv.SoDienThoai = sSoDienThoai;
            tv.TaiKhoan = sUsername;
            tv.MatKhau = sPasword1;
            if (sPasword1 == sPassword2)
            {
                if (this.IsCaptchaValid("Captcha is not valid"))
                {
                    db.ThanhViens.Add(tv);
                    db.SaveChanges();
                    Response.Write("<script>alert('Đăng Kí Thành Công')</script>");

                    return RedirectToAction("Index", "DangNhap");
                }
                else
                {
                    Response.Write("<script>alert('Captch sai')</script>");
                    return View("Index");
                }
            }
            else
            {
                Response.Write("<script>alert('Mật khẩu không trùng khớp')</script>");
                return View("Index");
            }
        }
    }
}