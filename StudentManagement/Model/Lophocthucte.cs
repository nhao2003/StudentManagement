using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Lophocthucte
    {
        public Lophocthucte()
        {
            Phanconggiangdays = new HashSet<Phanconggiangday>();
            Mahs = new HashSet<Hocsinh>();
        }

        public string Malhtt { get; set; } = null!;
        public string? Malop { get; set; }
        public string? Manh { get; set; }
        public string? Magvcn { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual Giaovien? MagvcnNavigation { get; set; }
        public virtual Lop? MalopNavigation { get; set; }
        public virtual Namhoc? ManhNavigation { get; set; }
        public virtual ICollection<Phanconggiangday> Phanconggiangdays { get; set; }

        public virtual ICollection<Hocsinh> Mahs { get; set; }
    }
}
