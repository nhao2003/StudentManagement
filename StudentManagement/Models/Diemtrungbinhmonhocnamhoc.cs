using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Diemtrungbinhmonhocnamhoc
    {
        public string Mahs { get; set; } = null!;
        public string Manh { get; set; } = null!;
        public string Mamh { get; set; } = null!;
        public double DtbmonHocNamHoc { get; set; }

        public virtual Hocsinh MahsNavigation { get; set; } = null!;
        public virtual Monhoc MamhNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}
