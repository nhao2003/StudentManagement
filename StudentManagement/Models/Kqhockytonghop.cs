using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Kqhockytonghop
    {
        public string Mahs { get; set; } = null!;
        public string Mahk { get; set; } = null!;
        public string Manh { get; set; } = null!;
        public string? MaHocLuc { get; set; }
        public string? MaHanhKiem { get; set; }
        public double? DtbtatCaMonHocKy { get; set; }

        public virtual Hanhkiem? MaHanhKiemNavigation { get; set; }
        public virtual Hocluc? MaHocLucNavigation { get; set; }
        public virtual Hocky MahkNavigation { get; set; } = null!;
        public virtual Hocsinh MahsNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}
