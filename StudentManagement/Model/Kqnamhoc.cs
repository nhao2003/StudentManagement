using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Kqnamhoc
    {
        public string Mahs { get; set; } = null!;
        public string Manh { get; set; } = null!;
        public string? MaHocLuc { get; set; }
        public string? MaHanhKiem { get; set; }
        public string? MaKetQua { get; set; }

        public virtual Hanhkiem? MaHanhKiemNavigation { get; set; }
        public virtual Hocluc? MaHocLucNavigation { get; set; }
        public virtual Ketqua? MaKetQuaNavigation { get; set; }
        public virtual Hocsinh MahsNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}
