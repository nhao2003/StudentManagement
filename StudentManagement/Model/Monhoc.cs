using System;
using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Diemmonhocs = new HashSet<Diemmonhoc>();
            Khananggiangdays = new HashSet<Khananggiangday>();
            Kqhockymonhocs = new HashSet<Kqhockymonhoc>();
            Phanconggiangdays = new HashSet<Phanconggiangday>();
        }

        public string Mamh { get; set; } = null!;
        public string? Tenmh { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Diemmonhoc> Diemmonhocs { get; set; }
        public virtual ICollection<Khananggiangday> Khananggiangdays { get; set; }
        public virtual ICollection<Kqhockymonhoc> Kqhockymonhocs { get; set; }
        public virtual ICollection<Phanconggiangday> Phanconggiangdays { get; set; }
    }
}
