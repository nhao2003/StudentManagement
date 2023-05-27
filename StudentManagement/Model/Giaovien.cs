using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Giaovien
    {
        public Giaovien()
        {
            Khananggiangdays = new HashSet<Khananggiangday>();
            Lophocthuctes = new HashSet<Lophocthucte>();
            Phanconggiangdays = new HashSet<Phanconggiangday>();
        }

        public string Magv { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? Hocvi { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual Taikhoan UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Khananggiangday> Khananggiangdays { get; set; }
        public virtual ICollection<Lophocthucte> Lophocthuctes { get; set; }
        public virtual ICollection<Phanconggiangday> Phanconggiangdays { get; set; }
    }
}
