using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Diemmonhoc
    {
        public string Mahs { get; set; } = null!;
        public string Mahk { get; set; } = null!;
        public string Mamh { get; set; } = null!;
        public string Manh { get; set; } = null!;
        public string Malkt { get; set; } = null!;
        public double Diem { get; set; }

        public virtual Hocky MahkNavigation { get; set; } = null!;
        public virtual Hocsinh MahsNavigation { get; set; } = null!;
        public virtual Loaikiemtra MalktNavigation { get; set; } = null!;
        public virtual Monhoc MamhNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}