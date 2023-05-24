using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Diemmonhocs = new HashSet<Diemmonhoc>();
            Kqhockymonhocs = new HashSet<Kqhockymonhoc>();
            Magvs = new HashSet<Giaovien>();
        }

        public string Mamh { get; set; } = null!;
        public string? Tenmh { get; set; }

        public virtual ICollection<Diemmonhoc> Diemmonhocs { get; set; }
        public virtual ICollection<Kqhockymonhoc> Kqhockymonhocs { get; set; }

        public virtual ICollection<Giaovien> Magvs { get; set; }
    }
}
