using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Giaovien
    {
        public Giaovien()
        {
            Lophocthuctes = new HashSet<Lophocthucte>();
            Mamhs = new HashSet<Monhoc>();
        }

        public string Magv { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? Hocvi { get; set; }

        public virtual Taikhoan UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Lophocthucte> Lophocthuctes { get; set; }

        public virtual ICollection<Monhoc> Mamhs { get; set; }
    }
}
