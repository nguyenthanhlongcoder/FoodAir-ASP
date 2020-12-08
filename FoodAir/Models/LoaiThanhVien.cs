namespace FoodAir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiThanhVien")]
    public partial class LoaiThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThanhVien()
        {
            ThanhViens = new HashSet<ThanhVien>();
        }

        [Key]
        public int MaLoaiTV { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        public int? UuDai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
    }
}
