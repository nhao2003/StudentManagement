using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Hocluc
    {
        public Hocluc()
        {
            Kqhockytonghops = new HashSet<Kqhockytonghop>();
            Kqnamhocs = new HashSet<Kqnamhoc>();
        }

        public string MaHocLuc { get; set; } = null!;
        public string TenHocLuc { get; set; } = null!;
        public double DiemCanDuoi { get; set; }
        public double DiemCanTren { get; set; }
        public double DiemKhongChe { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Kqhockytonghop> Kqhockytonghops { get; set; }
        public virtual ICollection<Kqnamhoc> Kqnamhocs { get; set; }
    }
}
