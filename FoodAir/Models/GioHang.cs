using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAir.Models
{
    public class GioHang
    {
        public string TenSP { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string HinhAnh { get; set; }
        public decimal ThanhTien { get; set; }
        public GioHang(int iMaSP, int sl)
        {
            using(QuanLiBanHangModel db = new QuanLiBanHangModel())
            {
                this.MaSP = iMaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
                this.TenSP = sp.TenSP;
                this.HinhAnh = sp.HinhAnh;
                this.DonGia = sp.DonGia.Value;
                this.ThanhTien = DonGia * SoLuong;

            }
        }
        public GioHang(int iMaSP)
        {
            using (QuanLiBanHangModel db = new QuanLiBanHangModel())
            {
                this.MaSP = iMaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
                this.TenSP = sp.TenSP;
                this.SoLuong = 1;
                this.HinhAnh = sp.HinhAnh;
                this.DonGia = sp.DonGia.Value;
                this.ThanhTien = DonGia * SoLuong;

            }
        }

    }
}