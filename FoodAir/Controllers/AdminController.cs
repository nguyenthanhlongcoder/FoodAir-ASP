using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodAir.Models;
namespace FoodAir.Controllers
{
    public class AdminController : Controller
    {
        QuanLiBanHangModel db = new QuanLiBanHangModel();

        // GET: Admin
        public ActionResult Index()
        {
            var lstLoaiSP = db.SanPhams;

            return View(lstLoaiSP);
        }
        public ActionResult TaoMoi()
        {
            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(FormCollection f)
        {
            string sTenSP = f["TenSanPham"].ToString();
            string sMoTa = f["MoTa"].ToString();
            int sDonGia = int.Parse(f["DonGia"].ToString());
            int sLoaiSP = int.Parse(f["LoaiSP"].ToString());
            string sHinhAnh = f["HinhAnh"].ToString();

            SanPham sp = new SanPham();

            sp.TenSP = sTenSP;
            sp.MoTa = sMoTa;
            sp.DonGia = sDonGia;
            sp.MaLoaiSP = sLoaiSP;
            sp.HinhAnh = sHinhAnh;

            db.SanPhams.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult ChinhSua(int MaSP)
        {
            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai");

            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            ViewBag.SanPham = sp;
            return View();
        }
        [HttpPost]
        public ActionResult CapNhat(FormCollection f)
        {
            int sMaSP = int.Parse(f["MaSP"].ToString());
            string sTenSP = f["TenSanPham"].ToString();
            string sMoTa = f["MoTa"].ToString();
            int sDonGia = int.Parse(f["DonGia"].ToString());
            int sLoaiSP = int.Parse(f["LoaiSP"].ToString());
            string sHinhAnh = f["HinhAnh"].ToString();

            SanPham sp = new SanPham();
            sp.MaSP = sMaSP;
            sp.TenSP = sTenSP;
            sp.MoTa = sMoTa;
            sp.DonGia = sDonGia;
            sp.MaLoaiSP = sLoaiSP;
            sp.HinhAnh = sHinhAnh;

            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Xoa(int MaSP)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult ChuaGiaoHang()
        {
            var lst = db.DonDatHangs.Where(n => n.TinhTrangGiaoHang == false).OrderBy(n => n.NgayDat);
            return View(lst);
        }
        public ActionResult DaGiaoHang()
        {
            var lst = db.DonDatHangs.Where(n => n.TinhTrangGiaoHang == true).OrderBy(n => n.NgayDat);
            return View(lst);
        }
        [HttpPost]
        public ActionResult ThongTinDonHang(FormCollection f)
        {
            int MaDDH = int.Parse(f["MaDDH"].ToString());
            var lst = db.ChiTietDonDatHangs.Where(n => n.MaDDH == MaDDH);
            ViewBag.TenKH = f["TenKH"].ToString();
            ViewBag.MaDDH = MaDDH;
            ViewBag.NgayDat = f["NgayDat"].Substring(0,21);
            ViewBag.TongTien = lst.Sum(n => n.SoLuong * n.DonGia);
            return View(lst);
        }
        [HttpPost]
        public ActionResult GiaoHang(FormCollection f)
        {
            int MaDDH = int.Parse(f["MaDDH"].ToString());
            DonDatHang ddh = db.DonDatHangs.SingleOrDefault(n => n.MaDDH == MaDDH);
           
            ddh.TinhTrangGiaoHang = true;

            db.SaveChanges();
            return RedirectToAction("ChuaGiaoHang", "Admin");
        }
    }
}