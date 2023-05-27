using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Ketqua
    {
        public Ketqua()
        {
            Kqnamhocs = new HashSet<Kqnamhoc>();
        }

        public string MaKetQua { get; set; } = null!;
        public string TenKetQua { get; set; } = null!;
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Kqnamhoc> Kqnamhocs { get; set; }
    }
}
