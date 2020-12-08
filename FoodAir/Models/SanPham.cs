namespace FoodAir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuans = new HashSet<BinhLuan>();
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(255)]
        public string TenSP { get; set; }

        public decimal? DonGia { get; set; }

        public string MoTa { get; set; }

        public string HinhAnh { get; set; }

        public int? SoLuongTon { get; set; }

        public int? LuotBinhChon { get; set; }

        public int? LuotBinhLuan { get; set; }

        public int? SoLanMua { get; set; }

        public int? Moi { get; set; }

        public int? MaLoaiSP { get; set; }

        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
