using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Lop
    {
        public Lop()
        {
            Lophocthuctes = new HashSet<Lophocthucte>();
        }

        public string Malop { get; set; } = null!;
        public int? Khoi { get; set; }
        public string? Tenlop { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Lophocthucte> Lophocthuctes { get; set; }
    }
}
