using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Loaikiemtra
    {
        public Loaikiemtra()
        {
            Diemmonhocs = new HashSet<Diemmonhoc>();
        }

        public string Malkt { get; set; } = null!;
        public string? Tenloaikiemtra { get; set; }
        public double Tile { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Diemmonhoc> Diemmonhocs { get; set; }
    }
}
