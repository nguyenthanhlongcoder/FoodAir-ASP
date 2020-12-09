using FoodAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAir.Controllers
{
    public class GioHangController : Controller
    {
        QuanLiBanHangModel db = new QuanLiBanHangModel();

        public ActionResult Index()
        {
            ViewBag.TongTien = TinhTongTien();
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            return PartialView();
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
                return lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int MaSP, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<GioHang> lstGioHang = LayGioHang();
            GioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);

            if(spCheck != null)
            {
                spCheck.SoLuong++;   
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }

            GioHang itemGH = new GioHang(MaSP);
            lstGioHang.Add(itemGH);
            return Redirect(strURL);

        }

        public double TinhTongSoLuong()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                return 0;
            }

            return lstGioHang.Sum(n => n.SoLuong);

        }

        public decimal TinhTongTien()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);

        }
        [HttpPost]
        public ActionResult SuaGioHang(int MaSP)
        {
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);

            if(spCheck == null)
            {
                return RedirectToAction("Index", "Home");

            }

            ViewBag.GioHang = lstGioHang;
            return View(spCheck);
        }
        [HttpPost]
        public ActionResult CapNhatGioHang(FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == Int32.Parse(f["MaSP"].ToString()));
            if(spCheck != null)
            {
                spCheck.SoLuong = Int32.Parse(f["SoLuong"].ToString());
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return RedirectToAction("Index", "GioHang");
            }
            return View();
        }
        public ActionResult DatHang()
        {
            if (Session["GioHang"] == null || Session["GioHang"] == "")
            {
                Response.Write("<script>alert('Giỏ Hàng Trống!')</script>");
            }
            if(Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Index", "DangNhap");
            }
            else
            {
                ThanhVien tv = (ThanhVien)Session["TaiKhoan"];
                DonDatHang ddh = new DonDatHang();
                ddh.NgayDat = DateTime.Now;
                ddh.MaKH = tv.MaThanhVien;
                ddh.TinhTrangGiaoHang = false;
                ddh.DaThanhToan = false;
                ddh.DaHuy = false;
                db.DonDatHangs.Add(ddh);
                db.SaveChanges();
                List<GioHang> lstGioHang = LayGioHang();
                
                ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
                foreach(GioHang item in lstGioHang)
                {
                    ctddh.MaSP = item.MaSP;
                    ctddh.SoLuong = item.SoLuong;
                    ctddh.DonGia = item.DonGia;
                    ctddh.TenSP = item.TenSP;
                    ctddh.MaDDH = db.DonDatHangs.Max(p => p.MaDDH);
                    db.ChiTietDonDatHangs.Add(ctddh);
                    db.SaveChanges();
                }
                
                Session["GioHang"] = null;
                Response.Write("<script>alert('Đặt Hàng Thành Công!')</script>");

                return RedirectToAction("Index", "GioHang");
            }
        }
    }
}