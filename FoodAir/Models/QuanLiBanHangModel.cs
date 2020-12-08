namespace FoodAir.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLiBanHangModel : DbContext
    {
        public QuanLiBanHangModel()
            : base("name=QuanLiBanHangEntities")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LoaiThanhVien> LoaiThanhViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonDatHang>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonDatHangs)
                .WithOptional(e => e.KhachHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiThanhVien>()
                .HasMany(e => e.ThanhViens)
                .WithOptional(e => e.LoaiThanhVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.KhachHangs)
                .WithOptional(e => e.ThanhVien)
                .WillCascadeOnDelete();
        }
    }
}
