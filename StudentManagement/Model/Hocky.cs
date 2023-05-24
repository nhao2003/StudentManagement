using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Hocky
    {
        public Hocky()
        {
            Diemmonhocs = new HashSet<Diemmonhoc>();
            Kqhockymonhocs = new HashSet<Kqhockymonhoc>();
            Kqhockytonghops = new HashSet<Kqhockytonghop>();
        }

        public string Mahk { get; set; } = null!;
        public string? Tenhk { get; set; }

        public virtual ICollection<Diemmonhoc> Diemmonhocs { get; set; }
        public virtual ICollection<Kqhockymonhoc> Kqhockymonhocs { get; set; }
        public virtual ICollection<Kqhockytonghop> Kqhockytonghops { get; set; }
    }
}
